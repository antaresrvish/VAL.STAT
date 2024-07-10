using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace val_stat.Models
{
    class v2MMRModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class ActRankWin
        {
            public string patched_tier { get; set; }
            public int tier { get; set; }
        }

        public class BySeason
        {
            public E1a1 e1a1 { get; set; }
            public E1a2 e1a2 { get; set; }
            public E1a3 e1a3 { get; set; }
            public E2a1 e2a1 { get; set; }
            public E2a2 e2a2 { get; set; }
            public E2a3 e2a3 { get; set; }
            public E3a1 e3a1 { get; set; }
            public E3a2 e3a2 { get; set; }
            public E3a3 e3a3 { get; set; }
            public E4a1 e4a1 { get; set; }
            public E4a2 e4a2 { get; set; }
            public E4a3 e4a3 { get; set; }
            public E5a1 e5a1 { get; set; }
            public E5a2 e5a2 { get; set; }
            public E5a3 e5a3 { get; set; }
            public E6a1 e6a1 { get; set; }
            public E6a2 e6a2 { get; set; }
            public E6a3 e6a3 { get; set; }
            public E7a1 e7a1 { get; set; }
            public E7a2 e7a2 { get; set; }
            public E7a3 e7a3 { get; set; }
            public E8a1 e8a1 { get; set; }
            public E8a2 e8a2 { get; set; }
            public E8a3 e8a3 { get; set; }
            public E9a1 e9a1 { get; set; }
            public E9a2 e9a2 { get; set; }
            public E9a3 e9a3 { get; set; }
        }

        public class CurrentData
        {
            public int currenttier { get; set; }
            public string currenttierpatched { get; set; }
            public Images images { get; set; }
            public int ranking_in_tier { get; set; }
            public int mmr_change_to_last_game { get; set; }
            public int elo { get; set; }
            public int games_needed_for_rating { get; set; }
            public bool old { get; set; }
        }

        public class Data
        {
            public string name { get; set; }
            public string tag { get; set; }
            public string puuid { get; set; }
            public CurrentData current_data { get; set; }
            public HighestRank highest_rank { get; set; }
            public BySeason by_season { get; set; }
        }

        public class E1a1
        {
            public string error { get; set; }
        }

        public class E1a2
        {
            public string error { get; set; }
        }

        public class E1a3
        {
            public string error { get; set; }
        }

        public class E2a1
        {
            public string error { get; set; }
        }

        public class E2a2
        {
            public string error { get; set; }
        }

        public class E2a3
        {
            public string error { get; set; }
        }

        public class E3a1
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E3a2
        {
            public string error { get; set; }
        }

        public class E3a3
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E4a1
        {
            public string error { get; set; }
        }

        public class E4a2
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E4a3
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E5a1
        {
            public string error { get; set; }
        }

        public class E5a2
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E5a3
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E6a1
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E6a2
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E6a3
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E7a1
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E7a2
        {
            public string error { get; set; }
        }

        public class E7a3
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E8a1
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E8a2
        {
            public string error { get; set; }
        }

        public class E8a3
        {
            public int wins { get; set; }
            public int number_of_games { get; set; }
            public int final_rank { get; set; }
            public string final_rank_patched { get; set; }
            public List<ActRankWin> act_rank_wins { get; set; }
            public bool old { get; set; }
        }

        public class E9a1
        {
            public string error { get; set; }
        }

        public class E9a2
        {
            public string error { get; set; }
        }

        public class E9a3
        {
            public string error { get; set; }
        }

        public class HighestRank
        {
            public bool old { get; set; }
            public int tier { get; set; }
            public string patched_tier { get; set; }
            public string season { get; set; }
        }

        public class Images
        {
            public string small { get; set; }
            public string large { get; set; }
            public string triangle_down { get; set; }
            public string triangle_up { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public Data data { get; set; }
        }


    }
}
