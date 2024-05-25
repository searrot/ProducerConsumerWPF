using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerWPF
{
    internal class Storage
    {
        private List<int> _data;
        public Storage()
        {
            _data = new List<int>(3);
            for (int i = 0; i < 3; i++)
            {
                _data.Add(-1);
            }
        }


        public void Put(int index, int value)
        {
            lock (_data)
            {
                _data[index] = value;
                Monitor.PulseAll(_data);
            }
        }

        public List<int> Get()
        {
            List<int> res;
            lock (_data)
            {
                while (_data.Contains(-1))
                {
                    Monitor.Wait(_data);
                }
                res = _data.ToList();
                _data[0] = _data[1] = _data[2] = -1;
            }
            return res;
        }
    }
}
