using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SampleApplication.Models
{
    public class MongoMetaDataService
    {

        private static MongoServer connect()
        {
            const string connectionString = "mongodb://localhost";
            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
            return mongoServer;
        }
        internal static IEnumerable<string> AllDatabases()
        {
            var results = new List<string>();
            foreach (var database in connect().GetDatabaseNames())
            {
                results.Add(database);
            }
            return results;
        }

        internal static IEnumerable<string> AllCollections(string database)
        {
            return connect().GetDatabase(database).GetCollectionNames();
        }

        internal static IEnumerable<BsonDocument> Documents(string database, string collection)
        {
            return connect().GetDatabase(database).GetCollection(collection).FindAll();
        }
    }
}