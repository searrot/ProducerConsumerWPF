using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerWPF
{
    internal class Consumer
    {
        private Storage commonData;
        public Consumer(Storage commonData)
        {
            this.commonData = commonData;
        }
        public bool IsAlive { get; private set; }
        public void Start()
        {
            if (IsAlive) return;
            IsAlive = true;
            new Thread(_ =>
            {
                while (IsAlive)
                {
                    var lst = commonData.Get();
                    Thread.Sleep(2000);
                    var result = lst.Average();
                    Console.WriteLine("({0}, {1}, {2}) -> {3}", lst[0], lst[1], lst[2], result);
                }
            }).Start();
        }

        public void Stop()
        {
            IsAlive = false;
        }
    }
}
