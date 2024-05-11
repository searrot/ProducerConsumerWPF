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
        private ObservableCollection<int> colors;
        public Producer(
        int id,
        Storage commonData,
        ObservableCollection<int> colors)
        {
            this.id = id;
            this.commonData = commonData;
            this.colors = colors;
        }

        private Random rnd = new Random();
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
                    var result = rnd.Next(1000, 2001);
                    //Console.WriteLine($"{id} produced: {result}");
                    var r = rnd.Next(200, 255);

                    colors.Add(r);
                    commonData.Put(id, result);
                }
            }).Start();
        }

        public void Stop()
        {
            IsAlive = false;
        }
    }
}
