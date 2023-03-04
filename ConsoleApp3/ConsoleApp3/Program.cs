using System;

namespace ConsoleApp3
{
    class Matrix
    {
        int n;//Размерность матрицы
        int[,] matrix;//Сама матрица

        public Matrix()//Конструктор по умолчанию создает матрицу 10х10 случайных элементов 1-10
        {
            Random rand = new Random();
            n = 10;
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    matrix[i, j] = rand.Next(1, 10);
            }
        }

        public Matrix(int input_n)//Создание матрицы заданной размерности
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

        public override string ToString()
        {
            string result;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    result = result + matrix[i, j] + ' ';
                result += '\n';
            }
            return result;
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public void Trans3rd()
        {
            int[,] T_matrix = new int[n / 2, n / 2];//Создаем вспомогательную матрицу для транспонирования
            for(int i = 0; i < n/2; i++)
            {
                for(int j = 0; j < n/2; j++)
                {
                    T_matrix[i, j] = matrix[j, i + n / 2];
                }
            }
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    matrix[i+n/2, j] = T_matrix[i, j];
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
            m.Print();
        }
    }
}
