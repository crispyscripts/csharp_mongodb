namespace csharp_mongodb
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Json.Net;
    using Newtonsoft.Json;

    public class ConnectionSettings
    {
        public User GetAdminUser()
        {
            var u = JsonConvert.DeserializeObject<Users>(File.ReadAllText(@"D:\vscode\csharp_mongodb\user.json"));

            return u.users.FirstOrDefault(x => x.usertype == "admin");
        }

        public Server GetServer()
        {
            var s = JsonConvert.DeserializeObject<Server>(File.ReadAllText(@"D:\vscode\csharp_mongodb\user.json"));

            return s;
        }
    }
}
