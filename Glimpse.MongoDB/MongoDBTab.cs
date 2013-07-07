using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using MongoDB.Driver;

namespace Glimpse.MongoDB
{
    public class MongDBTab: ITab, ITabSetup, IDocumentation
    {
        /// <summary>
        /// Ensures that the mongo profiling is turned on, and that any Mongo connections are properly tracked
        /// </summary>
        /// <param name="context"></param>
        public void Setup(ITabSetupContext context)
        {
            throw new NotImplementedException();
        }

        private class CommandData {
            public string DocumentId { get; set; }
        }
        private class ServerData
        {
            public string Address { get; set; }
            public bool Primary { get; set; }
            public List<CommandData> Commands { get; set; }
        }

        /// <summary>
        /// The context should contain the reference to any mongo connections, and the relevant profile document selection we need to extract from those connections.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object GetData(ITabContext context)
        {
            var servers = GetAllServers();
           
            return servers;
        }

        private List<ServerData> GetAllServers()
        {
            var servers = new List<ServerData>();
            foreach (MongoServer server in MongoServer.GetAllServers())
            {
                var instance = server.Instance;

                // get the details of the commands run on this server during the session

                servers.Add(new ServerData
                {
                    Address = instance.Address.ToString(),
                    Primary = instance.IsPrimary
                });
            }
            return servers;
        }

        public RuntimeEvent ExecuteOn
        {
            get { return RuntimeEvent.EndRequest; }
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
