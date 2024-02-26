using Automatically_place_bets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Automatically_place_bets
{
    public class Dataprocessing
    {
        public async void DataProcessing()
        {
            while (true)
            {
                string data = null;
                if (MyQueue.queue.TryDequeue(out data))
                {
                    Console.WriteLine(data);

                    if (data.Contains("\"C\":401", StringComparison.OrdinalIgnoreCase))
                    {

                    }
                }
                else
                {
                    // 隊列是空的
                    Console.WriteLine("The queue is empty.");
                    await Task.Delay(5000);
                }

            }
        }

    }
}



