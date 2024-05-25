using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProducerConsumerWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

           
            RectangleManager manager = new RectangleManager();

            this.DataContext = manager;

            Random rnd1 = new Random(1000);
            Random rnd2 = new Random(2000);
            Random rnd3 = new Random(3500);
            Storage data = new Storage();
            var producers = new List<Producer> { new Producer(0, data, manager, rnd2), new Producer(1, data, manager, rnd1), new Producer(2, data, manager, rnd3) };
            Random rnd = new Random();
            producers[0].Start();
            producers[1].Start();
            producers[2].Start();
            var consumer = new Consumer(data, manager);
            consumer.Start();
        }
       
    }

   

}
