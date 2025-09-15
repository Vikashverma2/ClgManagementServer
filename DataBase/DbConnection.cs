using System;
using MongoDB.Driver;

namespace ClgManagementServer.DataBase;

public class DbConnection
{
    public readonly IMongoDatabase _database;

    public DbConnection()
    {
        var connectionString = "";
        var databaseName = "CollegeServer";


        // Create client and connect
        var client = new MongoClient(connectionString);

        // Get the database
        _database = client.GetDatabase(databaseName);

    }
       // Method to get a collection
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }



}
