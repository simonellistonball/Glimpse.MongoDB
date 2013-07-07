using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glimpse.MongoDB.Models
{
    class MongoCommandModel
    {
        public string ServerAddress { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
        public string CommandType { get; set; }
        /// <summary>
        /// A document associated with the request, usually relevant for writes (actual document) or queries (additional parameters)
        /// </summary>
        public object RequestDocument { get; set; }
    }
}
