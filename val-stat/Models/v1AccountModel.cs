using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using val_stat.Models;

namespace val_stat.Models
{
    class v1AccountModel
    {
        public string connection = "https://api.henrikdev.xyz/valorant/v1/account/A%20Little%20Death/nbhd?api_key=" + apiKeyVariable.apiKey;
        public class Card
        {
            public string small { get; set; }
            public string large { get; set; }
            public string wide { get; set; }
            public string id { get; set; }
        }

        public class Data
        {
            public string puuid { get; set; }
            public string region { get; set; }
            public int account_level { get; set; }
            public string name { get; set; }
            public string tag { get; set; }
            public Card card { get; set; }
            public string last_update { get; set; }
            public int last_update_raw { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public Data data { get; set; }
        }

    }
}
