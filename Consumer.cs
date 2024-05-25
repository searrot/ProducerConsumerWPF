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
        private RectangleManager manager;
        public Consumer(Storage commonData, RectangleManager manager)
        {
            this.commonData = commonData;
            this.manager = manager;

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
                    var rColor = Convert.ToString(lst[0], 16);
                    if (rColor.Length == 1)
                    {
                        rColor = "0" + rColor;
                    }
                    var bColor = Convert.ToString(lst[2], 16);
                    if (bColor.Length == 1)
                    {
                        bColor = "0" + bColor;
                    }
                    var gColor = Convert.ToString(lst[1], 16);
                    if (gColor.Length == 1)
                    {
                        gColor = "0" + gColor;
                    }
                    string finalColor = "#"+rColor+gColor+bColor;
                    manager.PROD = finalColor;
                    Console.WriteLine("({0}, {1}, {2}) -> {3}", lst[0], lst[1], lst[2], finalColor);
                }
            }).Start();
        }

        public void Stop()
        {
            IsAlive = false;
        }
    }
}
