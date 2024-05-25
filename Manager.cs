using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProducerConsumerWPF
{
    internal class Manager : INotifyPropertyChanged
    {
        private List<int> _r;
        private List<int> _g;
        private List<int> _b;

        public Manager()
        {
            
        }


        public List<int> R
        {
            get { return _r; }
            set
            {
                _r = value;
                OnPropertyChanged("R");
            }
        }

        public List<int> G
        {
            get { return _g; }
            set
            {
                _r = value;
                OnPropertyChanged("G");
                OnPropertyChanged("G");
            }
        }

        public List<int> B
        {
            get { return _b; }
            set
            {
                _r = value;
                OnPropertyChanged("B");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
