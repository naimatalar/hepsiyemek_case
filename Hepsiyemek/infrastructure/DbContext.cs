using Hepsiyemek.Helpers;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.infrastructure
{
    public class DbContext
    {
        private static MongoClient _client;
        private static MongoServer _server;
        private static MongoDatabase _database;
        private static DbContext Instance;
        

        private DbContext() { }
    

    
        public static DbContext ActiveInstance
        {

            get
            {
                if (Instance == null)
                {
                    
                    _client = new MongoClient(new ConnectionPorts().MongoDb);
                    
                    _server = _client.GetServer();
                    _database = _server.GetDatabase("hepsiyemek_naimatalarDB");
                    Instance = new DbContext();
                }
                
                return Instance;
            }
        }
        public MongoDatabase Db
        {
            get
            {

                return _database;
            }
        }
    }
}
