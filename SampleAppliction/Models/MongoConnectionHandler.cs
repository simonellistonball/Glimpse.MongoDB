using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace SampleApplication.Models
{
    public class MongoConnectionHandler
    {
        public MongoConnectionHandler()
        {
            const string connectionString = "mongodb://localhost";
            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
        }
    }
}