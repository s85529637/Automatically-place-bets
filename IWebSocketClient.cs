public interface IWebSocketClient
{
    Task ConnectAsync(string uri,string token);
}
