using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProducerConsumerWPF
{
    internal class RectangleManager : INotifyPropertyChanged
    {
        private string r1;
        private string g1;
        private string b1;
        private string prod;

        public RectangleManager()
        {
            R1 = "#ffffff";
            B1 = "#ffffff";
            G1 = "#ffffff";
            PROD = "#ffffff";
        }


        public string R1
        {
            get { return r1; }
            set
            {
                r1 = value;
                OnPropertyChanged("R1");
            }
        }


        public string G1
        {
            get { return g1; }
            set
            {
                g1 = value;
                OnPropertyChanged("G1");
            }
        }



        public string B1
        {
            get { return b1; }
            set
            {
                b1 = value;
                OnPropertyChanged("B1");
            }
        }


        public string PROD
        {
            get { return prod; }
            set
            {
                prod = value;
                OnPropertyChanged("PROD");
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
