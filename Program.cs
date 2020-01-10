namespace csharp_mongodb
{
    using System;
    using MongoDbConnection;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Connecting ");

            var connectionSettings = new ConnectionSettings();

            var user = connectionSettings.GetAdminUser();

            if (user != null)
            {
                var serverSettings = connectionSettings.GetServer();

                var connectionTest = new ConnectionTest(user.username, user.password, serverSettings.servername);

                connectionTest.Connect();

                var task = connectionTest.Test();

                while (!task.IsCompleted)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(1000);
                }

                Console.WriteLine();

                Console.WriteLine();

                Console.WriteLine(task.Result);
            }

            Console.ReadKey();
        }
    }
}
