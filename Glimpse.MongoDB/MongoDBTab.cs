using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Extensions;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Glimpse.MongoDB
{
    public class MongoDBTab: ITab, ITabSetup, IDocumentation
    {
        /// <summary>
        /// Ensures that the mongo profiling is turned on, and that any Mongo connections are properly tracked
        /// </summary>
        /// <param name="context"></param>
        public void Setup(ITabSetupContext context)
        {
        }

        public RuntimeEvent ExecuteOn
        {
            get
            {
                return RuntimeEvent.EndRequest;
            }
        }

        /// <summary>
        /// The context should contain the reference to any mongo connections, and the relevant profile document selection we need to extract from those connections.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object GetData(ITabContext context)
        {
            var cutOff = DateTime.UtcNow - TimeSpan.FromSeconds(15);
            var results = new List<MongoProfileModel>();
            foreach (var server in MongoServer.GetAllServers())
            {
                foreach (var database in server.GetDatabaseNames())
                {
                    var db = server.GetDatabase(database);
                    if (db.CollectionExists("system.profile"))
                    {
                        var query =
                                from e in db.GetCollection("system.profile").FindAllAs<SystemProfileInfo>()
                                where e.Namespace != database + ".system.profile" && e.Timestamp > cutOff
                                select new MongoProfileModel(e);
                        // skip one to miss the namespace query above
                        foreach (var d in query.OrderByDescending(x => x.Timestamp).Skip(1).Take(10))
                        {
                            results.Add(d);
                        }
                    }
                }
            }
            return results;
        }

        public string Name
        {
            get { return "MongoDB"; }
        }

        public Type RequestContextType
        {
            get { return null; }
        }
        /// <summary>
        /// A URL for a document containing a brief guide on installing the plugin, and interpreting the information it provides.
        /// </summary>
        public string DocumentationUri
        {
            get { return "https://github.com/simonellistonball/Glimpse.MongoDB/wiki/Using"; }
        }
    }
}
