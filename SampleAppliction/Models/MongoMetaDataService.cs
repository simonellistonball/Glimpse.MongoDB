using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

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

        internal static dynamic GetDocument(string database, string collection, string document_id)
        {
            var db = connect();
            return db[database][collection].FindOneById(document_id);
        }
    }
}