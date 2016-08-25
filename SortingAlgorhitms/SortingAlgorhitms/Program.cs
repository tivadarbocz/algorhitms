using SortingAlgorhitms.SortingAlgorhitms;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortingAlgorhitms
{
    class Program
    {
        enum SortType { BubbleSort, InseretionSort, MergeSort, QuickSort, SelectionSort }
        public static int[] list = new int[] { 54, 92, 23, 71, 18, 32, 75, 31, 37, 99, 19, 0, 11, 64 };
        static void Main(string[] args)
        {
            
            Dictionary<string, double> algorhitmsRT = new Dictionary<string, double>();
            Console.WriteLine("Unordered List:");
            Print(list);
           
            SortTest(SortType.BubbleSort, algorhitmsRT);
            SortTest(SortType.MergeSort, algorhitmsRT);
            SortTest(SortType.InseretionSort, algorhitmsRT);
            SortTest(SortType.QuickSort, algorhitmsRT);
            SortTest(SortType.SelectionSort, algorhitmsRT);
            Console.ReadKey();
        }

        private static void SortTest(SortType type, Dictionary<string, double> algorhitmsRT)
        {
            Algorhitm alg = new Algorhitm();
            double elapsedTimeMs;
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Ordered List with "+type+":");
            switch (type)
            {
                case SortType.SelectionSort:
                    Print(alg.SelectionSort(list.Clone() as int[], out elapsedTimeMs));
                    break;
                case SortType.QuickSort:
                    Print(alg.QuickSort(list.Clone() as int[], 0, 13, out elapsedTimeMs));
                    break;
                case SortType.BubbleSort:
                    Print(alg.BubbleSort(list.Clone() as int[], out elapsedTimeMs));
                    break;
                case SortType.MergeSort:
                    Print(alg.MergeSort(list.Clone() as int[], 0, 13, out elapsedTimeMs));
                    break;
                case SortType.InseretionSort:
                    Print(alg.InsertionSort(list.Clone() as int[], out elapsedTimeMs));
                    break;
                default:
                    elapsedTimeMs = 0;
                    break;

            }
            Console.WriteLine("");
            Console.WriteLine(type+" Running time in MS: " + elapsedTimeMs);
            algorhitmsRT[type.ToString()] = elapsedTimeMs;
        }

        public static void Print(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}


