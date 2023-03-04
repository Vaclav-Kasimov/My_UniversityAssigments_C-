using System;
using System.Collections.Generic;
using System.Text;


namespace WinFormsApp1
{
    class MathVect : IComparable<MathVect>//Вектор. Имеет параметры -- координаты точки конца (начало в 0,0)
    {//Интерфейс IComparable нужен для сортировки
        double x,y;//Координаты вектора

        public MathVect(double xx, double yy)//Конструктор
        {
            x = xx;
            y = yy;
        }
        public int CompareTo(MathVect p)//Метод CompareTo -- будет сравнивать вектора через длины
        {
            return this.Length.CompareTo(p.Length);
        }

        public override string ToString()//Для вывода вектора. Будемвыводить его через координаты
        {
            return "(" + x + "; " + y + ")";
        }

        public double X { get { return x; } }

        public double Y { get { return y; } }

        public static MathVect operator +(MathVect a, MathVect b)//Сложение векторов
            => new MathVect(a.x + b.x, a.y + b.y);

        public static MathVect operator -(MathVect a, MathVect b)//Вычитание векторов
            => new MathVect(a.x - b.x, a.y - b.y);

        public static double operator * (MathVect a, MathVect b)//Скалярное произведение векторов
            =>(a.X * b.X + a.Y * b.Y);

        public static MathVect operator *(MathVect a, double b)//Умножение вектора на число
            => new MathVect(a.X * b, a.y * b);

        public double Length { get { return Math.Sqrt(x * x + y * y); } }//Свойство, возвращает длину векторв

        public static double Ugol(MathVect a, MathVect b)//Определяет угол между векторами и переводит его в градусы
            => (Math.Acos((a * b) / (a.Length*b.Length)))*(180/Math.PI);

        public static bool Collinear(MathVect a, MathVect b)//Проверяет коллинеарность векторов
        {
            bool result;
            if (a.X == 0 && b.X == 0)//Если вектора направлены вдоль oX или oY, то они коллинеарны
                result = true;
            else
            {
                if (a.Y == 0 && b.Y == 0)
                    result = true;
                else                //Иначе они коллинеарны если уних совпадает соотношение соответствующих координат
                    result = a.X / b.X == a.Y / b.Y;
            }

            return result;
        }


    }
}
