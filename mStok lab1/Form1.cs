using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mStok_lab1
{
    public partial class Form1 : Form
    {
        private char[] dict;
        private char[] dictOut;
        private string keyValue;
        private int keyInt;
        private char[] dictEn = new char[52]
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };
        private char[] dictRu = new char[66]
        {
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я',
            'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я'
        };
        public Form1()
        {
            InitializeComponent();
            

        }

       private void getDict()
        {
            keyValue = textBox1.Text.ToString();
            keyInt = Convert.ToInt32(textBox2.Text.ToString());

            if (radioButton1.Checked)
            {
                dict = new char[52];
                dictOut = new char[52];
                Array.Copy(dictEn, dict, dictEn.Length);
            } else
            {
                dict = new char[66];
                dictOut = new char[66];
                Array.Copy(dictRu, dict, dictRu.Length);
            }

            for (int i = 0; i < dictOut.Length; i++)
            {
                dictOut[i] = '0';
            }

            keyValue = new string(keyValue.Replace(" ", "").Distinct().ToArray()); //удаляем пробелы из ключевого слова и повторение символов

            for (int i = 0; i < keyValue.Length; i++)
            {
                dictOut[i + keyInt] = keyValue[i];
            }

            int j = keyValue.Length + keyInt;
            foreach (char ch in dict)
            {
                if (j >= dictOut.Length)
                {
                    if (Array.IndexOf(dictOut, ch) == -1)
                    {
                        dictOut[j - dictOut.Length] = ch;
                        j++;
                    }
                }
                else
                {
                    if (Array.IndexOf(dictOut, ch) == -1)
                    {
                        dictOut[j] = ch;
                        j++;
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getDict();
            string strIn = textBox3.Text.ToString();
            string strOut = "";
            foreach(char ch in strIn)
            {
                if (Array.IndexOf(dict, ch) != -1)
                {
                    strOut += dictOut[Array.IndexOf(dict, ch)];
                } else
                {
                    strOut += ch;
                }
            }

            textBox4.Text = strOut;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getDict();
            string strIn = textBox5.Text.ToString();
            string strOut = "";
            foreach (char ch in strIn)
            {
                if (Array.IndexOf(dictOut, ch) != -1)
                {
                    strOut += dict[Array.IndexOf(dictOut, ch)];
                }
                else
                {
                    strOut += ch;
                }
            }

            textBox6.Text = strOut;
        }
    }
}
