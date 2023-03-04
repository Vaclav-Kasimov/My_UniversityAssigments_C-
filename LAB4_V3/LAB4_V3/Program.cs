using System;

namespace LAB4_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_ForTask12, path_ForTask3, path_ForTask4;//Адреса файлов для задач (1 и 2) 3 и 4 соответственно
            path_ForTask12 = @"D:\file_task12.dat";
            path_ForTask3 = @"D:\file_task3.dat";
            path_ForTask4 = @"D:\text.txt";
            int n = 13;//Количество элементов в заданиях 1 и 2


            //ЗАДАНИЕ 1
            BinFile.RandomInt32Fill(path_ForTask12, n);
            BinFile.PrintInt32(path_ForTask12, n);
            Console.WriteLine("Количество чисел, корни которых -- целые нечетные числа = " + BinFile.SqrtNechet(path_ForTask12, n) + "\n\n");


            //ЗАДАНИЕ 2
            int[,] matrix = BinFile.ToMatrix(path_ForTask12, n);
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                    Console.Write(matrix[i, j] + "     ");
                Console.WriteLine();
            }
            Console.WriteLine('\n');


            //ЗАДАНИЕ 3
            Toy[] toys = new Toy[5];
            toys[1] = new Toy("Мяч", 100, 0, 18);
            toys[2] = new Toy("Соска", 10, 0, 4);
            toys[3] = new Toy("Кукла", 12, 0, 4);
            toys[0] = new Toy("Кубики", 5, 0, 4);
            toys[4] = new Toy("Конструктор", 1500, 6, 17);
            BinFile.Serialization(toys, path_ForTask3);


            //ЗАДАНИЕ 4
            Console.WriteLine("\n\nСреднее арифметическое минимального и максимального чисел в файле {0} {1}", path_ForTask4, BinFile.MinAndMax_Average(path_ForTask4));
        }
    }
}
