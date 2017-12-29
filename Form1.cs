using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_string
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            MyString str1, str2, str3;
            richTextBox1.Clear();
            if (comboBox1.SelectedIndex>=0)
                switch (comboBox1.SelectedIndex)
                {
                    //пустой конструктор
                    case 0:
                        MyString my1 = new MyString();
                        MessageBox.Show("Создан пустой объект класса MyString конструктором без параметров");
                        break;
                    //конструктор преобразующий строку в наш тип
                    case 1:
                        MyString my2 = new MyString(textBox1.Text);
                        MessageBox.Show("Создан объект класса MyString параметрическим конструктором принимающим тип String");
                        break;
                    //конструктор преобразующий массив символов в наш тип
                    case 2:
                        MyString my3 = new MyString(textBox1.Text.ToCharArray());
                        MessageBox.Show("Создан объект класса MyString параметрическим конструктором принимающим тип char[]");
                        break;
                    //конструктор копирования создающий копию объекта нашего типа
                    case 3:
                        my3 = new MyString(textBox1.Text.ToCharArray());
                        MyString my4 = new MyString(my3);
                        MessageBox.Show("Создан объект класса MyString параметрическим конструктором копирования принимающим тип MyString");
                        break;
                    //конструктор создающий пустую строку нашего типа заданной длины
                    case 4:
                        MyString my5 = new MyString(7);
                        MessageBox.Show("Создан пустой объект со строкой заданной длины класса MyString параметрическим конструктором принимающим количество символов в строке");
                        break;
                    //перегрузка стандартного оператора +
                    case 5:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        richTextBox1.Text = str1 + str2;
                        break;
                    //перегрузка стандартного оператора >
                    case 6:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        if (str1 > str2) richTextBox1.Text = "Верно";
                        else richTextBox1.Text = "Не верно";
                        break;
                    //перегрузка стандартного оператора <
                    case 7:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        if (str1 < str2) richTextBox1.Text = "Верно";
                        else richTextBox1.Text = "Не верно";
                        break;
                    //перегрузка стандартного оператора >=
                    case 8:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        if (str1 >= str2) richTextBox1.Text = "Верно";
                        else richTextBox1.Text = "Не верно";
                        break;
                    //перегрузка стандартного оператора <=
                    case 9:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        if (str1 <= str2) richTextBox1.Text = "Верно";
                        else richTextBox1.Text = "Не верно";
                        break;
                    //перегрузка стандартного оператора ==
                    case 10:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        if (str1 == str2) richTextBox1.Text = "Верно";
                        else richTextBox1.Text = "Не верно";
                        break;
                    //перегрузка стандартного оператора !=
                    case 11:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        if (str1 != str2) richTextBox1.Text = "Верно";
                        else richTextBox1.Text = "Не верно";
                        break;
                    //свойство Length для объекта
                    case 12:
                        str1 = new MyString(textBox1.Text);
                        richTextBox1.Text = str1.Length.ToString();
                        break;
                    //поиск в строке подстроки s1
                    case 13:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        richTextBox1.Text = (str1.Index(str2)).ToString();
                        break;
                    //поиск в строке  подстроки начиная с элемента номер num
                    case 14:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        richTextBox1.Text = (str1.Index(str2,Convert.ToInt32(textBox4.Text))).ToString();
                        break;
                    //замена подстроки s1 на подстроку s2 в строке
                    case 15:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        str3 = new MyString(textBox3.Text);
                        str1.Replacement(str2,str3);
                        richTextBox1.Text = str1;
                        break;
                    //замена в строке подстроки начиная c num на подстроку 
                    case 16:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        str1.Replacement(str2, Convert.ToInt32(textBox4.Text));
                        richTextBox1.Text = str1;
                        break;
                    //вырезать из строки символы начиная с num количеством count
                    case 17:
                        str1 = new MyString(textBox1.Text);
                        str1.Cut(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                        richTextBox1.Text = str1;
                        break;
                    //вырезать из строки все вхождения подстроки 
                    case 18:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        str1.Cut(str2);
                        richTextBox1.Text = str1;
                        break;
                    //вырезать из строки все вхождения подстроки s2 начиная с символа с индексом num
                    case 19:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        str1.Cut(str2,Convert.ToInt32(textBox4.Text));
                        richTextBox1.Text = str1;
                        break;
                    //Вставить в строку подстроку s1 начиная с символа с индексом num
                    case 20:
                        str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        str1.Insert(str2, Convert.ToInt32(textBox4.Text));
                        richTextBox1.Text = str1;
                        break;
                    //Вставить в строку подстроку s1 в начало (place == true) или в конец (place == false)
                    case 21:
                         str1 = new MyString(textBox1.Text);
                        str2 = new MyString(textBox2.Text);
                        str1.Insert(str2, checkBox1.Checked);
                        richTextBox1.Text = str1;
                        break;
                    //вырезать из строки count символов начиная с начала (place == true) или с конца (place == false)
                    case 22:
                        str1 = new MyString(textBox1.Text);
                        str1.Clip(Convert.ToInt32(textBox5.Text), checkBox1.Checked);
                        richTextBox1.Text = str1;
                        break;
                    //вернуть первые count символов строки в виде новой строки
                    case 23:
                        str1 = new MyString(textBox1.Text);
                        richTextBox1.Text = str1.Substring(Convert.ToInt32(textBox5.Text));
                        break;
                    //вернуть count символов строки начиная с num в виде новой строки
                    case 24:
                        str1 = new MyString(textBox1.Text);
                        richTextBox1.Text = str1.Substring(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox4.Text));
                        break;
                    //преобразования типов
                    case 25:
                        str1 = textBox1.Text; //неявное преобразование строки в наш тип
                        int chislo = (int)str1; //явное преобразование нашего типа в целое число
                        richTextBox1.Text = chislo.ToString();
                        break;
                    
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message , "MyString", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if (checkBox1.Checked)  checkBox1.Text = "начало строки";
           else checkBox1.Text = "конец строки";
        }
    }
}
