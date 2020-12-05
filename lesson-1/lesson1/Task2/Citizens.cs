using System;
using System.Collections;

namespace Task2
{
    class Citizens : IEnumerable
    {
        private Citizen[] _citizens;
        public Citizens()
        {
            _citizens = new Citizen[0];
        }
        public int Count
        {
            get => _citizens.Length;            
        }
        public bool Contains(Citizen item, out int index)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_citizens[i].Equals(item))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        public int Add(Citizen element)
        {
            int index;
            if (Contains(element, out index))
            {
                return index;
            }

            var arrayTemp = new Citizen[_citizens.Length + 1];

            if (element as Pensioner == null)
            {
                _citizens.CopyTo(arrayTemp, 0);
                arrayTemp[arrayTemp.Length - 1] = element;
                index = arrayTemp.Length - 1;
            }
            else
            {
                int indexAfter = FindIndexAfterPensioner();
                Array.ConstrainedCopy(_citizens, 0, arrayTemp, 0, indexAfter);
                arrayTemp[indexAfter] = element;
                Array.ConstrainedCopy(_citizens, indexAfter, arrayTemp, indexAfter + 1, _citizens.Length - indexAfter);
                index = indexAfter;
            }
            _citizens = arrayTemp;
            return index;
        }
        public void Remove()
        {
            var arrayTemp = new Citizen[_citizens.Length - 1];
            Array.ConstrainedCopy(_citizens, 1, arrayTemp, 0, arrayTemp.Length);
            _citizens = arrayTemp;
        }
        public void Remove(Citizen element)
        {
            int index;
            if (Contains(element, out index))
            {
                var arrayTemp = new Citizen[_citizens.Length - 1];
                Array.ConstrainedCopy(_citizens, 0, arrayTemp, 0, index);
                Array.ConstrainedCopy(_citizens, index + 1, arrayTemp, index, arrayTemp.Length - index);
                _citizens = arrayTemp;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return _citizens.GetEnumerator();
        }
        private int FindIndexAfterPensioner()
        {
            int index = 0;

            while ((_citizens.Length > index && _citizens[index] as Pensioner != null))
            {
                index++;
            }
            return index;
        }
        public Citizen ReturnLast(out int index)
        {
            index = _citizens.Length - 1;
            return _citizens[_citizens.Length - 1];
        }
        public void Clear()
        {
            if (Count > 0)
            {
                _citizens = new Citizen[0];                            
            }            
        }
    }
}
