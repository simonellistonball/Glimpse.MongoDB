using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
namespace Glimpse.MongoDB
{
    class MongoProfileModel
    {
        public string Operation { get; set; }
        public string Namespace { get; set; }
        public IDictionary Command { get; set; }
        public IDictionary Query { get; set; }
        public string Error { get; set; }
        public DateTime Timestamp { get; set; }
        public MongoProfileModel(SystemProfileInfo i)
        {
            Operation = i.Op;
            Namespace = i.Namespace;
            if (i.Command != null)
            {
                Command = i.Command.ToDictionary();
            }
            if (i.Query != null && i.Query.Count() > 0) {
                Query = i.Query.ToDictionary();
            }
            Error = i.Error;
            Timestamp = i.Timestamp;
        }
    }
}
