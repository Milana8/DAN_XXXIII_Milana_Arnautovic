using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        static void Main(string[] args)
        {
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
