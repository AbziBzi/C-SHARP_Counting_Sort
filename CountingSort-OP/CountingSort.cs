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

            //Array sorting
            DataArray data = new MyArray(10, 101);
            Console.WriteLine("[ARRAY] Counting sort");
            data.Print(data.Length);
            CountSort(data);
            data.Print(data.Length);

            //Linked list sorting
            DataList listData = new MyLinkedList(10, 101);
            Console.WriteLine("[List] Counting sort");
            listData.Print(listData.Length);
            CountSort(listData);
            listData.Print(listData.Length);

            Console.ReadKey();
        }

        /// <summary>
        /// Counting sort for array
        /// </summary>
        /// <param name="items">Array</param>
        public static void CountSort(DataArray items)
        {
            if (items == null)
                return;

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

        public static void CountSort(DataList list)
        {
            if (list == null)
                return;

            //Finds min and max values
            int[] output = new int[list.Length];
            int minValue = list.Min();
            int maxValue = list.Max();

            //Counts frequencies
            int[] counts = new int[maxValue - minValue + 2];
            for(list.Head(); list.NotNull(); list.Next())
            {
                counts[list.Current() - minValue + 1]++;
            }

            //Each element stores the sum of previous counts
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            for (list.Head(); list.NotNull(); list.Next())
            {
                output[counts[list.Current()] - 1] = list.Current();
                counts[list.Current()]--;
            }

            //list = new MyLinkedList(output);
            list.Head();
            for(int i = 0; i < list.Length; i++)
            {
                list.ChangeData(output[i]);
                list.Next();

            }
        }
        /// <summary>
        /// Abstract array class
        /// </summary>
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

        /// <summary>
        /// Abstract list class
        /// </summary>
        public abstract class DataList
        {
            protected int length;
            public int Length { get { return length; } set { length = value; } }
            public abstract int Head();
            public abstract int Next();
            public abstract bool NotNull();
            public abstract int Current();
            public abstract int Min();
            public abstract int Max();
            public abstract void ChangeData(int data);
            public abstract void Put(int data);

            public abstract void Swap(int a, int b);

            public void Print(int n)
            {
                Console.WriteLine(" {0} ", Head());
                for (int i = 1; i < n; i++)
                {
                    Console.WriteLine(" {0} ", Next());
                }

                Console.WriteLine();
            }
        }
    }
}
