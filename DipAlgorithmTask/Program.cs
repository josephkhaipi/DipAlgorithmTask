using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms
{
    class Program
    {
        public static int[] nums = new int[] { 1499, 2999 };
        public static int[] csvD;
        public static int[] sData;
        public int numb = 0;
        public static int[] Fnum = new int[] { };

        static void Main(string[] args)
        {

            using (var readFile = new StreamReader(@"D:\GitHub\DipAlgorithmTask\DipAlgorithmTask\unsorted_numbers.csv"))
            {
                csvD = readFile.ReadToEnd().Split('\n').SelectMany(s => s.Split(',').Select(x => int.Parse(x))).ToArray<int>();
                sData = csvD;
                int n = csvD.Length;
                int f = sData.Length;


                Console.WriteLine("Shell Sorting.......");
                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                ShellSort(sData, f);
                WriteF($"D:\\GitHub\\DipAlgorithmTask\\DipAlgorithmTask\\ShellSort.csv", ShellSort(sData, f));
                stopwatch1.Stop();
                TimeSpan ts = stopwatch1.Elapsed;
                Console.WriteLine($"Shell Sort duration is: {ts.TotalMilliseconds} Milliseconds");
                Console.ReadLine();
                Console.WriteLine();


                Console.WriteLine("Insertion Sorting.......");
                Stopwatch stopwatch2 = new Stopwatch();
                stopwatch2.Start();
                Print(InsertionSort(csvD));
                stopwatch2.Stop();
                TimeSpan ts2 = stopwatch2.Elapsed;
                WriteF($"D:\\GitHub\\DipAlgorithmTask\\DipAlgorithmTask\\InsertionSort.csv", InsertionSort(csvD));
                Console.WriteLine($"Insertion Sort duration is: {ts2.TotalMilliseconds} Milliseconds");
                Console.WriteLine();
                Console.ReadLine();



                Console.WriteLine("Linear Searching.......");
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch3.Start();
                LinearSearch(csvD);
                stopwatch3.Stop();
                TimeSpan ts3 = stopwatch3.Elapsed;
                Console.WriteLine($"Linear Search duration is: {ts3.TotalMilliseconds} Milliseconds");
                Console.ReadLine();



                Console.WriteLine("Binary Searching.......");
                Stopwatch stopwatch4 = new Stopwatch();
                stopwatch4.Start();
                BinarySearch(csvD);
                TimeSpan ts4 = stopwatch4.Elapsed;
                Console.WriteLine($"Binary Search duration is: {ts4.TotalMilliseconds} Milliseconds");
                Console.ReadLine();

            }
        }

        public static void WriteF(string path, int[] array) => File.WriteAllLines(path, array.Select(x => x.ToString()));

        static int[] ShellSort(int[] arr, int n)
        {
            int i, j, position, temp;
            position = 3;
            while (position > 0)
            {
                for (i = 0; i < n; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= position) && (arr[j - position] > temp))
                    {
                        arr[j] = arr[j - position];
                        j = j - position;
                    }
                    arr[j] = temp;
                }
                if (position / 2 != 0)
                    position = position / 2;
                else if (position == 1)
                    position = 0;
                else
                    position = 1;
            }
            return arr;
        }

        static int[] InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        Console.WriteLine(arr[j]);
                    }
                }
            }
            return arr;
        }

        public static void Print(int[] array)
        {
            foreach (int i in array)
            {

            }
        }


        public static object BinarySearch(int[] arr)
        {
            bool loop = true;
            int arLength = arr.Length;
            int i = 1499;
            int Start = 0;
            int End = arr.Length - 1;
            int Middle = (Start + End) / 2;

        loopBefore:
            while (loop)
            {

                arLength = arr.Length;
                Start = 0;
                End = arr.Length - 1;
                Middle = (Start + End) / 2;


            loopAfter:
                while (true)
                {

                    if (Middle == i)
                    {
                        Console.WriteLine(arr[i]);
                        break;
                    }
                    else if (i < Middle)
                    {
                        End = Middle;
                        Middle = (Start + End) / 2;
                        goto loopAfter;
                    }
                    else
                    {
                        Start = Middle;
                        Middle = (Start + End) / 2;

                        if (i == arr.Length - 1)
                        {
                            Console.WriteLine(arr[i]);
                            loop = false;
                            goto loopBefore;
                        }
                        goto loopAfter;
                    }
                }
                if (i == 14999)
                {
                    loop = false;
                }
                i = i + 1500;
            }
            return -1;
        }
        public static int LinearSearch(int[] arr)
        {
            int Max = arr.Length + 1;

            for (int i = 1; i < Max; i++)
            {
                if (i % 1500 == 0)
                {
                    Console.WriteLine(arr[i - 1]);
                }

            }
            return -1;
        }



    }
}