using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.Helpers
{
    public class ConnectionPorts 
    {
       

        public ConnectionPorts()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            Redis = configuration.GetSection("ConnectionPorts").GetSection("Redis").Value;
            MongoDb = configuration.GetSection("ConnectionPorts").GetSection("MongoDb").Value;


        }
   

        public string Redis { get; set; }
        public string MongoDb { get; set; }
    }

}
