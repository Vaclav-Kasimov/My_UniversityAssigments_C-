using System;

namespace LAB4
{
    class Program
    {
        static void Main(string[] args)
        {
            BinFile.Path = @"D:\file.dat";
            Console.WriteLine("1 -- Первая и вторая задачи, иначе третья задача");
            int tsk = Convert.ToInt32(Console.ReadLine());
            if (tsk == 1)
            {
                
                BinFile.Size = 14;
                BinFile.RandomInt32Fill();
                BinFile.PrintInt32();
                Console.WriteLine("Количество квадратов нечетных чисел " + BinFile.SqrtNechet());
                int[,] matrix = BinFile.ToMatrix();
                for (int i = 0; i < BinFile.Matrix_Size; i++)
                {
                    for (int j = 0; j < BinFile.Matrix_Size; j++)
                        Console.Write(matrix[i, j] + "   ");
                    Console.WriteLine();
                }
            }
            else
            {
                Toy[] toys = new Toy[5];
                toys[1] = new Toy("Мяч", 100, 0, 18);
                toys[2] = new Toy("Соска", 10, 0, 4);
                toys[3] = new Toy("Кукла", 12, 0, 4);
                toys[0] = new Toy("Кубики", 5, 0, 4);
                toys[4] = new Toy("Конструктор", 1500, 6, 17);
                BinFile.Serialization(toys);
            }
        }
    }
}
