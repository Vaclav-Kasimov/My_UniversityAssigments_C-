using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Тест задачи 1
            List<string> List1 = new List<string>() { "Кошка", "Собака", "Хомяк" };
            List<string> List2 = new List<string>() { "Крыса", "Хомяк", "Кошка" };
            Console.WriteLine("Задание 1 (листы { \"Кошка\", \"Собака\", \"Хомяк\" } и { \"Крыса\", \"Хомяк\", \"Кошка\" }):");
            foreach (string current in LAB5.Task1<string>(List1, List2))
                Console.Write(current + " ");

            //Тест задачи 2
            Console.WriteLine("\n\nЗадание 2 (исходный лист содержит цифры 0-4):");
            LinkedList<int> L1 = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
                L1.AddLast(i);
            foreach (int n in LAB5.Task2<int>(L1))
                Console.Write(n + " ");


            //Тест задачи 3
            Console.WriteLine("\n\nЗадание 3 (Всего 5 студентов: Иванов, Петров, Васечкин, сидоров, Вовочкин. Распределяются рандомно.):");
            Random rand = new Random();
            HashSet<string> students = new HashSet<string>() { "Иванов", "Петров", "Васечкин", "Сидоров", "Вовочкин" };
            HashSet<string> Biology = new HashSet<string>();
            HashSet<string> Physics = new HashSet<string>();
            HashSet<string> Fizra = new HashSet<string>();
            foreach (string student in students)
            {
                if (rand.Next(0, 2) == 1)
                    Fizra.Add(student);
                if (rand.Next(0, 3) == 1)
                    Biology.Add(student);
                if (rand.Next(0, 4) == 1)
                    Physics.Add(student);
            }
            Console.Write("Список студентов, посещающих факультатив по физкультуре: ");
            foreach (string student in Fizra)
                Console.Write(student + ", ");
            Console.Write("\nСписок студентов, посещающих факультатив по биологии: ");
            foreach (string student in Biology)
                Console.Write(student + ", ");
            Console.Write("\nСписок студентов, посещающих факультатив по физике: ");
            foreach (string student in Physics)
                Console.Write(student + ", ");
            Console.Write("\n");
            Console.Write("\nСписок факультативов, на которые ходят все пять студентов: ");
            if (LAB5.Task3_All(students, Biology)) Console.Write("биология, "); if (LAB5.Task3_All(students, Physics)) Console.Write("физика, "); if (LAB5.Task3_All(students, Fizra)) Console.Write("физкультура.");
            Console.Write("\nСписок факультативов, на которые ходит хотя бы один студент: ");
            if (LAB5.Task3_OneOrMore(students, Biology)) Console.Write("биология, "); if (LAB5.Task3_OneOrMore(students, Physics)) Console.Write("физика, "); if (LAB5.Task3_OneOrMore(students, Fizra)) Console.Write("физкультура.");
            Console.Write("\nСписок факультативов, на которые никто не ходит: ");
            if (LAB5.Task3_NoOne(students, Biology)) Console.Write("биология, "); if (LAB5.Task3_NoOne(students, Physics)) Console.Write("физика, "); if (LAB5.Task3_NoOne(students, Fizra)) Console.Write("физкультура.");


            //Тест задачи 4
            Console.Write("\n\nЗадание 4. Уникальных русских букв в тексте: ");
            Console.Write(LAB5.Task4(@"D:/text.txt"));
        }
    }
}
