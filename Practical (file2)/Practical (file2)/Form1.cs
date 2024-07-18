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

namespace Practical__file2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            FileStream fs = new FileStream(textBox2.Text, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            StreamWriter sw = new StreamWriter(fs);
            string line;
            string[] ar;
            Boolean found = false;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                ar = line.Split(',');
                if (ar[0] == textBox1.Text)
                {
                    found = true;
                    fs.Seek(count, SeekOrigin.Begin);
                    fs.Flush();
                    sw.Write("*");
                    sw.Flush();
                }
                count += line.Length + 2;
            }
            if (found == false)
            {
                MessageBox.Show("not found");
                sr.Close();
                fs.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)//(openning file)
        {
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)//squeeze
        {
            StreamReader sr = new StreamReader(textBox2.Text);
            FileStream fs1 = new FileStream("E:\\sq1.txt",FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] != '*')
                {
                    sw.WriteLine(line);
                    sw.Flush();
                }
            }
            sr.Close();
            fs1.Close();
        }

        private void button6_Click(object sender, EventArgs e)//show all
        {
            StreamReader sr = new StreamReader(textBox2.Text);
            textBox7.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void button4_Click(object sender, EventArgs e)//insert
        {
            FileStream file = new FileStream(textBox2.Text,FileMode.Append,FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            string s = textBox3.Text + "," + textBox4.Text;
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            MessageBox.Show("inserted");
        }

        private void button5_Click(object sender, EventArgs e)//search by id
        {
            StreamReader sr = new StreamReader(textBox2.Text);
            string line;
            string[] ar;
            Boolean found = false;
            while ((line = sr.ReadLine()) != null)
            {
                ar = line.Split(',');
                if (ar[0] == textBox5.Text)
                {
                    found = true;
                    textBox6.Text = ar[1];
                }
            }
            if (found == false)
            {
                MessageBox.Show("not found!");
            }
            sr.Close();
        }
    }
}
