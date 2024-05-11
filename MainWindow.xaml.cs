using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            var RColors = new ObservableCollection<int>();
            RColors.CollectionChanged += RColors_CollectionChanged;
            Storage data = new Storage();
            var producers = new List<Producer> { new Producer(0, data, RColors), new Producer(1, data, RColors), new Producer(2, data, RColors) };
            producers.ForEach(p => p.Start());
        }
        void RColors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is int newColor)
                        Console.WriteLine($"Добавлен новый объект: {newColor}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is int oldColor)
                        Console.WriteLine($"Удален объект: {oldColor}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if ((e.NewItems?[0] is int replacingColor) &&
                        (e.OldItems?[0] is int replacedColor))
                        Console.WriteLine($"Объект {replacedColor} заменен объектом {replacingColor}");
                    break;
            }
        }
    }
}
