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
            int i  = 0, total = originitems.Count;
            string[] items = new string[total];
            while (i < total)
            {
                items[i] = originitems[i].ipconfig;
                i++;
            }
            return items;
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