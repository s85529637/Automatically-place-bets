using Automatically_place_bets;
using Automatically_place_bets.Model;
using Newtonsoft.Json;

var post = new Post();

var get = new GET();
///H1Login
Dictionary<string, string> Logindata = new Dictionary<string, string>
{
    { "account", "datw03" },
    { "password", "cf79ae6addba60ad018347359bd144d2" },
    { "uidKey","web"}
};
var loginjson = JsonConvert.SerializeObject(Logindata);
var login =await post.PostWithHeadersAsync("https://pwaapi.bacctest.com/api/Member/Login", loginjson, new Dictionary<string, string>{});

var loginResponse = JsonConvert.DeserializeObject<loginResponses>(login);
//var b = await get.GetSendAsync("https://dd.bacc55.com/Api/login?Token=73BBE298-5478-4F37-B84E-EC7ACBD3D3E8&backurl=https://ts.bacctest.com/close&lang=zh-TW&Logo=H1&clubType=classicBacc");

///RcgLogin
Dictionary<string, string> Rcgdata = new Dictionary<string, string>
{
    { "device", "DESKTOP" },
    { "lang", "zh-tw" },
    { "lobbyURL", "https://ts.bacctest.com/close" },
    { "Desk","baccarat"}
};

Dictionary<string, string> headers = new Dictionary<string, string>
{
    { "Authorization", "Bearer " + loginResponse.result.token}
};
var Rcgjson = JsonConvert.SerializeObject(Rcgdata);

var RCG =await post.PostWithHeadersAsync("https://pwaapi.bacctest.com/api/Game/GetGameToken/W1RCGv2", Rcgjson, headers);
var rcgResponse = JsonConvert.DeserializeObject<RCGloginResponses>(RCG);

await post.PostWithHeadersAsync("https://pwaapi.bacctest.com/api/Game/GetGameToken/W1RCGv2", Rcgjson, headers);
///進桌
//Redirect
var redirect =await get.GetSendAsync(rcgResponse.result.urlInfo);
Console.WriteLine(redirect);
