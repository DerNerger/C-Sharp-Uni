using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class CompareableInteger : IComparable
    {
        public int value
        {
            get;
            set;
        }

        public CompareableInteger(int value)
        {
            this.value = value;
        }

        int IComparable.CompareTo(Object o)
        {
            CompareableInteger cInt = (CompareableInteger)o;
            if (this.value == cInt.value)
                return 0;
            if (this.value < cInt.value)
                return -1;
            else
                return 1;
        }

        public override String ToString() 
        {
            return value.ToString();
        }

    }
}
