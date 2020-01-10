namespace Drivers
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class MongoDb
    {
        public MongoClient Client { get; set; }

        public MongoDb(string connectionString)
        {
            this.Client = new MongoClient(connectionString);
        }

        public IMongoDatabase GetDatabase(string dbName)
        {
            return this.Client.GetDatabase(dbName);
        }

        public string Read()
        {
            return "Read";
        }

        public void Write()
        {
        }
    }
}