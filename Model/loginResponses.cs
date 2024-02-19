using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatically_place_bets.Model
{
    public class loginResponses
    {
        public int status { get; set; }
        public string desc { get; set; }
        public Result result { get; set; }


        public class Result
        {
            public string token { get; set; }
            public string clubid { get; set; }
            public string clubename { get; set; }
            public string clubcname { get; set; }
            public string huilvtype { get; set; }
            public float now_xinyong { get; set; }
            public int isTest { get; set; }
            public string zuBie { get; set; }
            public bool isSocialLogin { get; set; }
            public string collet { get; set; }
            public string payment { get; set; }
            public bool collet_isEnabled { get; set; }
            public bool payment_isEnabled { get; set; }
            public int expiresAt { get; set; }
            public int mustChangePasssword { get; set; }
            public string union_id { get; set; }
            public string unitKey { get; set; }
        }

    }
}
