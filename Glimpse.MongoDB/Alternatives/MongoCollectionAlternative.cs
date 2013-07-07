using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Glimpse.MongoDB.Alternatives
{
    public class MongoCollectionAlternative : IAlternateType<MongoCollection<BsonDocument>>
    {
        private IProxyFactory ProxyFactory { get; set; }
        private ILogger Logger { get; set; }

        private IEnumerable<IAlternateMethod> allMethodsMongoCollection;

        public MongoCollectionAlternative(IProxyFactory proxyFactory, ILogger logger)
        {
            ProxyFactory = proxyFactory;
            Logger = logger;
        }

        public IEnumerable<IAlternateMethod> AllMethodsRoute
        {
            get
            {
                return allMethodsMongoCollection ?? (allMethodsMongoCollection = new List<IAlternateMethod>
                {
                    new Find(typeof(System.Web.Routing.Route)),
                    new GetVirtualPath(typeof(System.Web.Routing.Route)),
                    new ProcessConstraint(),
                });
            }
        }

        private IProxyFactory ProxyFactory { get; set; }

        private ILogger Logger { get; set; }

    }
}
