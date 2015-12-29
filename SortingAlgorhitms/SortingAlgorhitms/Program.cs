using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortingAlgorhitms
{
    class Program
    {
        static void Main(string[] args)
        {
            Algorhitm alg = new Algorhitm();
            List<int> list = new List<int>() { 5, 9, 2, 7, 1 };
            Dictionary<string, long> algorhitmsRT = new Dictionary<string, long>();

            Console.WriteLine("Unordered List:");
            long elapsedTimeMs;
            Print(list);

            //Bubble Sort
            Console.WriteLine("");
            Console.WriteLine("Ordered List with BubbleSort:");
            Print(alg.BubbleSort(new int[] { 5, 9, 2, 7, 1 }, out elapsedTimeMs));
            Console.WriteLine("");
            Console.WriteLine("Bubble Sort Running time in MS: " + elapsedTimeMs);

            algorhitmsRT["BubbleSort"] = elapsedTimeMs;

            //Insertion Sort
            Console.WriteLine("");
            Console.WriteLine("Ordered List with Insertion Sort:");
            Print(alg.InsertionSort(new int[] { 5, 9, 2, 7, 1 }, out elapsedTimeMs));
            Console.WriteLine("");
            Console.WriteLine("Insertion Sort Running time in MS: " + elapsedTimeMs);

            algorhitmsRT["InsertionSort"] = elapsedTimeMs;

            Console.ReadKey();
        }

        public static void Print(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }



    class Algorhitm
    {

        /*******************************************
        How "Bubble Sort" algorithm is working - Best O(n), Average O(n^2), Worst O(n^2)
            
            for i = (n-1) to 1
                for j = 0 to (i-1)
                    if(A[j] > A[j+1])
                        Swap(A[i],A[i+1]) 
         ******************************************/


        public int[] BubbleSort(int[] list, out long elapsedTimeMs)
        {
            var watch = Stopwatch.StartNew();

            //Core algorhitm
            for (int i = list.Length - 1; i > 0; --i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(ref list[j], ref list[j + 1]);
                    }
                }
            }
            //

            watch.Stop();
            elapsedTimeMs = watch.ElapsedTicks;
            return list;
        }

        /*******************************************
        How "Insertion Sort" algorithm is working - Best O(n), Average O(n^2), Worst O(n^2)
            
            for i = 1 to (n-1)
                j = i
                    while(j > 0 && A[j] < A[j-1])
                        Swap(A[j],A[j-1])
                        --j 
         ******************************************/
        public int[] InsertionSort(int[] list, out long elapsedTimeMs)
        {
            var watch = Stopwatch.StartNew();

            //Core algorhitm
            for (int i = 1; i < list.Length; i++)
            {
                int j = i;
                while (j > 0 && list[j] < list[j - 1])
                {
                    Swap(ref list[j], ref list[j - 1]);
                    --j;
                }
            }
            //
            watch.Stop();
            elapsedTimeMs = watch.ElapsedTicks;
            return list;
        }


        /*******************************************
        How "Merge Sort" algorithm is working - Best O(n log n), Average O(n log n), Worst O(n log n)
            
         ******************************************/
        public int[] MergeSort(int[] list, out long elapsedTimeMs)
        {
            var watch = Stopwatch.StartNew();

            //Core algorhitm

            //
            watch.Stop();
            elapsedTimeMs = watch.ElapsedTicks;
            return list;
        }

        public int[] QuickSort(int[] list, out long elapsedTimeMs)
        {
            var watch = Stopwatch.StartNew();

            //Core algorhitm

            //
            watch.Stop();
            elapsedTimeMs = watch.ElapsedTicks;
            return list;
        }

        private void Swap(ref int x, ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }
    }
}


