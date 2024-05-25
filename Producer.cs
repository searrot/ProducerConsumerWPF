using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProducerConsumerWPF
{
    internal class Producer
    {
        private int id;
        private Storage commonData;
        private RectangleManager manager;
        private Random rnd;
        private string color;
        public Producer(
        int id,
        Storage commonData,
        RectangleManager manager,
        Random rand)
        {
            this.id = id;
            this.commonData = commonData;
            this.manager = manager;
            rnd = rand;
        }
        
        private bool IsAlive { get; set; }

        public void Start()
        {
            if (IsAlive) return;
            IsAlive = true;
            new Thread(_ =>
            {
                while (IsAlive)
                {
                    
                    // Эмуляция выполнения продолжительной работы:
                    Thread.Sleep(rnd.Next(5000, 8001));
                    // Получение результата:
                    //Console.WriteLine($"{id} produced: {result}");
                    var r = rnd.Next(0, 255);
                    color = Convert.ToString(r, 16);
                    if (color.Length == 1)
                    {
                        color = "0" + color;
                    }
                    switch (id)
                    {
                        case 0:
                            manager.R1 = $"#{color}0000";
                            break;
                        case 1:
                            manager.G1 = $"#00{color}00";
                            break;
                        case 2:
                            manager.B1 = $"#0000{color}";
                            break;
                        default:
                            manager.R1 = $"#000000";
                            break;
                    }
                    commonData.Put(id, r);
                }
            }).Start();
        }

        public void Stop()
        {
            IsAlive = false;
        }
    }
}
