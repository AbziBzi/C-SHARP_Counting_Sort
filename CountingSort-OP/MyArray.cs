using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CountingSort_OP.CountingSort;

namespace CountingSort_OP
{
    class MyArray : DataArray
    {
        int[] data;

        public MyArray(int n)
        {
            data = new int[n];
        }

        public MyArray(int n, int seed)
        {
            data = new int[n];
            length = n;

            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = rand.Next(0, 10);
            }
        }

        public MyArray(MyArray array)
        {
            for(int i = 0; i < array.length; i++)
            {
                data[i] = array.length;
            }
        }

        public override int this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
    }
}
