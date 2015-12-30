﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortingAlgorhitms
{
    class Program
    {
        static void Main(string[] args)
        {
            Algorhitm alg = new Algorhitm();
            int[] list = new int[] { 54, 92, 23, 71, 18, 32, 75, 31, 37, 99, 19, 0, 11, 64 };
            Dictionary<string, double> algorhitmsRT = new Dictionary<string, double>();

            Console.WriteLine("Unordered List:");
            double elapsedTimeMs;
            Print(list);

            //Bubble Sort
            Console.WriteLine("");
            Console.WriteLine("Ordered List with BubbleSort:");
            Print(alg.BubbleSort(new int[] { 54, 92, 23, 71, 18, 32, 75, 31, 37, 99, 19, 0, 11, 64 }, out elapsedTimeMs));
            Console.WriteLine("");
            Console.WriteLine("Bubble Sort Running time in MS: " + elapsedTimeMs);

            algorhitmsRT["BubbleSort"] = elapsedTimeMs;

            //Insertion Sort
            Console.WriteLine("");
            Console.WriteLine("Ordered List with Insertion Sort:");
            Print(alg.InsertionSort(new int[] { 54, 92, 23, 71, 18, 32, 75, 31, 37, 99, 19, 0, 11, 64 }, out elapsedTimeMs));
            Console.WriteLine("");
            Console.WriteLine("Insertion Sort Running time in MS: " + elapsedTimeMs);

            algorhitmsRT["InsertionSort"] = elapsedTimeMs;

            //Merge Sort
            Console.WriteLine("");
            Console.WriteLine("Ordered List with Merge Sort:");
            Print(alg.MergeSort(new int[] { 54, 92, 23, 71, 18, 32, 75, 31, 37, 99, 19, 0, 11, 64 },0,13, out elapsedTimeMs));
            Console.WriteLine("");
            Console.WriteLine("Merge Sort Running time in MS: " + elapsedTimeMs);
            algorhitmsRT["MergeSort"] = elapsedTimeMs;

            //Quick Sort
            Console.WriteLine("");
            Console.WriteLine("Ordered List with Quick Sort:");
            Print(alg.QuickSort(new int[] { 54, 92, 23, 71, 18, 32, 75, 31, 37, 99, 19, 0, 11, 64 },0,13, out elapsedTimeMs));
            Console.WriteLine("");
            Console.WriteLine("Quick Sort Running time in MS: " + elapsedTimeMs);
            algorhitmsRT["QuickSort"] = elapsedTimeMs;

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


        public int[] BubbleSort(int[] list, out double elapsedTimeMs)
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
            elapsedTimeMs = watch.Elapsed.TotalMilliseconds;
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
        public int[] InsertionSort(int[] list, out double elapsedTimeMs)
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
            elapsedTimeMs = watch.Elapsed.TotalMilliseconds;
            return list;
        }


        /*******************************************
        How "Merge Sort" algorithm is working - Best O(n log n), Average O(n log n), Worst O(n log n)
        for i = 1 ; i < n; i = 2i
            for j = 0; j < size-i; j = j+2i
                Merge(&A[j], i, min(2i,size-j))
            
         ******************************************/
        public int[] MergeSort(int[] list,int left, int right, out double elapsedTimeMs)
        {
            var watch = Stopwatch.StartNew();

            //Core algorhitm
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(list, left, mid, out elapsedTimeMs);
                MergeSort(list, (mid + 1), right, out elapsedTimeMs);

                DoMerge(list, left, (mid + 1), right);
            }
            //
            watch.Stop();
            elapsedTimeMs = watch.Elapsed.TotalMilliseconds;
            return list;
        }

        public int[] QuickSort(int[] list, int left, int right, out double elapsedTimeMs)
        {
            var watch = Stopwatch.StartNew();

            //Core algorhitm
            // For Recusrion
            if (left < right)
            {
                int pivot = Partition(list, left, right);

                if (pivot > 1)
                    QuickSort(list, left, pivot - 1, out elapsedTimeMs);

                if (pivot + 1 < right)
                    QuickSort(list, pivot + 1, right, out elapsedTimeMs);
            }
            //
            watch.Stop();
            elapsedTimeMs = watch.Elapsed.TotalMilliseconds;
            return list;
        }

        private void Swap(ref int x, ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }

        private void Swap(ref int[] x, ref int[] y)
        {
            int[] tmp = x;
            x = y;
            y = tmp;
        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                    left++;

                while (arr[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }

        }

        private void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

       

    }
}


