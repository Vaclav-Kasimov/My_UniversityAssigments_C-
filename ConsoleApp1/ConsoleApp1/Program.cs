using System;
/*Реализовать определение класса LineSegment -- отрезка на коорд. прямой (поля, свойства, конструкторы, 
 * перегрузка метода ToString() для вывода полей, Определить пересекаются ли заданные отрезки. Результат должен быть типа bool.).
 * 
 * Добавить к реализованному в п. I классу указанные в варианте перегруженные операции. Протестировать все методы
 * 
 * Унарные операции:
 * ! вычислить длину диапазона, результатом должно быть вещественное число
 * ++ расширить отрезок на 1 вправо и влево 
 * 
 * Операции приведения типа:
 * int (неявная) – результатом является целая часть координаты х; 
 * double (явная) – результатом является координата y. 
 * 
 * Бинарные операции:
 * - LineSegment целое число (левосторонняя операция, уменьшается координата х);
 * - целое число LineSegment (правосторонняя операция, уменьшается координата y); 
 * < LineSegment d – результат равен true, если отрезки пересекаются, и false – в противном случае.*/
namespace ConsoleApp1
{
    class LineSegment
    {
        double x, y;//Начало и конец отрезка на координатной прямой

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }

        public LineSegment() { x = 0; y = 1; }//Конструктор по умолчанию, даёт обычный еденичный отрезок

        public LineSegment(double x, double y) { this.x = x; this.y = y; }//Обычный конструктор задающий напрямую начало и конец отрезка

        public LineSegment(LineSegment baza) { this.x = baza.x; this.y = baza.y; }//Конструктор копирования

        public override string ToString() { return ("Начало отрезка " + x + " Конец отрезка " + y); }//Перегрузка ToString

        public bool IsCrossing(LineSegment b)//Метод, проверяющий, пересекаются ли отрезки
        {
            if (((b.x <= this.x && this.x < b.y) || (b.x < this.y && this.y <= b.y) || (this.x <= b.x && b.x < this.y) || (this.x < b.y && b.y <= this.y)))
                return true;
            else return false;
        }

        public static double operator ! (LineSegment a)//Оператор возвращающий длину отрезка
        {
            return a.y - a.x;
        }

        public static LineSegment operator ++ (LineSegment a)//Оператор, увеличивающий отрезок на  1 вправо и влево
        {
            return new LineSegment(a.x - 1, a.y + 1);
        }

        public static implicit operator int(LineSegment a)//Возвращает целую часть координаты начала отрезка. Неявное преобразование
        {
            return Convert.ToInt32(Math.Truncate(a.x));
        }

        public static explicit operator double(LineSegment a)//Возвращает координату y. Явное преобразование
        {
            return a.y;
        }

        public static LineSegment operator - (LineSegment a, int b)//Левосторонняя операция, уменьшаем на int координату начала
        {
            return new LineSegment(a.x - b, a.y);
        }

        public static LineSegment operator -(int a, LineSegment b)//Уменьшаем на int координату конца
        {
            return new LineSegment(b.x, b.y - a);
        }

        public static bool operator < (LineSegment a, LineSegment b)//результат равен true, если отрезки пересекаются,
                                                                    //и false – в противном случае.
        {
            return a.IsCrossing(b);
        }

        public static bool operator >(LineSegment a, LineSegment b)//Обратный к предыдущему оператор
        {
            return !a.IsCrossing(b);
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            LineSegment a, b, a_copy, c;
            a = new LineSegment();//Еденичный отрезок
            b = new LineSegment(2.23, 10.563);
            a_copy = new LineSegment(a);
            c = new LineSegment(5, 15);
            Console.WriteLine("Примением к отрезку С (5,15) метод ToString. Результат " + c.ToString());
            Console.WriteLine("Протестируем операторы. Пересекаются ли отрезки (2.23,10.563) и (5,15): {0}\nПересекаются ли отрезки (1,0) и (2.23,10.563): {1}", b < c, a < c);
            a_copy++;
            Console.WriteLine("Расширим копию отрезка a на 1 в обе стороны. Теперь ее параметры такие: {0}", a_copy.ToString());
            Console.WriteLine("Получим ее длину: {0}", !a_copy);
            a_copy = a_copy - 2;
            a_copy = 1 - a_copy;
            Console.WriteLine("Теперь уменьшим на 2 координату начала и на 1 координату конца. Результат: {0}", a_copy.ToString());
            int x = b;
            double y = (double)b;
            Console.WriteLine("Перейдем к отрезку b. Его параметры: {0}. \nПреобразуем его координаты в int (начало отрезка, преобразуем неявно, взяв только целую часть) и Double (Конец отрезка, преобразуем явно).\nВыведем целую часть от координаты его начала: {1} и координату его конца: {2}", b.ToString(), x, y);
        }
    }
}
