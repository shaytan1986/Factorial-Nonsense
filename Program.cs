using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Diagnostics;

namespace eCalc
{
    class Program
    {
        static float e;


        static void Main(string[] args)
        {
            double runningTotal = 2;
            double currentValue = 1;
            double denom;
            Stopwatch timer = new Stopwatch();
            double intervalStartMs = 0;
            double intervalEndMs = 0;
            BigInteger f;
            using (StreamWriter sw = new StreamWriter(@"C:\Users\gabe.tower\Documents\65535Fact.txt"))
            {
                timer.Start();

                for (ushort i = 1; i <= 32767; i++)
                {
                    intervalStartMs = timer.ElapsedMilliseconds;
                    f = i.Factorial();
                    intervalEndMs = timer.ElapsedMilliseconds;

                    sw.WriteLine(string.Format("{0} ({1}): {2}", i, (intervalEndMs - intervalStartMs) / 1000.0, f));

                    if (i % 1000 == 0)
                    {
                        Console.WriteLine("Wrote {0}! in {1} sec", i, (intervalEndMs - intervalStartMs) / 1000.0);
                    }

                }

                timer.Stop();
                Console.WriteLine(string.Format("Total Time (sec): {0}", timer.ElapsedMilliseconds / 1000.0));
                sw.WriteLine(string.Format("Total seconds: {0}", timer.ElapsedMilliseconds / 1000.0));
                
            }

            Console.WriteLine("Press any key to continue...");


            

            //Console.WriteLine("\n\nFinal Value: {0}", runningTotal);
            Console.ReadLine();
        }


    }

    static class Extensions
    {
        /// <summary>
        /// Calculates the factorial of a given short.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static BigInteger Factorial(this ushort num)
        {
            BigInteger output = num;

            while (num > 1)
            {
                output *= --num;
            }

            return output;
        }
    }
}
