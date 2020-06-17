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
        static string file1 = @"../../FileByThread_1.txt";
        static string file2 = @"../../FileByThread_22.txt";

        /// <summary>
        /// Method for generating Identity matrix and writing it into text file FileByThread_1.txt
        /// </summary>
        /// <returns></returns>
        static int[,] IdentityMatrix()
        {

            int[,] result = new int[100, 100];

            using (StreamWriter sw = new StreamWriter(file1))
            {
                for (int i = 0; i < 100; ++i)
                {
                    for (int j = 0; j < 100; ++j)
                    {
                        if (i == j)
                            sw.Write(result[i, j] = 1);

                        else
                            sw.Write(result[i, j] = 0);
                    }
                    sw.WriteLine();
                }
            }
            return result;

        }

        /// <summary>
        /// Method for generating 1000 random odd numbers and writing it into file FileByThread_22.txt
        /// </summary>
        static void GetRandomNumbers()
        {
            long[] oddNums = new long[1000];
            Random rnd = new Random();
            long num = 0;
            for (int i = 0; i < oddNums.Length; i++)
            {

                do
                {
                    num = rnd.Next(0, 10000);
                    oddNums[i] = num;

                } while (num % 2 == 0);


            }

            using (StreamWriter sw = new StreamWriter(file2))
            {

                for (int i = 0; i < oddNums.Length; i++)
                {

                    sw.WriteLine(oddNums[i]);
                }
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
