using System;

class Base
{
    protected double a;
    protected double b;
    protected double c;

    
    public Base() //конструктор без параметров
    {
        Random rand = new Random(); //для случайного заполнения полец
        a = rand.Next(-10, 10);
        b = rand.Next(-10, 10);
        c = rand.Next(-10, 10);
    }

    public Base(double A, double B, double C)//конструктор с параметрами
    {
        a = A;
        b = B;
        c = C;
    }

    public override string ToString()//перегрузка метода ToString
    {
        return a + " " + b + " " + c;
    }

    public virtual void Print(Base X)//метода для вывода с virtual для переопределения этого метода в наследуемых классах
    {
        Console.WriteLine(X.ToString());
    }
}

class Nerav : Base
{
    public Nerav() : base() { } //наследование конструктора без параметров

    public Nerav(double A, double B, double C) : base(A, B, C) { }//наследование конструктора спараметрами

    public override string ToString()//перегрузка метода ToString
    {
        return a + "x^2" + " + " + b + "x" + " + " + c + " > 0";
    }

    public override void Print(Base X) //переопределние метода вывода через override
    {
        Console.WriteLine(X.ToString());
    }

    public void Solution()//решение неравенства
    {
        double x1;
        double x2;

        double D = Math.Pow(b, 2) - 4 * a * c;//дискриминант

        if (D > 0)
        {
            x1 = (Math.Pow(D, 0.5) - b) / (2.0 * a);
            x2 = (-Math.Pow(D, 0.5) - b) / (2.0 * a);

            if (x1 < x2)
            {
                double temp = x2;
                x2 = x1;
                x1 = temp;
            }//в х1 больший корень

            if (a > 0) //ветви вверх
            {
                Console.WriteLine("(-inf;" + x2 + ") ~ (" + x1 + "; +inf)");
            }
            else
            {
                Console.WriteLine("(" + x2 + " ; " + x1 + ")");
            }
        }

        else if (D == 0)
        {
            x1 = -b / (2.0 * a);

            if (a > 0) //ветви вверх
            {
                Console.WriteLine(x1 + " ; +inf");
            }
            else
            {
                Console.WriteLine("-inf ; " + x1);
            }
        }

        else
        {
            Console.WriteLine("Решений нет");
        }

    }

    public void Quantity()//для классификации по количеству решений
    {
        double D = Math.Pow(b, 2) - 4 * a * c;//дискриминант

        if ((a < 0 && D > 0) || D == 0) //ветви параболы вниз или один Х
        {
            Console.WriteLine("одно решение (промежуток)");
        }

        else if (D > 0) //ветви вверх и два Х
        {
            Console.WriteLine("два решения (промежутка)");
        }

        else if (D < 0) //нет решений
        {
            Console.WriteLine("нет решений");
        }
    }
}

class Program
    {
        static void Main(string[] args)
        {
        //Ниже мои тесты, у меня все работает как на калькуляторе.
            Console.WriteLine("1");
            Nerav n = new Nerav(-1, 2, 2);
            Console.WriteLine(n);
            n.Solution();
            n.Quantity();
            Console.WriteLine();
            Console.WriteLine("2");
            n = new Nerav(-1, 2, -2);
            Console.WriteLine(n);
            n.Solution();
            n.Quantity();
            Console.WriteLine();
            Console.WriteLine("3");
            n = new Nerav(-10, 2, 22);
            Console.WriteLine(n);
            n.Solution();
            n.Quantity();
            Console.WriteLine();
            Console.WriteLine("4");
            n = new Nerav(10, 2, -100);
            Console.WriteLine(n);
            n.Solution();
            n.Quantity();
            Console.WriteLine();
            Console.WriteLine("5");
            n = new Nerav(10, -30, -100);
            Console.WriteLine(n);
            n.Solution();
            n.Quantity();
        }
    }
