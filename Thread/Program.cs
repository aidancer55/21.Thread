using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _Thread
{
    class Program
    {
        static int a = Convert.ToInt32(Console.ReadLine());
        static int b = Convert.ToInt32(Console.ReadLine());
        static int[,] path = new int[a, b];

        static void Main(string[] args)
        {
            Thread gardener1 = new Thread(Gardener1);
            Thread gardener2 = new Thread(Gardener2);
            gardener1.Start();
            gardener2.Start();
            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(path[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void Gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (path[i, j] == 0)
                        path[i, j] = 1;
                    Thread.Sleep(10);
                }
            }
        }
        private static void Gardener2()
        {
            for (int i = b - 1; i > 0; i--)
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (path[j, i] == 0)
                        path[j, i] = 2;
                    Thread.Sleep(10);
                }
            }
        }
    }
}