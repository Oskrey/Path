using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Оригинал
            /*
            int[,] a = new int[6, 5]
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
            };*/
            int[,] a = new int[6, 5]
            {
                {1, 0, 0, 0, 0},
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
                {0, 0, 0, 0, 1}
            };

            int[,] aArrow = new int[6, 5];
            int[,] bArrow = new int[6, 5];
           

            int[,] cColor = new int[6, 6];
            cColor[0, 0] = 1;
            cColor[5, 5] = 1;
            int[,] c = new int[6, 6];
            //заполнение нулями
            for (int i = 0; i<5;i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    c[i, j] = 0;
                    cColor[i, j] = 0;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    aArrow[i, j] = 0;
                    bArrow[i, j] = 0;
                }
            }
            //заполнение нулями


            //Вынужденный верхний
            for (int i= 4; i >= 0; i--)
            {
                c[5, i] = c[5, i + 1] + a[5, i];
            }
            //Вынужденный правый
            for (int i = 4; i >= 0; i--)
            {
                c[i, 5] = c[i + 1, 5] + b[5, i];
            }

            Console.WriteLine("Вынужденный путь");
            Console.WriteLine();
            for (int i = 6 - 1; i >= 0; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write("{0, 5}", c[i, j]);

                }
                Console.WriteLine();
                Console.WriteLine();

            }
            
            //Подсчёты
            for (int i = 0; i < 6-1 ; i++)
            {
                for (int j = 0; j < 6 - 1; j++)
                {
                    int vertical = c[6 - i - 1, 6 - j - 2] + b[6 - 2 - j, 6 - i - 2];
                    int horizontal = c[6 - i - 2,6 - j - 1] + a[6 - 2 - i,6 - j - 2];
                    if (horizontal > vertical)
                    {
                        c[6 - 2 - i,6 - 2 - j] = vertical;
                        bArrow[6 - 2 - j,6 - i - 2] = 1;
                    }
                    else
                    {
                        c[6 - 2 - i,6 - 2 - j] = horizontal;
                        aArrow[6 - 2 - i,6 - j - 2] = 1;
                    }
                }
            }
            //-------------------------------------
            
            // путь
            int ii = 0;
            int jj = 0;
            while (ii < 6 - 1 || jj < 6 - 1)
            {               
                
                if (jj == 5 && ii < 5)
                {
                    cColor[jj, ii + 1] = 1;
                    ii++;
                }
               else if (jj < 5 && ii < 5)
                {
                    if (aArrow[jj, ii] == 1 && bArrow[ii, jj] != 1 || jj >= 5)
                    {
                        cColor[jj, ii + 1] = 1;
                        ii++;
                    }
                }
                if (ii == 5 && jj<5)
                {
                    cColor[jj + 1, ii] = 1;
                    jj++;
                }
                else if (jj < 5 && ii <5)
                {
                    if (bArrow[ii, jj] == 1 && aArrow[jj, ii] != 1 || ii >= 5)
                    {
                        cColor[jj + 1, ii] = 1;
                        jj++;
                    }
                }
                
            }
            
            //Вывод
            Console.WriteLine("Путь");
            Console.WriteLine();
            for (int i = 6 - 1; i >= 0; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (cColor[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0, 5}", c[i, j]);

                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0, 5}", c[i, j]);
                    }
                }
                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}
