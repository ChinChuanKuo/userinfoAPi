using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace userinfoApi.App_Code
{
    public class corsorigins
    {
        public string connectionString()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(new database().connectionSystem()).AddJsonFile("connectionApi.json");
            var connection = configurationBuilder.Build().Get<configString>().connectionStrings;
            int total = connection.Count - 1;
            List<string> items = new List<string>();
            while (total >= 0)
            {
                items.Add(connection[total].ipconfig);
                total--;
            }
            return String.Join(",", items);
        }

        public class configString
        {
            public List<config> connectionStrings { get; set; }
        }

        public class config
        {
            public string ipconfig { get; set; }
        }
    }
}