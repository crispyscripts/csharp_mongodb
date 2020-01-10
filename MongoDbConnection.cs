namespace MongoDbConnection
{
    using System;

    public class MongoDbConnection
    {
        public const string ConnectionParameters = "mongodb+srv://{0}:{1}@{2}/test?retryWrites=true&w=majority";

        private string ConnectionString { get; set; }

        private Drivers.MongoDb MongoDb { get; }

        public MongoDbConnection(string username, string password, string address)
        {
            this.ConnectionString = string.Format(ConnectionParameters, username, password, address);
        }

        public Drivers.MongoDb GetMongoDbReference()
        {
            return new Drivers.MongoDb(this.ConnectionString);
        }
    }
}