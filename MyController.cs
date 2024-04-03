using Automatically_place_bets.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatically_place_bets
{
    public class MyController
    {

        private IWebSocketClient webSocketClient;
        public MyController(IWebSocketClient webSocketClient)
        {
            this.webSocketClient = webSocketClient;
        }
        public async Task Action()
        {
            try
            {
                var post = new Post();

                var get = new GET();


                var takslist = new List<Task>();
                ////寫入資料
                //Task webSocketwrite = Task.Run(() => webSocketClient.ConnectAsync("wss://gs.bacc55.com/doubledragon/eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJDb21wYW55Q29kZSI6IkgxUm95YWxUcmFuc2ZlciIsIlN5c3RlbUNvZGUiOiJIMVN5c3RlbSIsIldlYklkIjoiSDFXZWIiLCJXYWxsZXRNb2RlIjoiNSIsIkNvbXBhbnlUb2tlbiI6IjU3YzJhMzgyLTAyYzUtNDlhOC05ZThhLTNiOGYwYjE3YWExMCIsIklkIjoiMjI4OTYwIiwiVWlkIjoiMjAwNTE2MTc3NiIsIlVzZXJOYW1lIjoiRGF0dzAzIiwiVXNlcktleSI6IjBlZGVlYTJhLWZhZTYtNDM5NC05NGFlLTliNGExODE3MzQyYiIsIkxhbmciOiJ6aC1UVyIsIkdyb3VwTGlzdCI6IiIsIkRldmljZVR5cGUiOiJXZWIiLCJJUCI6IjM0LjEyNi43Ni4xODMiLCJMb2dpblRva2VuIjoiYjkzNWUwZWQtNGJkMi00YTkwLTk1OWUtZmIzMWFiYzZlYTUxIiwiT3BlblNlcnZlcklkIjoiMTUxMDEsMTEwMSwxMTAyLDExMDMsMTEwNCwxMTA1LDExMDYsMTEwNywxMTA4LDQxMDEsNDEwMiw0MTAzLDQxMDQsMTExMSwxMTA5LDExMTAsNDExMyw0MTE0LDQxMTUsNDExNiw0MTE3LDQxMTgsNDMwMiw0MzAzLDQzMDQsNDMwNSwxMTE1LDExMTYsMTExNywxMTE4LDExMTksMjEwMSwyMTAyLDIxMDMsMjEwNCwzMTAxLDMxMDIsMzEwMywzMTA0LDMxMDUsMzEwNiwzMTA3LDMxMDgsNDEwNyw0MTA4LDQxMDksNDExMCw0MTExLDQxMTIsNDEwNSw0MTA2LDQzMDYsNDMwNyw0MzA4LDQzMDksOTQwMSw5NDAyLDk0MDMsOTQwNCw5NDA1LDk0MDYsOTQwNyw5NDA4LDk1MDEsOTUwMiwxODAwMSw4MTAxLDUwMDEsMTUwMSwwLDAsMTcwMDEsMTYwMSwzNjAxLDIwMDEsMjAwMiwxMjAxLDEyMDIsMTIwMywyMjAxLDIyMDIsMjIwMyw0MjAxLDQyMDIsMzIwMSwzMjAyLDMwMDEsMzAwMiwxMzAxLDEzMDIsMjMwMSwzMzAxLDMzMDIsMjcwMSwxNzAxLDQwLDQzLDkxMDEsMTYxMDEsNDAwMSw0MDAyLDE0MDEsMTQwMiwyNDAiLCJDdXJyZW5jeSI6IlRIQiIsIkNyZWF0ZVRpbWUiOiIyMDIyLTAzLTA5VDE0OjE4OjU3IiwiRmlyc3RMb2dpblRpbWUiOiIyMDIyLTA0LTIwVDEzOjI0OjAzIiwiTGFzdExvZ2luVGltZSI6IjIwMjQtMDItMTlUMTU6MzI6NTgiLCJDdXJyZW5jeVJhdGUiOiIxLjExMTAiLCJIMXNoaWRzdHJpbmciOiIiLCJCYWNrVXJsIjoiaHR0cHM6Ly90cy5iYWNjdGVzdC5jb20vY2xvc2UiLCJleHAiOjE3MDgzMjg4MTgsImlzcyI6IkxvYmJ5V2ViU2l0ZSJ9.V2hbGKSSBtjZnlXbEuMnr7LdLbF_yZFnRfp1KpvzoOk", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJDb21wYW55Q29kZSI6IkgxUm95YWxUcmFuc2ZlciIsIlN5c3RlbUNvZGUiOiJIMVN5c3RlbSIsIldlYklkIjoiSDFXZWIiLCJXYWxsZXRNb2RlIjoiNSIsIkNvbXBhbnlUb2tlbiI6IjU3YzJhMzgyLTAyYzUtNDlhOC05ZThhLTNiOGYwYjE3YWExMCIsIklkIjoiMjI4OTYwIiwiVWlkIjoiMjAwNTE2MTc3NiIsIlVzZXJOYW1lIjoiRGF0dzAzIiwiVXNlcktleSI6IjBlZGVlYTJhLWZhZTYtNDM5NC05NGFlLTliNGExODE3MzQyYiIsIkxhbmciOiJ6aC1UVyIsIkdyb3VwTGlzdCI6IiIsIkRldmljZVR5cGUiOiJXZWIiLCJJUCI6IjM0LjEyNi43Ni4xODMiLCJMb2dpblRva2VuIjoiYjkzNWUwZWQtNGJkMi00YTkwLTk1OWUtZmIzMWFiYzZlYTUxIiwiT3BlblNlcnZlcklkIjoiMTUxMDEsMTEwMSwxMTAyLDExMDMsMTEwNCwxMTA1LDExMDYsMTEwNywxMTA4LDQxMDEsNDEwMiw0MTAzLDQxMDQsMTExMSwxMTA5LDExMTAsNDExMyw0MTE0LDQxMTUsNDExNiw0MTE3LDQxMTgsNDMwMiw0MzAzLDQzMDQsNDMwNSwxMTE1LDExMTYsMTExNywxMTE4LDExMTksMjEwMSwyMTAyLDIxMDMsMjEwNCwzMTAxLDMxMDIsMzEwMywzMTA0LDMxMDUsMzEwNiwzMTA3LDMxMDgsNDEwNyw0MTA4LDQxMDksNDExMCw0MTExLDQxMTIsNDEwNSw0MTA2LDQzMDYsNDMwNyw0MzA4LDQzMDksOTQwMSw5NDAyLDk0MDMsOTQwNCw5NDA1LDk0MDYsOTQwNyw5NDA4LDk1MDEsOTUwMiwxODAwMSw4MTAxLDUwMDEsMTUwMSwwLDAsMTcwMDEsMTYwMSwzNjAxLDIwMDEsMjAwMiwxMjAxLDEyMDIsMTIwMywyMjAxLDIyMDIsMjIwMyw0MjAxLDQyMDIsMzIwMSwzMjAyLDMwMDEsMzAwMiwxMzAxLDEzMDIsMjMwMSwzMzAxLDMzMDIsMjcwMSwxNzAxLDQwLDQzLDkxMDEsMTYxMDEsNDAwMSw0MDAyLDE0MDEsMTQwMiwyNDAiLCJDdXJyZW5jeSI6IlRIQiIsIkNyZWF0ZVRpbWUiOiIyMDIyLTAzLTA5VDE0OjE4OjU3IiwiRmlyc3RMb2dpblRpbWUiOiIyMDIyLTA0LTIwVDEzOjI0OjAzIiwiTGFzdExvZ2luVGltZSI6IjIwMjQtMDItMTlUMTU6MzI6NTgiLCJDdXJyZW5jeVJhdGUiOiIxLjExMTAiLCJIMXNoaWRzdHJpbmciOiIiLCJCYWNrVXJsIjoiaHR0cHM6Ly90cy5iYWNjdGVzdC5jb20vY2xvc2UiLCJleHAiOjE3MDgzMjg4MTgsImlzcyI6IkxvYmJ5V2ViU2l0ZSJ9.V2hbGKSSBtjZnlXbEuMnr7LdLbF_yZFnRfp1KpvzoOk"));
                //takslist.Add(webSocketwrite);
                ////處理資料
                //Dataprocessing dataprocessing = new Dataprocessing();
                //Task dataProcessing = Task.Run(() => dataprocessing.DataProcessing());


                //await Task.WhenAll(takslist);


                ///H1Login
                Dictionary<string, string> Logindata = new Dictionary<string, string>
                {
                    { "account", "datw03" },
                    { "password", "cf79ae6addba60ad018347359bd144d2" },
                    { "uidKey","web"}
                };
                var loginjson = JsonConvert.SerializeObject(Logindata);
                var login = await post.PostWithHeadersAsync("https://pwaapi.bacctest.com/api/Member/Login", loginjson, new Dictionary<string, string> { });

                var loginResponse = JsonConvert.DeserializeObject<loginResponses>(login);
                //var b = await get.GetSendAsync("https://dd.bacc55.com/Api/login?Token=73BBE298-5478-4F37-B84E-EC7ACBD3D3E8&backurl=https://ts.bacctest.com/close&lang=zh-TW&Logo=H1&clubType=classicBacc");

                ///RcgLogin
                Dictionary<string, string> Rcgdata = new Dictionary<string, string>
                {
                    { "device", "DESKTOP" },
                    { "lang", "zh-tw" },
                    { "lobbyURL", "https://ts.bacctest.com/close" },
                    { "deskid","1201"},
                };

                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + loginResponse.result.token}
                };
                var Rcgjson = JsonConvert.SerializeObject(Rcgdata);

                var RCG = await post.PostWithHeadersAsync("https://pwaapi.bacctest.com/api/Game/GetGameToken/W1RCGv2", Rcgjson, headers);
                var rcgResponse = JsonConvert.DeserializeObject<RCGloginResponses>(RCG);


                //取的RCG Token
                var redirect = await get.GetSendAsync(rcgResponse.result.urlInfo);
                var Token = redirect.Split("token=")[1].Split("&")[0];


                //userinfo
                Dictionary<string, string> Getheaders = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + Token},
                    {"Referer","https://dd.bacc55.com/api/UserInfo"}
                };
                var userinfo = await get.GetAsync("https://dd.bacc55.com/api/UserInfo", Getheaders);

                var userinfoResponse = JsonConvert.DeserializeObject<userinfo>(userinfo);

                /////進桌
                ////Redirect

                //await webSocketClient.ConnectAsync("wss://gs.bacc55.com/doubledragon/"+ Token,Token);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
