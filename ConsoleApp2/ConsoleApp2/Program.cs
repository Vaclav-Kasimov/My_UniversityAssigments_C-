using System;

namespace ConsoleApp2
{
    class Base
    {
        protected int a;
        protected int b;
        protected int c;

        public Base()
        {
            a = 0;b = 0;c = 0;
        }

        public Base(int a, int b, int c)
        {
            this.a = a;this.b = b;this.c = c;
        }
        public  override string ToString()
        {
            string result = (a.ToString() + b.ToString() + c.ToString());
            return result;
        }
    }

    class Time : Base
    {
        public Time()
        {
            a = 1;
            b = 1;
            c = 1;
        }
        public Time(int a, int b, int c, int d) : base(a, b, c)
        {
            this.c = this.c * d;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Time a, b;
            a = new Time();
            b = new Time(1, 2, 3, 10);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
