using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Fanuta_Adrian_Text_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "Text File|*.txt";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "Text File|*.txt";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;
            String reverse = "";
            for (int i = str.Length - 1; i >= 0; i--)
                reverse += str[i];
            textBox1.Text = reverse;
        }

        private void reverseOrderOfWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strg = textBox1.Text;
            String[] strArr = strg.Split(' ');
            String str = "";
            String result = "";
            for (int i = 0; i < strArr.Length; i++)
            {
                str = strArr[i] + " " + str;
            }
            result = str.Substring(0, str.Length - 1);
            textBox1.Text = result;
        }

        private void reverseEveryWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;
            String[] strArr = str.Split(' ');
            String strg = "";
            for (int i = 0; i < strArr.Length; i++)
            {
                for (int j = strArr[i].Length - 1; j >= 0; j--)
                {
                    strg = strg + strArr[i][j];
                }
                strg += " ";
            }
            textBox1.Text = strg;
        }

        private void appearenceOfLettersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;
            str = str.ToLower();
            int count = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (i == str[j])
                    {
                        count++;
                    }
                }
                if(count!=0)
                    textBox1.Text+=("  \"" + i + "\" apare de " + count + " ori, ");
                count = 0;
            }
        }

        private void literaMicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strg = textBox1.Text;
            strg = strg.ToLower();
            textBox1.Text = strg;
        }

        private void literaMareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strg = textBox1.Text;
            strg = strg.ToUpper();
            textBox1.Text = strg;
        }

        private void fiecareCuvantLiteraMareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String phrase = textBox1.Text;
            String new_phrase = "";
            for (int i = 0; i < phrase.Length; i++)
            {
                if (i != 0)
                {
                    if (phrase[i - 1] == ' ')
                    {
                        new_phrase = new_phrase + char.ToUpper(phrase[i]);
                    }
                    else new_phrase = new_phrase + phrase[i];
                }
            }
            new_phrase = char.ToUpper(phrase[0]) + new_phrase;

            textBox1.Text = new_phrase;
        }

        private void numarulDeCuvinteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String phrase = textBox1.Text;
            int count = 1;
            for (int i = 1; i < phrase.Length; i++)
            {
                if (phrase[i - 1] == ' ') count++;
            }
            String wordsNum = $"    Sunt {count} cuvinte in acest string.";
            textBox1.Text += wordsNum;
        }
    }
}
