using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace FilterMedian
{
    public class FilterMedian<T> where T : IComparable<T>, new()
    {
        private int _size = 5;
        private CircularBuffer<T> _data;
        private int _middle = 0;
        private Dictionary<int, T> _dataSorted;

        public FilterMedian(int size = 5)
        {
            _size = size;
            _middle = Convert.ToInt32(_size / 2);

            _data = new CircularBuffer<T>(_size);
            _dataSorted = new Dictionary<int, T>();
        }

        public void Add(T v)
        {
            _data.Enqueue(v);

            // Copy to array
            Dictionary<int, T>_dataUnSorted = new Dictionary<int, T>();
            int pos = 0;
            foreach (T curV in _data)
            {
                _dataUnSorted[pos] = curV;
                pos++;
            }

            // Sort array
            IEnumerable<KeyValuePair<int, T>> localDict = from entry in _dataUnSorted orderby entry.Value ascending select entry;
            Dictionary<int, T> localDictSorted = localDict.ToDictionary(pair => pair.Key, pair => pair.Value);
            // Debug.WriteLine("localDictSorted");
            // DebugPrint(localDictSorted);

            pos = 0;
            _dataSorted.Clear();
            foreach (var entry in localDictSorted)
            {
                _dataSorted.Add(pos, entry.Value);
                pos++;
            }
            // Debug.WriteLine("_dataSorted");
            // DebugPrint(_dataSorted);
        }

        public T GetMedian()
        {
            T result = new T();

            if (_dataSorted.Count >= _middle)
            {
                result = _dataSorted[_middle];
            }

            return result;
        }

        public void DebugPrint(Dictionary<int, T> dict)
        {
            foreach (var v in dict)
            {
                Debug.Write(string.Format(" {0:0.0000}", v));
            }
            
            Debug.WriteLine("");
        }
    }
}
