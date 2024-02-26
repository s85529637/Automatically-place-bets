using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatically_place_bets.Model
{
    public static class MyQueue
    {
        public static ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
    }
}

