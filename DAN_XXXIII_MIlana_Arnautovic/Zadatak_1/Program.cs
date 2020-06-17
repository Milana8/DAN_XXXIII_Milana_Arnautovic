using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threadsArray =
           {
               new Thread(() => Matrix()),
               new Thread(() => RandomNumbers()),
               new Thread(() => PrintMatrix()),
               new Thread(() => Suma()),
           };


            for (int i = 0; i < threadsArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    threadsArray[i].Name = string.Format("Thread_{0}", i + 1);
                }
                else
                {
                    threadsArray[i].Name = string.Format("Thread_{0}{1}", i + 1, i + 1);
                }
                Console.WriteLine(threadsArray[i].Name + " is created.\n");
            }
            Stopwatch s = new Stopwatch();
            //start Stopwatch
            s.Start();
            threadsArray[0].Start();
            threadsArray[1].Start();
            threadsArray[0].Join();
            threadsArray[1].Join();
            //stop Stopwatch
            s.Stop();

            TimeSpan ts = s.Elapsed;
            //Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds);
            //printing time on console
            Console.WriteLine("RunTime for Thread_1 and Thread_22 " + elapsedTime);

            threadsArray[2].Start();
            threadsArray[3].Start();
          
            Console.ReadLine();
        }
        /// <summary>
        /// A method that writes a unit matrix to the file
        /// </summary>
        public static void Matrix()
        {
            int[,] matrix = new int[100, 100];

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }

            StreamWriter sw = new StreamWriter(@"../../FileByThread_1.txt");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sw.Write((matrix[i, j]));
                }
                sw.WriteLine();
            }
            sw.Close();

        }
        /// <summary>
        ///  A method that generates a random 1000 odd numbers and writes them to a file
        /// </summary>
        public static void RandomNumbers()
        {
            Random random = new Random();
            int[] numbers = new int[1000];
            for (int i = 0; i < numbers.Length; i++)
            {
                do
                {
                    numbers[i] = random.Next(0, 10000);
                }
                while ((numbers[i] % 2 == 0));
            }
            StreamWriter str1 = new StreamWriter(@"../../FileByThread_22.txt");
            foreach (var item in numbers)
            {
                str1.WriteLine(item);
            }

            str1.Close();
        }
        /// <summary>
        /// A method that prints data from the file to the console
        /// </summary>
        public static void PrintMatrix()
        {
            string[] red = File.ReadAllLines(@"../../FileByThread_1.txt");
            foreach (var item in red)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        /// A method that prints the sum of all generated on the console odd numbers in the file
        /// </summary>
        public static void Suma()
        {
            string[] red = File.ReadAllLines(@"../../FileByThread_22.txt");
            int sum = 0;
            foreach (var item in red)
            {
                sum = sum + Int32.Parse(item);
            }
            Console.WriteLine("The sum of all odd numbers from those written to the file is:" + sum);

        }
    }
}
