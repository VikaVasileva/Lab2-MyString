using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_string
{
    class MyString
    {
        char[] stroka;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //перегрузка стандартных операторов
        public static MyString operator +(MyString obj1, MyString obj2)
        {
            MyString stroka1 = new MyString(obj1.Length + obj2.Length);
            for (int i = 0; i < obj1.Length; i++)
                stroka1.stroka[i] = obj1.stroka[i];
            for (int i = 0; i < obj2.Length; i++)
                stroka1.stroka[i + obj1.Length] = obj2.stroka[i];
            return stroka1;
        }

        // операторы сравнения по алфавиту, старше строчка или младше
        public static bool operator >(MyString obj1, MyString obj2)
        {
            if ((obj1.stroka == null) && (obj2.stroka == null)) return false;
            if (obj1.stroka == null) return false;
            if (obj2.stroka == null) return true;
            int min;
            if (obj1.Length <= obj2.Length)
                min = obj1.Length;
            else min = obj2.Length;

            for (int i = 0; i < min; i++)
                if (obj1.stroka[i] != obj2.stroka[i])
                    if (obj1.stroka[i] > obj2.stroka[i]) return true;
                    else return false;

            return false;
        }

        public static bool operator <(MyString obj1, MyString obj2)
        {
            if ((obj1.stroka == null) && (obj2.stroka == null)) return false;
            if (obj1.stroka == null) return true;
            if (obj2.stroka == null) return false;
            int min;
            if (obj1.Length <= obj2.Length)
                min = obj1.Length;
            else min = obj2.Length;

            for (int i = 0; i < min; i++)
                if (obj1.stroka[i] != obj2.stroka[i])
                    if (obj1.stroka[i] > obj2.stroka[i]) return false;
                    else return true;

            return false;
        }

        public static bool operator >=(MyString obj1, MyString obj2)
        {
            if ((obj1.stroka == null) && (obj2.stroka == null)) return true;
            if (obj1.stroka == null) return false;
            if (obj2.stroka == null) return true;
            int min;
            if (obj1.Length <= obj2.Length)
                min = obj1.Length;
            else min = obj2.Length;

            for (int i = 0; i < min; i++)
                if (obj1.stroka[i] != obj2.stroka[i])
                    if (obj1.stroka[i] > obj2.stroka[i]) return true;
                    else return false;


            return true;
        }

        public static bool operator <=(MyString obj1, MyString obj2)
        {
            if ((obj1.stroka == null) && (obj2.stroka == null)) return true;
            if (obj1.stroka == null) return true;
            if (obj2.stroka == null) return false;
            int min;
            if (obj1.Length <= obj2.Length)
                min = obj1.Length;
            else min = obj2.Length;

            for (int i = 0; i < min; i++)
                if (obj1.stroka[i] != obj2.stroka[i])
                    if (obj1.stroka[i] > obj2.stroka[i]) return true;
                    else return false;

            return true;
        }

        public static bool operator ==(MyString obj1, MyString obj2)
        {
            if ((obj1.stroka == null) && (obj2.stroka == null)) return true;
            if (obj1.Length != obj2.Length)
                return false;
            else
            {
                for (int i = 0; i < obj1.Length; i++)
                    if (obj1.stroka[i] != obj1.stroka[i]) return false;
                return true;
            }
        }

        public static bool operator !=(MyString obj1, MyString obj2)
        {
            if (obj1 == obj2) return false;
            else return true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int length()
        {

            return this.stroka.Length;
        }

        //создание свойства Length для объекта класса MyString
        public int Length
        {
            get
            { return this.stroka.Length; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //конструкторы

        public MyString() //пустой конструктор
        {
            stroka = new char[0];
          
        }

        public MyString(String tmp) //конструктор преобразующий строку в наш тип
        {
            stroka = new char[tmp.Length];
            for (int i = 0; i < tmp.Length; i++)
                stroka[i] = tmp[i];
            
        }

        public MyString(char[] tmp) //конструктор преобразующий массив символов в наш тип
        {
            stroka = new char[tmp.Length];
            for (int i = 0; i < tmp.Length; i++)
                stroka[i] = tmp[i];
           
        }

        public MyString(MyString tmp) //конструктор копирования создающий копию объекта нашего типа
        {
            stroka = new char[tmp.Length];
            for (int i = 0; i < tmp.Length; i++)
                stroka[i] = tmp.stroka[i];
           
        }


        public MyString(int tmp) //конструктор создающий пустую строку нашего типа заданной длины
        {
            stroka = new char[tmp];

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //методы
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //1 группа методов - поиск
        public int Index(MyString s2) //поиск в строке  подстроки s2
        {
            int findindex = -1;
            if (stroka.Length >= s2.Length)
            {
                for (int i = 0; i < stroka.Length - s2.Length + 1; i++)
                {
                    for (int j = 0; j < s2.Length; j++)
                    {
                        if (stroka[i + j] != s2.stroka[j]) break;
                        if (j == s2.Length - 1) findindex = i;
                    }
                    if (findindex > -1) break;
                }
            }
            return findindex;
        }

        public int Index(MyString s2, int num) //поиск в строке  подстроки s2 начиная с элемента номер num
        {

            int findindex = -1;
            if (s2.Length + num <= stroka.Length)
            {
                if (stroka.Length >= s2.Length)
                {
                    for (int i = num; i < stroka.Length - s2.Length + 1; i++)
                    {
                        for (int j = 0; j < s2.Length; j++)
                        {
                            if (stroka[i + j] != s2.stroka[j]) break;
                            if (j == s2.Length - 1) findindex = i;
                        }
                        if (findindex > -1) break;
                    }
                }
            }
            return findindex;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //2 группа методов - замена
        public void Replacement(MyString s1, MyString s2)  // замена подстроки s1 на подстроку s2 в строке
        {
            if (s2.Length == s1.Length)
            {
                int findindex = 1;
                while (findindex != -1)
                {
                    findindex = -1;
                    if (stroka.Length >= s1.Length)
                    {
                        for (int i = 0; i < stroka.Length - s1.Length+1; i++)
                        {
                            for (int j = 0; j < s1.Length; j++)
                            {
                                if (stroka[i + j] != s1.stroka[j]) break;
                                if (j == s1.Length - 1) findindex = i;
                            }
                            if (findindex > -1) break;
                        }
                    }
                    if (findindex!=-1)
                    for (int j = 0; j < s1.Length; j++)
                        stroka[findindex + j] = s2.stroka[j];
                }
               // return true;
            }
            else throw new System.ArgumentException("MyString" + Environment.NewLine + "Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            // return false;

        }

        public void Replacement(MyString s1, int num)  // замена в строке подстроки начиная c num на подстроку s1
        {
            if (num + s1.Length <= stroka.Length)
            {
                for (int j = 0; j < s1.Length; j++)
                    stroka[num + j] = s1.stroka[j];
                //return true;
            }
            else throw new System.ArgumentException("MyString" + Environment.NewLine + "Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            //return false;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //3 группа методов - вырезать
        public void Cut(int num, int count) //вырезать из строки символы начиная с num количеством count
        {
            if (num + count <= stroka.Length)
            {
                MyString stroka_tmp = new MyString(stroka.Length - count);
                for (int i = 0; i < num; i++)
                    stroka_tmp.stroka[i] = stroka[i];

                for (int i = num + count; i < stroka.Length; i++)
                    stroka_tmp.stroka[i - count] = stroka[i];

                stroka = stroka_tmp.stroka;
               // return true;
            }
            else throw new System.ArgumentException("MyString" + Environment.NewLine + "Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            //return false;
        }

        public void Cut(MyString s2) //вырезать из строки все вхождения подстроки s2
        {
            if (s2.Length <= stroka.Length)
            {
                MyString stroka_tmp = new MyString();
                MyString stroka_tmp2 = new MyString();
                int findindex = 1, n = 0;
                while (findindex != -1)
                {
                    findindex = -1;
                    if (stroka.Length >= s2.Length)
                    {
                        for (int i = n; i < stroka.Length - s2.Length + 1; i++)
                        {
                            for (int j = 0; j < s2.Length; j++)
                            {
                                if (stroka[i + j] != s2.stroka[j]) break;
                                if (j == s2.Length - 1) findindex = i;
                            }
                            if (findindex > -1) break;
                        }
                    }
                    if (findindex > -1)
                    {
                        stroka_tmp2 = new MyString(findindex);
                        for (int i = 0; i < findindex; i++)
                            stroka_tmp2.stroka[i] = stroka[i];
                        n = findindex;

                        stroka_tmp = new MyString(this.Length-findindex-s2.Length);
                        for (int i = findindex + s2.Length; i < this.Length; i++)
                            stroka_tmp.stroka[i-findindex - s2.Length] = stroka[i];
                         stroka_tmp2 += stroka_tmp;
                         stroka = stroka_tmp2.stroka ;
                    }
                }
                
               // return true;
            }
            else throw new System.ArgumentException("MyString" + Environment.NewLine + "Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            //return false;
        }


        public void Cut(MyString s2, int num) //вырезать из строки все вхождения подстроки s2 начиная с символа с индексом num
        {
            if (s2.Length + num <= stroka.Length)
            {
                MyString stroka_tmp = new MyString();
                MyString stroka_tmp2 = new MyString();
                int findindex = 1, n = num;
                while (findindex != -1)
                {
                    findindex = -1;
                    if (stroka.Length >= s2.Length)
                    {
                        for (int i = n; i < stroka.Length - s2.Length + 1; i++)
                        {
                            for (int j = 0; j < s2.Length; j++)
                            {
                                if (stroka[i + j] != s2.stroka[j]) break;
                                if (j == s2.Length - 1) findindex = i;
                            }
                            if (findindex > -1) break;
                        }
                    }
                    if (findindex > -1)
                    {
                        stroka_tmp2 = new MyString(findindex);
                        for (int i = 0; i < findindex; i++)
                            stroka_tmp2.stroka[i] = stroka[i];
                        n = findindex;
                   /*     stroka_tmp += stroka_tmp2;
                        stroka = stroka_tmp.stroka;*/
                        stroka_tmp = new MyString(this.Length - findindex - s2.Length);
                        for (int i = findindex + s2.Length; i < this.Length; i++)
                            stroka_tmp.stroka[i - findindex - s2.Length] = stroka[i];
                        stroka_tmp2 += stroka_tmp;
                        stroka = stroka_tmp2.stroka;
                    }
                }
               
                //return true;
            }
            else throw new System.ArgumentException("MyString" + Environment.NewLine + "Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            //return false;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //4 группа методов - вставить

        public void Insert(MyString s1, int num) //Вставить в строку подстроку s1 начиная с символа с индексом num
        {
            MyString tmp1 = new MyString(this);
            MyString tmp2 = new MyString(this);
            tmp1.Clip(this.Length - num, false);
            tmp2.Clip( num, true);
            tmp1 = tmp1 + s1 + tmp2;
            this.stroka = tmp1.stroka;
        }

        public void Insert(MyString s1, bool place) //Вставить в строку подстроку s1 в начало (place == true) или в конец (place == false)
        {
            if (place == true)
            {
                s1 = s1 + this;
                this.stroka = s1.stroka;
            }
            else
            {
                s1 = this + s1;
                this.stroka = s1.stroka;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //5 группа методов - обрезать

        public void Clip(int count, bool place) //вырезать из строки count символов начиная с начала (place == true) или с конца (place == false)
        {
            if (Length >= count)
            {
                if (place == false)
                {
                    this.Cut(this.Length - count, count);
                }
                else
                {
                    MyString tmp = new MyString(this.Length - count);
                    for (int i = count; i < this.Length; i++)
                        tmp.stroka[i - count] = this.stroka[i];
                    this.stroka = tmp.stroka;
                }

              //  return true;
            }
            else throw new System.ArgumentException("MyString" + Environment.NewLine + "Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            // return false;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //6 группа методов - получить подстроку

        public MyString Substring(int count) //вернуть первые count символов строки в виде новой строки
        {
            if (count > this.Length) throw new System.ArgumentException("MyString" + Environment.NewLine + "Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            MyString tmp = new MyString(count);
            for (int i = 0; i < count; i++)
                tmp.stroka[i] = this.stroka[i];
            return tmp;
        }

        public MyString Substring(int count, int num) //вернуть count символов строки начиная с num в виде новой строки
        {
            if (count + num >= this.Length) throw new System.ArgumentException("MyString"+Environment.NewLine+"Строка короче, чем требуется для введённых параметров!"); //создание исключения в случае ошибки
            MyString tmp = new MyString(this.Length - count);
            for (int i = 0; i < count; i++)
                tmp.stroka[i] = this.stroka[i + num];
            return tmp;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //перегрузки операций преобразования типов

        //неявные преобразования
        public static implicit operator String(MyString v) //в строку
        {
            return new string(v.stroka);
        }

        public static implicit operator MyString(String v) //из строки
        {

            return new MyString(v);
        }

        public static implicit operator char[](MyString v) //в массив чар
        {
            return v.stroka;
        }

        public static implicit operator MyString(char[] v) //из массива чар
        {
            return new MyString(v);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //явные преобразования
        public static explicit operator int(MyString v) //в целое число
        {
            return Convert.ToInt32(v.stroka);
        }

        public static explicit operator MyString(int v) //из целого числа
        {
            return new MyString(v.ToString());
        }

        public static explicit operator Double(MyString v) // в вещественное число
        {
            return Convert.ToDouble(v.stroka);
        }

        public static explicit operator MyString(Double v) //из вещественного числа
        {
            return new MyString(v.ToString());
        }


    }
}
