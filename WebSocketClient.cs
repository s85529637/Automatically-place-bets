using Automatically_place_bets.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text;
using Websocket.Client;

public class WebSocketClient : IWebSocketClient
{
    public async Task ConnectAsync(string uri, string LoginData)
    {
        var exitEvent = new ManualResetEvent(false);

        var client = new WebsocketClient(new Uri(uri));
        client.ReconnectTimeout = TimeSpan.FromSeconds(30);
        client.ReconnectionHappened.Subscribe(info =>
            Log.Information($"Reconnection happened, type: {info.Type}"));
        var intable = new Dictionary<string, string>
        {
            {"C","1000" },
            {"LoginData",LoginData},
            {"SI","GCBC20201102" },
        };
        client.Send(JsonConvert.SerializeObject(intable));


        var takslist = new List<Task>();
        client.MessageReceived.Select(msg => Observable.FromAsync(async () =>
             {
                 if (!string.IsNullOrEmpty(msg.Text))
                 {
                     //Console.WriteLine(msg.Text);
                     MyQueue.queue.Enqueue(msg.Text);
                 }

                 await Task.Delay(500);
                 return Task.CompletedTask;
             })).Concat().Subscribe();


        takslist.Add(client.Start());

        //¤ß¸õ
        var heartbeatmessage = new Dictionary<string, string>
                {
                    {"C","1003" },
                    {"SI","9999" },
                };
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        Task heartbeat = Task.Run(async () =>
        {

            while (!token.IsCancellationRequested)
            {
                client.Send(JsonConvert.SerializeObject(heartbeatmessage));
                await Task.Delay(TimeSpan.FromSeconds(5), token);
            }
        }, token
        );


        takslist.Add(heartbeat);
        await Task.WhenAll(takslist);

    }

    

}
