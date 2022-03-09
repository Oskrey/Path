using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[6,5]
            {
                {1, 4, 6, 9, 1},
                {4, 4, 6, 7, 8},
                {3, 5, 7, 9, 8},
                {2, 3, 2, 5, 9},
                {1, 5, 7, 8, 9},
                {0, 8, 6, 9, 9}
            };
            int[,] b = new int[6, 5]
            {
                {2, 2, 2, 3, 1},
                {4, 3, 2, 5, 8},
                {3, 4, 4, 6, 9},
                {2, 5, 5, 7, 8},
                {1, 2, 4, 6, 7},
                {9, 1, 3, 6, 8}
            };
            Console.WriteLine("Движение в лево");
            for(int i = 5; i >= 0; i--)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Дыижение вверх");
            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(b[j,i] + " ");
                }
                Console.WriteLine();
            }

            int[,] ci = new int[6, 6];
           // c[5, 5] = 0;
            for (int i = 0; i<5;i++)
            {
                for (int j = 0; j < 5; j++)
                    ci[i, j] = 0;
            }
            
            //Вынужденный верхний
            for(int i= 4; i >= 0; i--)
            {
                ci[5, i] = ci[5, i + 1] + a[5, i];
            }
            //Вынужденный левый
            for (int i = 4; i >= 0; i--)
            {
                ci[i, 0] = ci[i + 1, 0] + b[5, i];
            }

            Console.WriteLine("Вынужденный путь");

            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write("{0, 10}", ci[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
