using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

/*
   Решение всех задач оформить в виде одного класса со статическими методами, решающими поставленные задачи.
 
  I. Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
        Найти количество квадратов нечетных чисел среди компонент файла.

 II. Бинарные файлы, содержащие числовые данные (исходный файл заполнить случайными данными, заполнение организовать отдельным методом)
        Скопировать элементы заданного файла в квадратную матрицу размером n×n (если элементов файла недостает, заполнить оставшиеся
        элементы матрицы нулями). Указать строку (назвать её номер), где максимальное количество элементов, кратных сумме индексов.

III. Бинарные файлы, содержащие величины типа struct (заполнение исходного файла организовать отдельным методом)
        Получить название самой дорогой игрушки для детей до четырех лет.

 IV. Решить задачу с использованием структуры «текстовый файл» (в файле хранятся целые числа по одному в строке)
        В файле найти среднее арифметическое максимального и минимального элементов.

*/

namespace LAB4_V3
{
    //Структура для третьей задачи
    [Serializable]//Нужно чтобы сериализовать (записать целиком) экхемпляр структуры в бинарный файл
    struct Toy
    {
        string name;
        int price;
        int lower_age;
        int higher_age;
        public Toy(string name, int price, int lower_age, int higher_age)
        {
            this.name = name;
            this.price = price;
            this.lower_age = lower_age;
            this.higher_age = higher_age;
        }

        public int Higher_Age { get { return higher_age; } }
        public int Lower_Age { get { return lower_age; } }
        public string Name { get { return name; } }
        public int Price { get { return price; } }
        public override string ToString()
        {
            string result = ("Название игрушки: " + name + " цена " + price + " возраст от " + lower_age + " до " + higher_age + " лет.");
            return (result);
        }
    }
    static class BinFile
    {
        //Для задач 1 и 2. Заполнение бинарного файла случйными числами
        public static void RandomInt32Fill(string path, int n)//path -- путь к файлу n -- количество встраеваемых случайных чисел
        {
            //Создается обьект BinarYwriter. Он записывает в файл сами данные
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            Random rand = new Random();//Обьект класса рандом для генерации случайных чисел
            for (int i = 0; i < n; i++)
                writer.Write(rand.Next(0, 10));
            writer.Close();
        }

        //Вывод содержимого бинарного файла для задач 1 и 2

        public static void PrintInt32(string path, int n)
        {
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
            Console.WriteLine("Содержимое бинарного файла:");
            int temp;//Временная переменная для считывания данных
            for (int i = 0; i < n; i++)
            {
                temp = reader.ReadInt32();//Помещаем во временную переменную данные, считанные обьектом BinaryReader
                Console.Write(temp + "   ");
            }
            Console.Write('\n');
            reader.Close();
        }


        //===============================================================================
        //ЗАДАНИЕ 1

        //Поиск чисел, являющихся квадратами нечётных чисел и их подсчет

        public static int SqrtNechet(string path, int n)
        {
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));//Считыватель данных
            int count = 0;//Счетчик квадратов нечет. чисел
            int temp;//Тут хранится считанное число
            for (int i = 0; i < n; i++)
            {
                temp = reader.ReadInt32();//Читаем число
                if (temp > 0)
                {
                    if (Math.Sqrt(temp) % 1.0 == 0.0)//Если корень считанного числа -- целое
                    {
                        if (temp % 2.0 != 0.0)//И нечетное, то увеличиваем счетчик
                            count++;
                    }
                }
            }
            reader.Close();
            return count;
        }


        //ЗАДАНИЕ 2
        //Скопировать элементы заданного файла в квадратную матрицу размером n×n(если элементов файла недостает, заполнить оставшиеся
        //элементы матрицы нулями).

        static int Matrix_Size(int n)//Метод, возвращающий оптимальную размерность матрицы при заданом размере бинарного файла
        {

            int m_size;//Размерность матрицы
            if (Math.Sqrt(n) % 1.0 == 0.0)//Если количество элементов в бинарном файле -- квадрат целого числа то размерность матрицы будет этим числом
                m_size = (int)(Math.Sqrt(n));
            else//иначе ближайшим справа на числовом ряду целым
                m_size = (int)(Math.Sqrt(n)) + 1;
            return m_size;

        }

        static void Str(int[,] matrix)//Указать строку (назвать её номер), где максимальное количество элементов, кратных сумме индексов.
        {
            int num = 0;//Строка с max количеством элементов кратных сумме индексов
            int max = int.MinValue;//Максимальное количество элементов кратных сумме индексов в строке num
            int count = 0;//Количество элементов кратных сумме индексов в текущей строке 
            for (int i = 0; i < matrix.GetUpperBound(0); i++)//Считает сколько таких элмементов в каждой строке и находит максимальную по таким элементам строку
                                                             //Элемент 0,0 не считает потому что не существует чисел кратных нулю, а элементы равные нулю не считает ТК они выступают в роли
                                                             //"заглушек" если не хватило данных из файла
            {
                for (int j = 0; j < matrix.GetUpperBound(1); j++)
                    if (i + j != 0 && matrix[i, j] != 0)
                        if (matrix[i, j] % (i + j) == 0)
                            count++;
                if (count > max)
                {
                    num = i;
                    max = count;
                }
                count = 0;
            }
            Console.WriteLine("Максимальное ({0}) количество элементов, кратных сумме индексов находится в строке с индексом {1}. (Элементы равные нулю и элемент с индексом [0,0] не учитываются.)", max, num);
        }

        public static int[,] ToMatrix(string path, int n)
        {
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
            //Создаем матрицу, Matrix_SIze -- метод, который возвращает сторону квадратной матрицы,
            //оптимальную для кол-ва элементов в текущем бинарном файле
            int[,] matrix = new int[Matrix_Size(n), Matrix_Size(n)];
            for (int i = 0; i < Matrix_Size(n); i++)
                for (int j = 0; j < Matrix_Size(n); j++)
                {
                    if ((i) * Matrix_Size(n) + j + 1 <= n)//Если не дошли до конца файла
                        matrix[i, j] = reader.ReadInt32();//Считываем в текущий элемент матрицы текущий элемент файла
                    else
                        matrix[i, j] = 0;//Иначе записываем в ячейку матрицы 0
                }
            reader.Close();
            Str(matrix);//Выводим на экран информацию о строке с наибольшим количеством элементов кратным сумме индексов
            return matrix;//Возвращаем матрицу в которой содержатся данные из бинарного файла
        }


        //===============================================================================
        //ЗАДАНИЕ 3
        //Бинарные файлы, содержащие величины типа struct (заполнение исходного файла организовать отдельным методом)
        //Получить название самой дорогой игрушки для детей до четырех лет.

        static string FindExpensive(int n, string path)//Поиск самой дорогой игрушки для детей младше 4 лет.
                                                       //n -- количество сериализованных элементов
        {
            string name = " "; int cost = 0;//Имя и цена самой дорогой ирушки для детей младше 4 лет
            BinaryFormatter formatter = new BinaryFormatter();//Снова создаем объект BinaryFormatter теперь для десериализации
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);//И поток уже для чтения
            Toy current;
            for (int i = 0; i < n; i++)
            {
                current = (Toy)formatter.Deserialize(fileStream);//Десериализуем из потока экземпляр структуры Toy
                if (current.Price > cost && current.Higher_Age == 4)//Ищем самую дорогую для детей младше 4 лет
                {
                    cost = current.Price;
                    name = current.Name;
                }

            }
            fileStream.Close();
            return name;//Возвращаем ее имя
        }


        public static void Serialization(Toy[] toys, string path)//Запись структур из массива в бинарный файл
        {
            //Предствитель класса BinaryFormatter, который отформатирует структуру в правильный формат для сериализации
            BinaryFormatter formatter = new BinaryFormatter();
            //Поток для записи в бинарный файл
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            foreach (Toy current in toys)
            {
                formatter.Serialize(fileStream, current);//Сериализуем текущий элемент массива игрушек в наш поток в котором открыт бинарный фйл
                Console.WriteLine(current + " !!сериализовано в " + path);
            }
            fileStream.Close();
            //Выводим самую дорогую игрушку для детей младше 4 лет
            Console.WriteLine("Самая дорогая игрушка для детей до 4 лет это " + FindExpensive(toys.Length, path));
        }

        //===============================================================================
        //ЗАДАНИЕ 4
        //Решить задачу с использованием структуры «текстовый файл» (в файле хранятся целые числа по одному в строке)
        //В файле найти среднее арифметическое максимального и минимального элементов.

        public static double MinAndMax_Average(string path)
        {
            StreamReader reader = new StreamReader(path, System.Text.Encoding.Default);
            int min = int.MaxValue;
            int max = int.MinValue;
            string text = reader.ReadLine();
            while (text != null)
            {
                if (min > Convert.ToInt32(text))
                    min = Convert.ToInt32(text);
                if (max < Convert.ToInt32(text))
                    max = Convert.ToInt32(text);
                text = reader.ReadLine();
            }

            double result = min + max;
            result /= 2.0;
            return result;
        }

        //===============================================
    }
}
