using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CountingSort_OP.CountingSort;

namespace CountingSort_OP
{
    class MyLinkedList : DataList
    {
        class Node
        {
            public Node nextNode { get; set; }
            public int data { get; set; }

            public Node(int data, Node next)
            {
                this.data = data;
                this.nextNode = next;
            }
        }

        Node headNode;
        Node prevNode;
        Node currentNode;

        public MyLinkedList()
        {
            headNode = null;
            prevNode = null;
            currentNode = null;
        }

        public MyLinkedList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);

            headNode = new Node(rand.Next(0, 10), null);
            currentNode = headNode;

            for(int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new Node(rand.Next(0, 10), null);
                currentNode = currentNode.nextNode;
            }
        }

        public MyLinkedList(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                this.Put(data[i]);
            }
        }

        public override void Put(int data)
        {
            Node temp = new Node(data, null);

            if(headNode == null)
            {
                headNode = temp;
                currentNode = headNode;
            }
            else
            {
                currentNode.nextNode = temp;
                currentNode = temp;
            }

            length++;
        }

        public override void ChangeData(int data)
        {
            if (currentNode == null)
                return;

            currentNode.data = data;
        }

        /// <summary>
        /// Finds min value
        /// </summary>
        /// <returns>Min value</returns>
        public override int Min()
        {
            int minValue = headNode.data;
            for(Node i = headNode.nextNode; i != null; i = i.nextNode)
            {
                if(i.data < minValue)
                    minValue = i.data;
            }

            return minValue;
        }

        /// <summary>
        /// Finds max value
        /// </summary>
        /// <returns>Max value</returns>
        public override int Max()
        {
            int maxValue = headNode.data;
            for (Node i = headNode.nextNode; i != null; i = i.nextNode)
            {
                if (i.data > maxValue)
                    maxValue = i.data;
            }

            return maxValue;
        }

        public override int Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }

        public override bool NotNull()
        {
            return currentNode != null;
        }

        public override int Next()
        {
            prevNode = currentNode;
            if (currentNode.nextNode == null)
            {
                currentNode = null;
                return 0;
            }

            currentNode = currentNode.nextNode;
            return currentNode.data;
        }

        public override int Current()
        {
            return currentNode.data;
        }

        public override void Swap(int a, int b)
        {
            prevNode.data = a;
            currentNode.data = b;
        }
    }
}
