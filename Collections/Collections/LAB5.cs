using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Collections
{
    static class LAB5
    {
        //11. Составить программу, которая формирует список L, включив в него по одному разу элементы,
        //    которые входят одновременно в оба списка L1 и L2.

        public static List<T> Task1<T>(List<T> L1, List<T> L2)
        {
            List<T> result = new List<T>();
            foreach (T current in L1)
            {
                if (L2.Contains(current))
                    result.Add(current);
            }
            return result;
        }

        // в конец непустого списка L добавляет все его элементы, располагая их в обратном порядке
        //(например, по списку из элементов 1, 2, 3 требуется построить список из элементов 1, 2, 3, 3, 2,1);

        static LinkedList<T> Reverse<T>(LinkedList<T> input)//Получаем лист построенный из элементов исходного в обратном порядке
        {
            LinkedList<T> result = new LinkedList<T>();
            foreach (T current in input)
                result.AddFirst(current);
            return result;
        }
        public static LinkedList<T> Task2<T>(LinkedList<T> original)
        {
            LinkedList<T> result = new LinkedList<T>();
            foreach (T _current in original)//Копируем входной список в результирующий
                result.AddLast(_current);
            foreach (T current in Reverse<T>(original))//Копируем перевернутый входной список в результирующий
                result.AddLast(current);
            return result;

        }


        //        Есть перечень факультативов в учебном заведении.Студенты группы записались на некоторые
        //        из этих факультативов.Известно для каждого студента, на какие факультативы он записан.
        //        Определить:
        //        • на какие факультативы из перечня ходят все студенты группы;
        //        • на какие факультативы из перечня ходит хотя бы один студент группы;
        //        • на какие факультативы из перечня не ходит ни один из студентов группы?


        public static bool Task3_All(HashSet<string> students, HashSet<string> facult)//Определяет, ходят ли все студенты на факультатив
        {
            bool result = true;
            foreach (string student in students) { result = result && facult.Contains(student); }
            return result;
        }

        public static bool Task3_NoOne(HashSet<string> students, HashSet<string> facult)//Определяет, пустой ли список студентов у факультатива
        {
            bool result = true;
            foreach (string student in students) { result = result && !(facult.Contains(student)); }
            return result;
        }

        public static bool Task3_OneOrMore(HashSet<string> students, HashSet<string> facult)//Определяет, ходит ли хоть кто-то на факультатив
        {
            return !Task3_NoOne(students, facult);
        }

        //11. Файл содержит текст на русском языке.Сколько разных букв встречается в тексте?
        public static int Task4(string path)
        {
            HashSet<char> RuLetters = new HashSet<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
            int count = 0;
            StreamReader Reader = new StreamReader(path);
            char symbol;
            while (!Reader.EndOfStream)
            {
                symbol = (char)Reader.Read();
                if (RuLetters.Contains(symbol))//Если встречает неудаленную из ХэшСета русских букв букву, то удаляет ее и увеличивает 
                                               //счетчик встреченных русских букв. У букв Ё нумерация не такая как у остальных
                                               //Так что их удаляем отдельно если встретим.
                {
                    count++;
                    RuLetters.Remove(symbol);
                    if (symbol == 'ё')
                        RuLetters.Remove('Ё');
                    else
                    {
                        if (symbol == 'Ё')
                            RuLetters.Remove('ё');
                        else
                        {
                            if ((int)symbol > 1071)
                                RuLetters.Remove((char)((int)symbol - 32));
                            else
                                RuLetters.Remove((char)((int)symbol + 32));
                        }

                    }
                }


                
            }
            return count;
        }




    }
}
