using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x <= 100; x++)
            {
                Console.Write(x + " ");


                if (x % 3 == 0)
                {
                    Console.Write("Fizz");
                }

                if (x % 5 == 0)
                {
                    Console.Write("Buzz");
                }

                else if ((x % 15==0))
                {
                    Console.Write("FizzBuzz");
                }
                Console.WriteLine();
            }

            

            Console.ReadLine();

           
        }
    }
}
