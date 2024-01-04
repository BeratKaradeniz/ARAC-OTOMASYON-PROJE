using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracOtomasyon
{
    public class AutomationManager
    {

        public static AutomationManager Instance { get; set; }

        public AutomationManager() {
            Instance = this;
            client = new MongoClient(AUTH_STRING);

         
            

            database = client.GetDatabase("aracauto");
        }

        static string AUTH_STRING = "mongodb+srv://behaulas:BvZ5QghbpxAYAX52@cluster0.yzv8l.mongodb.net/?retryWrites=true&w=majority";
        public static MongoClient client;

        public static IMongoDatabase database;
    }
}
