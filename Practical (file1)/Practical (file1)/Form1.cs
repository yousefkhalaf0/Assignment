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

namespace Practical__file1_
{
    public partial class Form1 : Form
    {
        FileStream filecopy;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//file read from
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)//file write to
        {
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.Cancel)
                return;
            textBox2.Text = saveFileDialog1.FileName;
            filecopy = new FileStream(textBox2.Text, FileMode.Create, FileAccess.Write);
        }

        private void button3_Click(object sender, EventArgs e)//copy data from file1 to file2
        {
            StreamReader sr = new StreamReader(textBox1.Text);
            StreamWriter sw = new StreamWriter(filecopy);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sw.WriteLine(line);
                textBox3.Text += line;
            }
            sr.Close();
            sw.Close();
            filecopy.Close();
        }
    }
}
