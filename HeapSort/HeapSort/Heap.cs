using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    public class Heap
    {
        public IComparable[] heap
        {
            get;
            set;
        }

        public Heap(IComparable[] heap) 
        {
            this.heap = heap;
            for (int i = (heap.Length / 2) - 1; i >= 0; --i)
            {
                DownHeap(i);
            }
            showHeap();
        }

        public void heapSort() 
        {
            int k = heap.Length - 1;
            do
            {
                IComparable t = heap[0];
                heap[0] = heap[k];
                heap[k] = t; 
                k = k - 1;
                showHeap();
                ReHeap(0, k);
                showHeap();
            } while (k >= 0);
        }


        private void ReHeap(int i, int size) 
        {
            int j;
            IComparable v;
            v = heap[i];
            while (true)
            {
                if (i < (size + 1) / 2)
                {
                    j = 2 * i + 1;
                    bool leftKleinerRight;
                    if (heap[j].CompareTo(heap[j + 1]) < 0)
                        leftKleinerRight = true;
                    else
                        leftKleinerRight = false;
                    if ((j < size) && (leftKleinerRight))
                        j = j + 1;

                    bool parentKleinerChild;
                    if (heap[j].CompareTo(v) > 0)
                        parentKleinerChild = false;
                    else
                        parentKleinerChild = true;

                    if (parentKleinerChild) break;
                    heap[i] = heap[j];
                    i = j;
                }
                else break;
            }
            heap[i] = v; 
        }

        private void DownHeap(int i) {
            int j;
            IComparable v;
            v = heap[i]; 
            while (true) {
                if (i < heap.Length/2) {
            j = 2*i+1;
            bool leftKleinerRight;
            if (heap[j].CompareTo(heap[j + 1]) < 0)
                leftKleinerRight = true;
            else
                leftKleinerRight = false;
            if ((j<heap.Length-1) && (leftKleinerRight)) 
                j=j+1;

            bool parentKleinerChild;
            if (heap[j].CompareTo(v) > 0)
                parentKleinerChild = false;
            else
                parentKleinerChild = true;

            if (parentKleinerChild) break; 
            heap[i]=heap[j]; 
              i=j; 
             } else break; 
            }
            heap[i] = v; 
        }

        public void showHeap() 
        {
            for (int i = 0; i < heap.Length; i++)
            {
                Console.Write(heap[i].ToString() + "  ");
            }
            Console.WriteLine();
        }

    }
}
