using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatically_place_bets.Model
{
    public class userinfo
    {
            public Timerecord timeRecord { get; set; }
            public string uid { get; set; }
            public string userName { get; set; }
            public string userKey { get; set; }
            public string lang { get; set; }
            public object lid { get; set; }
            public string groupList { get; set; }
            public string backUrl { get; set; }
            public float currencyRate { get; set; }
            public float stopBalance { get; set; }
            public string h1shidstring { get; set; }
            public string systemCode { get; set; }
            public string webId { get; set; }
            public int walletMode { get; set; }
            public string companyToken { get; set; }
            public string cadrIp { get; set; }
            public string deviceType { get; set; }
            public Deskinfo[] deskInfo { get; set; }
            public Opendesk[] openDesk { get; set; }
            public Limitbox[] limitBox { get; set; }
            public Betareamapset[] betAreaMapSet { get; set; }
            public Maintain maintain { get; set; }
            public string streamDomain { get; set; }
            public string[] engineeringModeDesk { get; set; }
            public bool isTableLock { get; set; }
            public bool canChooseVersion { get; set; }
        

        public class Timerecord
        {
            public DateTime createTime { get; set; }
            public DateTime firstLoginTime { get; set; }
            public DateTime lastLoginTime { get; set; }
        }

        public class Maintain
        {
            public Xg xg { get; set; }
            public Wm wm { get; set; }
        }

        public class Xg
        {
            public int[] weekly { get; set; }
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Wm
        {
            public int[] weekly { get; set; }
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Deskinfo
        {
            public string serverId { get; set; }
            public string name { get; set; }
            public string deskNo { get; set; }
            public int gameNo { get; set; }
            public string historyVideoUrl1 { get; set; }
            public string historyVideoUrl2 { get; set; }
            public string historyVideoUrl3 { get; set; }
        }

        public class Opendesk
        {
            public int serverNo { get; set; }
            public string serverId { get; set; }
        }

        public class Limitbox
        {
            public Item[] items { get; set; }
            public string gameId { get; set; }
        }

        public class Item
        {
            public int itemNo { get; set; }
            public int max { get; set; }
            public int min { get; set; }
            public string limitStr { get; set; }
            public int limitId { get; set; }
        }

        public class Betareamapset
        {
            public string type { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

    }
}
