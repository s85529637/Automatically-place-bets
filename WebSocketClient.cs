using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text;
using Websocket.Client;

public class WebSocketClient : IWebSocketClient
{
    private ClientWebSocket webSocket = null;

    public async Task ConnectAsync(string uri)
    {
        var exitEvent = new ManualResetEvent(false);

        var client = new WebsocketClient(new Uri(uri));
        client.ReconnectTimeout = TimeSpan.FromSeconds(30);
        client.ReconnectionHappened.Subscribe(info =>
            Log.Information($"Reconnection happened, type: {info.Type}"));

        var takslist = new List<Task>();
        client.MessageReceived.Select(msg => Observable.FromAsync(async () =>
             {
                 if (!string.IsNullOrEmpty(msg.Text))
                 {
                     Console.WriteLine(msg.Text);
                 }

                 await Task.Delay(500);
                 return Task.CompletedTask;
             })).Concat().Subscribe();


        takslist.Add(client.Start());


        var message = new Dictionary<string, string>
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
                client.Send(JsonConvert.SerializeObject(message));
                await Task.Delay(TimeSpan.FromSeconds(5), token);
            }
        }, token
        );


        takslist.Add(heartbeat);
        await Task.WhenAll(takslist);

    }

    

}
