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

namespace Practical__File_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//browsing for the file(openning)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)//read line by line
        {
            StreamReader sr = new StreamReader(textBox1.Text);
            string line;
            while ( (line = sr.ReadLine()) != null )
            {
                textBox2.Text += line + "\r\n";
            }
            sr.Close();
        }

        private void button5_Click(object sender, EventArgs e)//read odd lines in file
        {
            StreamReader sr = new StreamReader(textBox1.Text);
            string line;
            int countlines = 0;
            while ((line = sr.ReadLine()) != null)
            {
                countlines++;
                if (countlines % 2 != 0)
                {
                    textBox3.Text += line + "\r\n";
                }
            }
            sr.Close();
        }

        private void button7_Click(object sender, EventArgs e)//read even lines in file
        {
            StreamReader sr = new StreamReader(textBox1.Text);
            string line;
            int countlines = 0;
            while ((line = sr.ReadLine()) != null)
            {
                countlines++;
                if (countlines % 2 == 0)
                {
                    textBox4.Text += line + "\r\n";
                }
            }
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)//count lines in file
        {
            StreamReader sr = new StreamReader(textBox1.Text);
            string line;
            int countline = 0;
            while ((line = sr.ReadLine()) != null)
            {
                countline++;
            }
            textBox5.Text = countline.ToString();
            sr.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//count characters in file
        {
            string file = new StreamReader(textBox1.Text).ReadToEnd();
            int charcount = file.Length;
            textBox6.Text = charcount.ToString();
        }

        private void button6_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
