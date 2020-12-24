using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace userinfoApi.App_Code
{
    public class corsorigins
    {
        public string[] connectionString()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(new database().connectionSystem()).AddJsonFile("connectionApi.json");
            List<configitem> originitems = configurationBuilder.Build().Get<originString>().corsoriginStrings;
            int total = originitems.Count - 1;
            List<string> items = new List<string>();
            while (total >= 0)
            {
                items.Add(originitems[total].ipconfig);
                total--;
            }
            return items.ToArray();
        }

        public class originString
        {
            public List<configitem> corsoriginStrings { get; set; }
        }

        public class configitem
        {
            public string ipconfig { get; set; }
        }
    }
}