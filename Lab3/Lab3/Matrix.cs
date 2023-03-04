using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    /// <summary>
    /// Класс для матрицы (двумерного массива)
    /// </summary>
    
    class Matrix
    {
        int n, m;//Высота и ширина матрицы
        int[,] matrix;//Двумерный массив, в котором хранятся данные матрицы
        /// <summary>
        /// Конструктор для не квадратной матрицы. Создает матрицу размерностью n*m
        /// </summary>
        /// <param name="n">Количество столбцов</param>
        /// <param name="m">Количество строк</param>
        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            matrix = new int[n, m];
        }

        /// <summary>
        /// Конструктор для квадратной матрицы. Создает матрицу размерностью n*n
        /// </summary>
        /// <param name="n">Размерность матрицы</param>
        public Matrix(int n)
        {
            this.n = n;
            this.m = n;
            matrix = new int[n, n];
        }

        /// <summary>
        /// Заполнение матрицы вручную пользователем построчно
        /// </summary>
        public void HandFull()
        {
            Console.WriteLine("Заполните матрицу {0} на {1}", n, m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    this.matrix[i, j] = Convert.ToInt32(Console.ReadLine());

        }

        /// <summary>
        /// Выводит матрицу на экран так, что каждый элемент столбца располагается строго под предыдущим.
        /// </summary>
        public void Print() 
        {
            Console.Write("\n ");
            for (int i = 0; i< n; i++)
            {
                for (int j = 0; j< m; j++)
                    Console.Write("{0,-5:d}", matrix[i, j]);
                Console.Write("\n ");
            }
            Console.Write("\n ");
        }

        /// <summary>
        /// Заполнение квадратного массива случайными числами от 1 до 10, потребуется в лабораторной #22
        /// </summary>
        void Make_0to10()
        {
            Random rand = new Random();
            int j = 0; int i = 0;
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    matrix[i, j] = rand.Next(0, 10);
        }


        /// <summary>
        /// Первое задание лабораторной 21. Итеративное. Массив n*m заполняется пользователем по столбцам снизу вверх
        /// </summary>
        public void Lab21_Iter_pt1()
        {
            Console.WriteLine("Введите {0} чисел для заполнения массива 1 с клавиатуры ", m* n);
            for (int i = 0; i < m; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    matrix[j, i] = Convert.ToInt32(Console.ReadLine()); //Заполняется по столбцам снизу вверх
                }
            }
        }

        /// <summary>
        /// Второе задание лабораторной 21. Итеративное. Массив n*n заполняется случайными числами так, что в каждом столбце получается возрастающая последовательность элементов
        /// </summary>
        public void Lab21_Iter_pt2()
        {
            Random rand = new Random();//Объект класса рандом, нужен нам для генерации случайных чисел для заполнения массива
            for (int i = 0; i < n; i++)
                matrix[0, i] = rand.Next(0, 10);//Заполняется верхняя строка матрицы, исходя из нее уже будут заполняться столбцы
            for (int i = 0; i < n; i++)
                for (int j = 1; j < n; j++)//Заполнение столбцов
                {
                    matrix[j, i] = rand.Next(matrix[j - 1, i] + 1, matrix[j - 1, i] + 100);
                    //Каждый элемент столбца будет большe верхнего хотя бы на 1 но не более чем на 100(чтоб не было очень длинных чисел)
                }

        }

        /// <summary>
        /// Третье задание лабораторной 21. Итеративное. Массив n*n заполняется построчно простыми числами в порядке возрастания, начиная с числа 2
        /// </summary>
        public void Lab21_Iter_pt3()
        {
            bool simp;//Переменная, которая означает, простое число или нет
            int g;//Номер столбца массива
            int f = 1;//Переменная в которой будет храниться простое число
            int ff;//переменная для перебора и последующего нахождения делителей числа f
            for (int i = 0; i < n; i++)//Цикл для заполнения массива простыми числами
            {
                g = 0;
                while (g != n)
                {
                    simp = false;//По умолчанию считаем что число НЕ простое
                    while (!simp)
                    {
                        f += 1;
                        {
                            ff = 2;
                            simp = true;//Пока не докажем обратного, считаем число простым
                            while (ff != f / 2 + 1)//Если предполагаемый делитель больше половины числа, то он точно не делитель
                            {
                                if (f % ff == 0)//Если предп. простое число поделилось на другое число -- оно не простое
                                    simp = false;
                                ff += 1;
                            }
                        }
                    }
                    matrix[i, g] = f;//А вот простое число уже заносим в массив
                    g++;
                }
            }

        }

        //Для второго задания делал вариант 10, ТК задача 11 варианта не до конца отсканирована

        /// <summary>
        /// Лабораторная 22. Матрица n*n, для удобства заполненная случайными числами от 0 до 10. Ищем параллельную главной диагональ с max суммой элементов
        /// </summary>
        public void Lab22_Iter()
        {
            this.Make_0to10();//Заполняем массив случайными числами.
            int j; int i;
            int max = 0;//Переменная для хранения максимальной суммы
            int j1, i1;//Переменные для запоминания координат правого нижнего элемента диагонали чтоб наглядно вывести сумму элементов
            i1 = -1;
            j1 = -1;
            int sum = 0;//сумма элементов текущей диагонали
            for (int a = 0; a < n - 1; a++)//Ищется перебором максимальная сумма из параллельных главной диагоналей, находящихся ниже главной
            {//Начинаем с верха и идем вниз диагонали
                sum = 0;
                j = 0;
                for (i = n - a - 1; i < n && j < n; i++)
                {
                    sum = sum + matrix[i, j];
                    j++;
                }
                if (max < sum)
                {
                    max = sum;
                    i1 = i - 1; j1 = j - 1;
                }
            }
            for (int a = 0; a < n - 1; a++)//Ищется перебором есть ли среди параллельных главной и находящихся выше ее диагоналей диагональ с суммой больше максимальной  суммы из параллельных главной диагоналей, находящихся ниже главной
            {
                sum = 0;
                i = 0;
                for (j = n - a - 1; i < n && j < n; j++)
                {
                    sum = sum + matrix[i, j];
                    i++;
                }
                if (max < sum)
                {
                    max = sum;
                    i1 = i - 1; j1 = j - 1;
                }
            }

            this.Print();//Выводится сам массив

            Console.WriteLine("Элементы диагонали, параллельной главной, с максимальной суммой: ");

            while (i1 != -1 && j1 != -1)//Выводится максимальная сумма и элементы диагонали
            {
                Console.Write(" {0} ", matrix[i1, j1]);
                if (i1 != 0 && j1 != 0)
                    Console.Write(" + ");
                else
                    Console.Write(" = ");
                i1--; j1--;
            }
            Console.Write(" {0}\n\n", max);
        }

        //Методы для итеративного умножения и транспонирования матриц.
        /// <summary>
        /// Итеративное транспонирование
        /// </summary>
        public Matrix T_Iter()
        {
            Matrix result = new Matrix(m,n);
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    result.matrix[i, j] = this.matrix[j, i];//В новой матрице будут поменяны местами координаты всех элементов старой
            return result;
        }

        /// <summary>
        /// Итеративное умножение матриц. Возвращает результат умножения.
        /// </summary>
        /// <param name="another">матрица, НА которую умножаем</param>
        /// <returns></returns>
        public Matrix Multiply_Iter(Matrix another)
        {
            Matrix result = new Matrix(n);//Результат умножения
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    result.matrix[i, j] = 0;//Обнулим его
            for (int i = 0; i < n; i++)//Считаем произведение нашей матрицы на вторую матрицу
                for (int j = 0; j < n; j++)
                    for (int f = 0; f < n; f++)//f -- счетчик элементов iтой строки и jтого столбца.
                        result.matrix[i, j] += this.matrix[i, f] * another.matrix[f, j];
            return result;

        }

        /// <summary>
        /// Рекурсивный вывод
        /// </summary>
        /// <param name="i">Cтолбцы</param>
        /// <param name="j">Строки</param>
        void PrintRec(int i, int j)
        {
            if (j < m && i < n)//Если не дошли до конца массива
            {
                Console.Write("{0,-5:d}", this.matrix[i, j]);
                if (j == m - 1)// В случае если j -- счетчик столбцов дойдет до правого края, надо его обнулить и перейти на следующую строку
                {
                    Console.Write("\n");
                    this.PrintRec(i + 1, 0);
                }
                else //Иначе просто увеличиваем счетчик столбцов, идём слева направо
                {
                    this.PrintRec(i, j + 1);
                }
            }
        }

        /// <summary>
        /// Запуск рекурсивного вывода
        /// </summary>
        public void PrintRec()
        {
            this.PrintRec(0, 0);
        }

        /// <summary>
        /// Рекурсивное заполнение массива снизу вверх по столбцам, сама функция
        /// </summary>
        /// <param name="i">Номер столбца (текущий)</param>
        /// <param name="j">Номер строки (Текущий)</param>
        void lab21_Rec_pt1(int i, int j)
        {
            if (j >= 0 && i < m)//Если не дошли до конца массива
            {
                this.matrix[j, i] = Convert.ToInt32(Console.ReadLine());
                if (j == 0)// В случае если j -- счетчик строки дойдет до первой строки, надо будет начинать заполнять следующий столбец
                {
                    this.lab21_Rec_pt1(i + 1, n - 1);
                }
                else //Иначе просто уменьшаем счетчик строки, идём снизу вверх
                {
                    this.lab21_Rec_pt1(i, j - 1);
                }
            }
        }

        /// <summary>
        /// Метод для запуска рекурсивной функции заполнения массива снизу вверх по столбцам
        /// </summary>
        public void lab21_Rec_pt1()
        {
            this.lab21_Rec_pt1(0, n - 1);
        }

        /// <summary>
        /// Рекурсивно заполняем первую строку массива
        /// </summary>
        /// <param name="rand">Элемент класса рандом</param>
        /// <param name="i">Номер элемента в строке массива</param>
        void lab21_Rec_pt2_First_Str(Random rand, int i)
        {
            if (i < n)
            {
                this.matrix[0, i] = rand.Next(0, 10);
                this.lab21_Rec_pt2_First_Str(rand, i + 1);//Просто двигаясь вправо заполняем рандомными числами от 0 до 10(чтоб очень больших чисел не было)
            }
            else
                this.lab21_Rec_pt2_Other_Str(rand, 0, 1);//И когда первая строка заполнена вызываем рекурсию для заполнения остального массива
        }

        /// <summary>
        /// Рекурсивное заполнение остальных строк массива
        /// </summary>
        /// <param name="rand">Представитель класса Random</param>
        /// <param name="i">Строка номер</param>
        /// <param name="j">Столбец номер</param>
        void lab21_Rec_pt2_Other_Str(Random rand, int i, int j)//Заполняем остальные строки рандомного массива
        {
            if (j < n && i < n)//Если не дошли до конца массива
            {
                this.matrix[j, i] = rand.Next(this.matrix[j - 1, i] + 1, this.matrix[j - 1, i] + 100);//Просто каждый следующий элемент будет в диапазоне от [Предыдущий элемент+1] до [Предыдущий элемент +100]
                if (j == n - 1)// В случае если j -- счетчик столбцов дойдет до правого края, надо его обнулить и перейти на следующую строку
                {

                    this.lab21_Rec_pt2_Other_Str(rand, i + 1, 1);
                }
                else
                {
                    this.lab21_Rec_pt2_Other_Str(rand, i, j + 1);
                }
            }
        }

        /// <summary>
        /// Запуск рекурсивной процедуры заполнения массива случайными числами по возрастанию
        /// </summary>
        public void lab21_Rec_pt2()
        {
            Random rand = new Random();//Экземпляр класса рандом для создания случайного числа
            this.lab21_Rec_pt2_First_Str(rand, 0);
        }

        /// <summary>
        /// Число проверяется на принадлежность к простым числам. Вернет true если число простое.
        /// </summary>
        /// <param name="f">Текущее число</param>
        /// <param name="ff">делитель</param>
        /// <param name="simp">Результат</param>
        /// <returns></returns>
        static bool checkSimp(int f, int ff, bool simp) 
        {
            if (ff != f / 2 + 1)//просто делим число на все предшествующие ему деленному на два числа и если оно
                                //поделится хоть на одно значит оно не простое
            {
                if (f % ff == 0)
                    simp = false;
                ff += 1;
                return checkSimp(f, ff, simp);
            }
            else
                return simp;
        }


        /// <summary>
        /// Нахождение простого числа
        /// </summary>
        /// <param name="f">Текущее число</param>
        /// <param name="simp">Флаг, указывающий на то, считаем ли мы число простым</param>
        /// <returns></returns>
        static int findSimple(int f, bool simp)//
        {
            if (!simp)//Если доказано что число не простое
            {
                f += 1;//Перейдем на следующее число
                if (f <= 3)// 2 3 -- простые числа, их даже проверять не станем
                {
                    simp = true;
                }
                else
                {
                    simp = checkSimp(f, 2, true);//Проверим, простое ли число
                }
                return findSimple(f, simp);
            }
            else
                return f;
        }


        /// <summary>
        /// Заполнение матрицы простыми числами
        /// </summary>
        /// <param name="i">Строка номер</param>
        /// <param name="j">Столбец номер</param>
        /// <param name="ifFirst">Является ли поиск простого числа первым. Это важно тк при поиске каждого простого числа мы отталкиваемся от предыдущего ->Это либо 1 для первого числа, либо предыдущий элемент массива для остальных чисел</param>
        void lab21_Rec_pt3(int i, int j, bool ifFirst) 
        {
            if (j < n && i < n)
            {
                if (ifFirst)
                    this.matrix[i, j] = findSimple(1, false);//Предыдущее простое число -- еденица ТК запуск функции первый раз
                else
                {//Иначе предыдущее простое число -- предыдущий элемент массива
                    if (j > 0)//Если мы не в первом столбце iтой строки, то все просто -- смотрим, что записано в предыдущий столбец этой же строки и понимаем что это и есть простое число (предыдущее)
                        this.matrix[i, j] = findSimple(this.matrix[i, j - 1], false);
                    else//Иначе смотрим на последний столбец предшествующей строки
                        this.matrix[i, j] = findSimple(this.matrix[i - 1, n - 1], false);
                }
                if (j == n - 1)// В случае если j -- счетчик столбцов дойдет до правого края, надо его обнулить и перейти на следующую строку
                {

                    this.lab21_Rec_pt3(i + 1, 0, false);
                }
                else//Иначе двигаемся по строке далее вправо
                {
                    this.lab21_Rec_pt3(i, j + 1, false);
                }
            }
        }

        /// <summary>
        /// Запуск рекурсивного заполнения простыми числами
        /// </summary>
        public void lab21_Rec_pt3()
        {
            this.lab21_Rec_pt3(0, 0, true);
        }




        int j1, i1, max;//Для правильной работы рекурсии по поиску диагонали. Тут хранятся координаты конца диагонали с max суммой и сама сумма
        void RandomFill(Random rand, int i, int j)//Заполняем строки рандомного массива
        {
            if (j < n && i < n)//Если не дошли до конца массива
            {
                this.matrix[j, i] = rand.Next(0, 10);//Просто каждый следующий элемент будет в диапазоне от 0 до 10
                if (j == n - 1)// В случае если j -- счетчик столбцов дойдет до правого края, надо его обнулить и перейти на следующую строку
                {

                    this.RandomFill(rand, i + 1, 0);
                }
                else
                {
                    this.RandomFill(rand, i, j + 1);
                }
            }
        }
        void printLine()//Выводит уравнение суммы всех элементов диагонали
        {
            if (i1 < n && j1 < n)
            {
                Console.Write("{0}", this.matrix[i1, j1]);
                if (j1 < n - 1 && i1 < n - 1)
                    Console.Write(" + ");
                i1 += 1; j1 += 1;
                this.printLine();
            }
        }
        int summir(int i, int j, int sum)//Получение суммы в текущей диагонали
        {
            if (i < n && j < n)
            {
                sum += this.matrix[i, j];
                return (summir( i + 1, j + 1, sum));
            }
            else
                return sum;
        }
        void upperDiagonales(int a)//Ищет среди диагоналей выше главной диагональ с максимальной суммой элементов
        {
            if (a < n - 1)//Тут а это счетчик столбца у первого элемента диагонали. Нужно идти вверх пока не придем до крайней диагонали
            {
                int sum = summir(n - a - 1, 0, 0);//Получаем сумму диагонали
                if (max < sum)
                {
                    max = sum; i1 = n - a - 1; j1 = 0;//И если она максимальная записываем ее, а так же координаты диагонали
                }
                this.upperDiagonales( a + 1);
            }
        }
        void lowerDiagonales(int a)//Ищется есть ли среди параллельных главной и находящихся ниже ее диагоналей диагональ с суммой больше максимальной  суммы из параллельных главной диагоналей, находящихся ниже главной
        {
            if (a < n - 1)
            {
                int sum = this.summir( 0, n - a - 1, 0);//А тут а -- счетчик строки у первого элемента диагонали
                if (max < sum)
                {
                    max = sum; j1 = n - a - 1; i1 = 0;
                }
                this.lowerDiagonales(a + 1);
            }
        }

        /// <summary>
        /// Метод, запускающий рекурсивное заполнение массива случайными числами и поиск в нем диагонали с максимальной суммой параллельной главной
        /// </summary>
        public void lab22_Rec()
        {
            Random rand = new Random();
            this.RandomFill(rand,0,0);//Заполняем рандомными числами 1-10
            j1 = i1 = n;//Даем значения координатам поиска диагонали
            max = -1;
            this.upperDiagonales( 0);//Ищем максимальную сумму элементов среди верхних диагоналей параллельных главной
            this.lowerDiagonales( 0);//Ищем максимальную сумму элементов среди нижних диагоналей параллельных главной
            Console.WriteLine(); Console.WriteLine();
            this.PrintRec();
            Console.WriteLine(); 
            this.printLine();
            Console.Write(" = {0}", max);
            Console.WriteLine();


        }


        void Hand_Rec_arrayFilling(int i, int j)//Заполняем рекурсивно с клавиатуры массив
        {
            if (j < n && i < n)//Если не дошли до конца массива
            {
                this.matrix[i, j] = Convert.ToInt32(Console.ReadLine());//Считываем элемент массива
                if (j == n - 1)// В случае если j -- счетчик столбцов дойдет до правого края, надо его обнулить и перейти на следующую строку
                {

                    this.Hand_Rec_arrayFilling( i + 1, 0);
                }
                else
                {
                    this.Hand_Rec_arrayFilling( i, j + 1);
                }
            }
        }

        public void Hand_Rec_arrayFilling() { this.Hand_Rec_arrayFilling(0,0); }

        /// <summary>
        /// Рекурсивно транспонируем матрицу
        /// </summary>
        /// <param name="result">Результат транспонирования</param>
        /// <param name="i">Столбец</param>
        /// <param name="j">Строка</param>
        void T_Rec(Matrix result, int i, int j)
        {
            
            if (i < n)
            {
                result.matrix[i, j] = this.matrix[j, i];
                if (j == n - 1)
                    this.T_Rec(result, i + 1, 0);
                else
                    this.T_Rec(result, i, j + 1);
            }
        }

        public Matrix T_Rec()//Запуск рекурсивного транспонирования матрицы
        {
            Matrix result = new Matrix(this.n);
            this.T_Rec(result, 0, 0);
            return result;
        }

        int MultOne(Matrix B, int i, int j, int f, int sum)//Поиск значения в клетке (i;j) матрицы A*B 
        {
            if (f < n)
            {
                sum += this.matrix[i, f] * B.matrix[f, j];
                f += 1;
                return this.MultOne(B, i, j, f, sum);
            }
            else
                return sum;
        }

        void Multiply_Rec(Matrix B, Matrix AB, int i, int j)//Заполняет все клетки матрицы A*b
        {
            if (i < n)
            {
                AB.matrix[i, j] = this.MultOne(B, i, j, 0, 0);
                if (j == n - 1)
                    this.Multiply_Rec(B, AB, i + 1, 0);
                else
                    this.Multiply_Rec(B, AB, i, j + 1);
            }
        }

        public Matrix Multiply_Rec(Matrix B)
        {
            Matrix result = new Matrix(this.n);
            this.Multiply_Rec(B, result, 0, 0);
            return result;
        }

    }
}

