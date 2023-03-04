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
namespace LAB4
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
    static class BinFile//Сам класс бинарного файла
    {

        static string path;//Путь к файлу
        static int n;//Количество элементов в файле

        public static string Path{ set { path = value; } }//Путь к файлу

        public static int Size
        { //Свойство, нужное, чтобы задать или получить количество элементов в файле
            get { return n; }
            set { n = value; } }


        //Для задач 1 и 2. Заполнение бинарного файла случйными числами
        public static void RandomInt32Fill()
        {
            //Создается обьект BinarYwriter. Он записывает в файл сами данные
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            Random rand = new Random();//Обьект класса рандом для генерации случайных чисел
            for (int i = 0; i < n; i++)
                writer.Write(rand.Next(1, 10));
            writer.Close();
        }

        //Вывод содержимого бинарного файла для задач 1 и 2
        public static void PrintInt32()
        {
            Console.WriteLine("Содержимое бинарного файла:");
            //Обьект класса BinaryReader нужен для считывания данных
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
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
        public static int SqrtNechet()
        {
            int count = 0;//Счетчик квадратов нечет. чисел
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));//Считыватель данных
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
        //===============================================================================


        //ЗАДАНИЕ 2
        //Скопировать элементы заданного файла в квадратную матрицу размером n×n(если элементов файла недостает, заполнить оставшиеся
        //элементы матрицы нулями).
        public static int[,] ToMatrix()
        {
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
            //Создаем матрицу, Matrix_SIze -- свойство, которое возвращает сторону квадратной матрицы,
            //оптимальную для кол-ва элементов в текущем бинарном файле
            int[,] matrix = new int[Matrix_Size, Matrix_Size];
            for(int i = 0; i < Matrix_Size; i++)
                for(int j = 0; j < Matrix_Size; j++)
                {
                    if ((i) * Matrix_Size + j + 1 <= n)//Если не дошли до конца файла
                        matrix[i, j] = reader.ReadInt32();//Считываем в текущий элемент матрицы текущий элемент файла
                    else
                        matrix[i,j] = 0;//Иначе записываем в ячейку матрицы 0
                }
            reader.Close();
            Str(matrix);//Выводим на экран информацию о строке с наибольшим количеством элементов кратным сумме индексов
            return matrix;//Возвращаем матрицу в которой содержатся данные из бинарного файла
        }

        public static int Matrix_Size { get {//Свойство, возвращающее оптимальную размерность матрицы при заданом размере бинарного файла
                int m_size;//Размерность матрицы
                if (Math.Sqrt(n) % 1.0 == 0.0)//Если количество элементов в бинарном файле -- квадрат целого числа то размерность матрицы будет этим числом
                    m_size = (int)(Math.Sqrt(n));
                else//иначе ближайшим справа на числовом ряду целым
                    m_size = (int)(Math.Sqrt(n)) + 1;
                return m_size;
            } }

        static void Str(int[,] matrix)//Указать строку (назвать её номер), где максимальное количество элементов, кратных сумме индексов.
        {
            int num=0;//Строка с max количеством элементов кратных сумме индексов
            int max = -1;//Максимальное количество элементов кратных сумме индексов в строке num
            int count = 0;//Количество элементов кратных сумме индексов в текущей строке 
            for (int i = 0; i < Matrix_Size; i++)//Считает сколько таких элмементов в каждой строке и находит максимальную по таким элементам строку
                //Элемент 0,0 не считает потому что не существует чисел кратных нулю, а элементы равные нулю не считает ТК они выступают в роли
                //"заглушек" если не хватило данных из файла
            {
                for (int j = 0; j < Matrix_Size; j++)
                    if(i + j != 0 && matrix[i,j]!=0)
                        if (matrix[i, j] % (i + j) == 0)
                            count++;
                if (count>max)
                {
                    num = i;
                    max = count;
                }
                count = 0;
            }
            Console.WriteLine("Максимальное ({0}) количество элементов, кратных сумме индексов находится в строке {1}. (Элементы равные нулю и элемент с индексом [0,0] не учитываются.)", max, num);
        }


        //===============================================================================
        //ЗАДАНИЕ 3
        //Бинарные файлы, содержащие величины типа struct (заполнение исходного файла организовать отдельным методом)
        //Получить название самой дорогой игрушки для детей до четырех лет.


        public static void Serialization(Toy[] toys)//Запись структур из массива в бинарный файл
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
            Console.WriteLine("Самая дорогая игрушка для детей до 4 лет это " + FindExpensive(toys.Length));
        }

        static string FindExpensive(int n)//Поиск самой дорогой игрушки для детей младше 4 лет.
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

    }
}
