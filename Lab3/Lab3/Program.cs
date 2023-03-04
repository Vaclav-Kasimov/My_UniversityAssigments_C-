using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №3. Введите n и m -- размерности массивов.");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Часть 1. Итеративно выполненные задания.\nЧасть 1. Задание 1. Пункт 1. Ввести массив n*m с клавиатуры снизу вверх по столбцам. Введите массив.");
            Matrix a = new Matrix(n, m);
            a.Lab21_Iter_pt1();
            a.Print();
            Console.WriteLine("Часть 1. Задание 1. Пункт 2. Массив n*n заполняется случайными числами так, что в каждом столбце получается возрастающая последовательность.");
            a = new Matrix(n);
            a.Lab21_Iter_pt2();
            a.Print();
            Console.WriteLine("Часть 1. Задание 1. Пункт 3. Массив n*n заполняется простыми числами начиная с 2, построчно, слева направо, по возрастанию.");
            a = new Matrix(n);
            a.Lab21_Iter_pt3();
            a.Print();
            Console.WriteLine("Часть 1. Задание 2. Найти в двумерном массиве n*n такую диагональ, параллельную главной, что сумма элементов в ней максимальная. Для удобства я сделал массив случайно заполняющимся.");
            a = new Matrix(n);
            a.Lab22_Iter();
            Console.WriteLine("Часть 1. Задание 3. Пример с матрицами: (B^T)*A*C. Введите массивы вручную. Массивы будут размеерности 3*3.");
            Matrix b, c;//Размерность 3*3 сделана для удобства тестирования
            a = new Matrix(3); b = new Matrix(3); c = new Matrix(3);
            a.HandFull(); b.HandFull(); c.HandFull();
            b.T_Iter().Multiply_Iter(a).Multiply_Iter(c).Print();
            Console.WriteLine("Часть 2. Рекурсивно выполненные задания.\nЧасть 2. Задание 1. Пункт 1. Ввести массив n*m с клавиатуры снизу вверх по столбцам. Введите массив.");
            a = new Matrix(n, m);
            a.lab21_Rec_pt1();
            a.PrintRec();
            Console.WriteLine("Часть 2. Задание 1. Пункт 2. Массив n*n заполняется случайными числами так, что в каждом столбце получается возрастающая последовательность.");
            a = new Matrix(n);
            a.lab21_Rec_pt2();
            a.PrintRec();
            Console.WriteLine("Часть 2. Задание 1. Пункт 3. Массив n*n заполняется простыми числами начиная с 2, построчно, слева направо, по возрастанию.");
            a = new Matrix(n);
            a.lab21_Rec_pt3();
            a.PrintRec();
            Console.WriteLine("Часть 2. Задание 2. Найти в двумерном массиве n*n такую диагональ, параллельную главной, что сумма элементов в ней максимальная. Для удобства я сделал массив случайно заполняющимся.");
            a = new Matrix(n);
            a.lab22_Rec();
            Console.WriteLine("Часть 2. Задание 3. Пример с матрицами: (B^T)*A*C. Введите массивы вручную. Массивы будут размеерности 3*3.");
            //Размерность 3*3 сделана для удобства тестирования
            a = new Matrix(3); b = new Matrix(3); c = new Matrix(3);
            a.Hand_Rec_arrayFilling(); b.Hand_Rec_arrayFilling(); c.Hand_Rec_arrayFilling();
            b.T_Rec().Multiply_Rec(a).Multiply_Rec(c).PrintRec();
        }
    }
}
