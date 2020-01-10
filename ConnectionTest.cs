namespace MongoDbConnection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class ConnectionTest
    {
        public MongoDbConnection DbConnection { get; set; }

        public Drivers.MongoDb DbReference { get; set; }

        public ConnectionTest(string username, string password, string server)
        {
            this.DbConnection = new MongoDbConnection(username, password, server);
        }

        public void Connect()
        {
            this.DbReference = this.DbConnection.GetMongoDbReference();
        }

        public async Task<string> Test()
        {
            try
            {
                var db = this.DbReference.GetDatabase("business");

                var collection = db.GetCollection<BsonDocument>("reviews");

                var filter = new BsonDocument("rating", 5);

                var document = await collection.Find(filter).FirstAsync();

                return document.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            //using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        IEnumerable<BsonDocument> batch = cursor.Current;
            //        foreach (BsonDocument document in batch)
            //        {
            //            Console.WriteLine(document);
            //            Console.WriteLine();
            //        }
            //    }
            //}
        }
    }
}