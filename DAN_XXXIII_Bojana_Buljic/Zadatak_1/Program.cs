﻿using System;
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

            //writing matrix into file
            using (StreamWriter sw = new StreamWriter(file2))
            {

                for (int i = 0; i < oddNums.Length; i++)
                {

                    sw.WriteLine(oddNums[i]);
                }
            }

        }

        /// <summary>
        /// Method for Reading Identity Matrix from FileByThread_1.txt and printing it on Console
        /// </summary>
        static void ReadFileByThread1()
        {
            string[] readFile1 = File.ReadAllLines(file1);
            foreach (string s in readFile1)
            {
                Console.WriteLine(s);
            }

        }

        /// <summary>
        /// Method for Reading FileByThread_22.txt
        /// </summary>
        static void ReadFileByThread2()
        {
            string[] readFile2 = File.ReadAllLines(file2);

            long sum = 0;
            foreach (string s in readFile2)
            {
                sum += Convert.ToInt64(s);
            }

            Console.WriteLine("The sum of all odd numbers:" + sum);
        }

        static void Main(string[] args)
        {
            Thread[] threadsArray = new Thread[4]
           {
                new Thread(() => IdentityMatrix()),
                new Thread(() => GetRandomNumbers()),
                new Thread(() => ReadFileByThread1()),
                new Thread(() => ReadFileByThread2())
           };
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 != 0)
                {
                    threadsArray[i].Name = string.Format("Thread_{0}{1}", i + 1, i + 1);
                }
                else
                {
                    threadsArray[i].Name = string.Format("Thread_{0}", i + 1);
                }
                Console.WriteLine(threadsArray[i].Name + " is created");
            }            

            Stopwatch sw = new Stopwatch();
            sw.Start();
            threadsArray[0].Start();
            threadsArray[1].Start();
            threadsArray[0].Join();
            threadsArray[1].Join();
            sw.Stop();
            Console.WriteLine("\n{0} milliseconds\n", sw.ElapsedMilliseconds);
            Thread.Sleep(1000);

            threadsArray[2].Start();
            threadsArray[3].Start();

            Console.ReadLine();
        }
    }
}
