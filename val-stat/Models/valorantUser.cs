using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace val_stat.Models
{
    class valorantUser
    {
        public static bool login_auth {  get; set; }
        public static string usr_Name { get; set; }
        public static string usr_Tag { get; set; }
        public static string usr_rank { get; set; }
        public static int usr_level { get; set; }
        public static string usr_region { get; set; }
        public static bool is_usrHasProfilePicture { get; set; }    
        public static string usr_card_s { get; set; }
        public static string usr_card_l { get; set; }
        public static string usr_card_w { get; set; }
        public static string usr_rankImage_url { get; set; }   
    }
}
