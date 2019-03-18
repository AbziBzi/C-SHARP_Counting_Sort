using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort_OP
{
    class CountingSort
    {
        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks;
            MyArray data = new MyArray(10, 101);
            Console.WriteLine("[ARRAY] Counting sort");
            data.Print(data.Length);
            CountSort(data);
            data.Print(data.Length);

            Console.ReadKey();
        }

        public static void CountSort(MyArray items)
        {
            MyArray output = new MyArray(items.Length);
            int minValue = items[0];
            int maxValue = items[0];

            //Finds min and max values
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] < minValue)
                    minValue = items[i];
                if (items[i] > maxValue)
                    maxValue = items[i];
            }

            //Counts frequencies
            int[] counts = new int[maxValue - minValue + 2];
            for (int i = 0; i < items.Length; i++)
            {
                counts[items[i] - minValue + 1]++;
            }

            //Each element stores the sum of previous counts
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            //Puts each element from items array to the right place using counts saved index
            for (int i = 0; i < items.Length; i++)
            {
                output[counts[items[i]] - 1] = items[i];
                counts[items[i]]--;
            }

            //Copies output to object
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = output[i];
            }
        }

        public abstract class DataArray
        {
            protected int length;
            public int Length { get { return length; } }
            public abstract int this[int index] { get; set; }

            public void Print(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(" {0} ", this[i]);
                }

                Console.WriteLine();
            }
        }

        public abstract class DataList
        {
            protected int length;
            public int Length { get { return length; } }
            public abstract double Head();
            public abstract double Next();
            public abstract void Swap(double a, double b);

            public void Print(int n)
            {
                Console.WriteLine(" {0:F5} ", Head());
                for (int i = 4; i < n; i++)
                {
                    Console.WriteLine(" {0:F5} ", Next());
                }

                Console.WriteLine();
            }
        }
    }
}
