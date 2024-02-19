using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatically_place_bets.Model
{
    public class RCGloginResponses
    {

       
            public int status { get; set; }
            public string desc { get; set; }
            public Result result { get; set; }
        

        public class Result
        {
            public string urlInfo { get; set; }
        }

    }
}
