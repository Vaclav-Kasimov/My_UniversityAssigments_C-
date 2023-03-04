using System;

namespace ConsoleApp3
{
    class Matrix
    {
        int n;//Размерность матрицы
        int[,] matrix;//Сама матрица

        public Matrix()//Конструктор по умолчанию создает матрицу 8х8 случайных элементов 1-10
        {
            Random rand = new Random();
            n = 8;
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    matrix[i, j] = rand.Next(1, 10);
            }
        }

        public Matrix(int input_n)//Создание матрицы заданной размерности. Для удобства тоже из случайных элементов
        {
            Random rand = new Random();
            n = input_n;
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    matrix[i, j] = rand.Next(1, 10);
            }
        }

        public int N//Свойство возвращающее размерность матрицы
        {
            get { return n; }
        }

        public override string ToString()//Метод ToString. Матрица в строку сохраняется "поделенной" пробелами и переносами строки на четверти -- для удобства восприятия
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result = result + matrix[i, j] + ' ';
                    if (j+1 == n / 2)
                        result += ' ';
                }
                if (i+1 == n / 2)
                    result += '\n';
                result += '\n';
            }
            return result;
        }

        public void Print()//Метод для вывода матрицы в консоль
        {
            Console.WriteLine(this);
        }

        public void Trans3rd()//Транспонирования третей четверти
        {
            int[,] T_matrix = new int[n / 2, n / 2];//Создаем вспомогательную матрицу для транспонирования
            for (int i = 0; i < n / 2; i++)//Помещаем туда элементы третьей четверти, меняя местами столбцы и строки
            {
                for (int j = 0; j < n / 2; j++)
                {
                    T_matrix[i, j] = matrix[j + n / 2, i];
                }
            }
            for (int i = 0; i < n / 2; i++)//Возвращаем в третью четверть исходной матрицы ее транспонированную версию
            {
                for (int j = 0; j < n / 2; j++)
                {
                    matrix[i + n / 2, j] = T_matrix[i, j];
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix();
            m.Print();
            m.Trans3rd();
            Console.WriteLine();
            m.Print();
        }
    }
}
