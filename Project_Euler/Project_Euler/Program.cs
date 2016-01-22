using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            Problems problem = new Problems();
            problem.MultiplesOfXandY(3,5,1000);
            problem.FibonacciNumber(10);
            problem.LargestPrimeFactor(600851475143);
            problem.LargestPalindrome(3);
            
            //problem.Primes(13195);

            Console.ReadKey();
        }
    }
}
