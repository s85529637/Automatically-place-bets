using Automatically_place_bets;
using Automatically_place_bets.Model;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

public class Program
{
    public static async Task Main(string[] args)
    {

        var serviceCollection = new ServiceCollection();
        // 2. 註冊服務
        serviceCollection.AddTransient<MyController>();
        serviceCollection.AddTransient<IWebSocketClient, WebSocketClient>();
        // 建立依賴服務提供者
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // 3. 執行主服務
        await serviceProvider.GetRequiredService<MyController>().Action();
    }
}






