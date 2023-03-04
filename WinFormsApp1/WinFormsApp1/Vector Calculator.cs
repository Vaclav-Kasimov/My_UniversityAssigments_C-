using MaterialSkin.Controls;
using MaterialSkin;
using System; using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public static bool InputIsDouble(string msg) //Проверка ввода вещественного числа
        {
            double value;
            bool isDouble = false;
            
                try
                {
                    value = double.Parse(msg);
                    isDouble = true;
                }
                catch (FormatException)
                {
                    isDouble = false;
                    MessageBox.Show("Введено не вещественное число!");
                }
                catch (Exception e)
                {
                    isDouble = false;
                    MessageBox.Show("Ошибка! " + e.Message);
                }
            
            return isDouble;
        }
        public Form1()
        {
            InitializeComponent();
            //Показ краткого руководства перед запуском программы
            MessageBox.Show("Основной вектор -- над ним проводятся все операции.\nДополнительный вектор нужен для операций с двумя векторами\nДля умножения вектора на число и указания количества векторов в массиве для сортировки используйте маленькое текстовое поле в правом нижнем углу.\nВсе числа должны быть типа Double или integer.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Collinear_Button_Click(object sender, EventArgs e)//Пользователь хочет узнать коллинеарны ли вектора
        {
            //проверяется корректность ввода
            if (InputIsDouble(TextBox_X1.Text) && InputIsDouble(TextBox_Y1.Text) && InputIsDouble(TextBox_X2.Text) && InputIsDouble(TextBox_Y2.Text))
            {
                MathVect a = new MathVect(Convert.ToDouble(TextBox_X1.Text), Convert.ToDouble(TextBox_Y1.Text));
                MathVect b = new MathVect(Convert.ToDouble(TextBox_X2.Text), Convert.ToDouble(TextBox_Y2.Text));
                //И только после проверки корректности создаются вектора и запускается соответствующая функция
                if (MathVect.Collinear(a, b))
                    MessageBox.Show("Вектора коллинеарны");
                else
                    MessageBox.Show("Вектора не коллинеарны");
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");

        }

        private void Ugol_Button_Click(object sender, EventArgs e)
        {
            if (InputIsDouble(TextBox_X1.Text) && InputIsDouble(TextBox_Y1.Text) && InputIsDouble(TextBox_X2.Text) && InputIsDouble(TextBox_Y2.Text))
            {
                MathVect a = new MathVect(Convert.ToDouble(TextBox_X1.Text), Convert.ToDouble(TextBox_Y1.Text));
                MathVect b = new MathVect(Convert.ToDouble(TextBox_X2.Text), Convert.ToDouble(TextBox_Y2.Text));
                string result = "Угол между векторами:\n" + MathVect.Ugol(a, b) + "\n(градусов)";
                MessageBox.Show(result);
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");
        }

        private void Scalar_Button_Click(object sender, EventArgs e)
        {
            if (InputIsDouble(TextBox_X1.Text) && InputIsDouble(TextBox_Y1.Text) && InputIsDouble(TextBox_X2.Text) && InputIsDouble(TextBox_Y2.Text))
            {
                MathVect a = new MathVect(Convert.ToDouble(TextBox_X1.Text), Convert.ToDouble(TextBox_Y1.Text));
                MathVect b = new MathVect(Convert.ToDouble(TextBox_X2.Text), Convert.ToDouble(TextBox_Y2.Text));
                string result = "Скалярное произведение векторов = \n" + a * b;
                MessageBox.Show(result);
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");

        }

        private void Plus_Button_Click(object sender, EventArgs e)
        {
            if (InputIsDouble(TextBox_X1.Text) && InputIsDouble(TextBox_Y1.Text) && InputIsDouble(TextBox_X2.Text) && InputIsDouble(TextBox_Y2.Text))
            {
                MathVect a = new MathVect(Convert.ToDouble(TextBox_X1.Text), Convert.ToDouble(TextBox_Y1.Text));
                MathVect b = new MathVect(Convert.ToDouble(TextBox_X2.Text), Convert.ToDouble(TextBox_Y2.Text));
                MessageBox.Show("Результат -- вектор:\n" + (a + b));
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");

        }

        private void Minus_Button_Click(object sender, EventArgs e)
        {
            if (InputIsDouble(TextBox_X1.Text) && InputIsDouble(TextBox_Y1.Text) && InputIsDouble(TextBox_X2.Text) && InputIsDouble(TextBox_Y2.Text))
            {
                MathVect a = new MathVect(Convert.ToDouble(TextBox_X1.Text), Convert.ToDouble(TextBox_Y1.Text));
                MathVect b = new MathVect(Convert.ToDouble(TextBox_X2.Text), Convert.ToDouble(TextBox_Y2.Text));
                MessageBox.Show("Результат -- вектор:\n" + (a - b));
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");

        }

        private void Mult_Button_Click(object sender, EventArgs e)
        {
            if (InputIsDouble(TextBox_X1.Text) && InputIsDouble(TextBox_Y1.Text) && InputIsDouble(TextBox_N.Text))
            {
                MathVect a = new MathVect(Convert.ToDouble(TextBox_X1.Text), Convert.ToDouble(TextBox_Y1.Text));
                double b = Convert.ToDouble(TextBox_N.Text);
                MessageBox.Show("Основной вектор умноженный\nна введенное число:\n" + (a * b));
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");
        }

        private void Length_Button_Click(object sender, EventArgs e)
        {
            if (InputIsDouble(TextBox_X1.Text) && InputIsDouble(TextBox_Y1.Text))
            {
                MathVect a = new MathVect(Convert.ToDouble(TextBox_X1.Text), Convert.ToDouble(TextBox_Y1.Text));
                MessageBox.Show("Длина основного вектора:\n" + a.Length);
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");


        }

        private void Sort_Button_Click(object sender, EventArgs e)//Сортировка массива
        {
            if (InputIsDouble(TextBox_N.Text))
            {
                int n = (int)Convert.ToDouble(TextBox_N.Text);//Создаём массив заданной пользователем размерности
                if (n > 1000 || n <=0) { MessageBox.Show("Слишком большое либо слишком маленькое количество элементов массива, введите число большее, чем 0, но меньшее, чем 1000"); }
                else
                {//Массив будет заполняться случайными числами
                    Random rand = new Random();
                    MathVect[] vectors = new MathVect[n];
                    string result = "Исходный массив: ";//Сюда записывается текст, который содержит информацию о массиве до сортировки
                    for (int i = 0; i < n; i++)
                        vectors[i] = new MathVect(rand.Next(0, 5), rand.Next(0, 5));
                    for (int i = 0; i < n; i++)
                    {
                        result += (vectors[i] + " ");
                        if (i % 6 == 0)
                            result += "\n";
                    }
                    MessageBox.Show(result);
                    result = "Отсортированный массив: ";//Мы уже вывели исходный массив, теперь отсортируем его и вывелем в отсортированном виде
                    Array.Sort(vectors);
                    for (int i = 0; i < n; i++)
                    {
                        result += (vectors[i] + " ");
                        if (i % 6 == 0)
                            result += "\n";
                    }
                    MessageBox.Show(result);
                }
            }
            else
                MessageBox.Show("Ошибка ввода. Проверьте, что Вы ввели числа типа double или int и повторите попытку.");

        }
    }
}
