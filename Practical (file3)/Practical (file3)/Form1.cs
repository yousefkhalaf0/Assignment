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

namespace Practical__file3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileStream fs;//
        StreamReader sr;//
        StreamWriter sw;//
        SortedDictionary<int, int> dic = new SortedDictionary<int, int>();//
        private void button1_Click(object sender, EventArgs e)//open
        {
            fs = new FileStream("test1.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            sr = new StreamReader(fs);
            sw = new StreamWriter(fs);
            MessageBox.Show("opened");
        }

        private void button2_Click(object sender, EventArgs e)//load index file to dic(MM)
        {
            dic.Clear();
            textBox4.Text = "Key\tLoc\r\n";
            if (File.Exists("index.txt"));
            {
                StreamReader isr = new StreamReader("index.txt");//key|loc
                string line;
                while ((line = isr.ReadLine()) != null)
                {
                    string[] arr = line.Split('|');
                    dic.Add(int.Parse(arr[0]), int.Parse(arr[1]));
                    textBox4.Text += arr[0] + "\t" + arr[1] + "\r\n";
                }
                isr.Close();
                MessageBox.Show("index file is loaded");
            }
        }

        private void button3_Click(object sender, EventArgs e)//insert
        {
            fs.Seek(0, SeekOrigin.End);
            int L = Convert.ToInt16(fs.Position);
            sw.WriteLine(textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text);
            sw.Flush();
            dic.Add(int.Parse(textBox1.Text), L);
            MessageBox.Show("inserted");
        }

        private void button6_Click(object sender, EventArgs e)//rewrite means save dic to index file
        {
            StreamWriter ws = new StreamWriter("index.txt");
            foreach (KeyValuePair<int,int> item in dic)
            {
                ws.WriteLine(item.Key + "|" + item.Value);
                ws.Flush();
            }
            ws.Close();
            MessageBox.Show("rewrite done");
        }

        public bool BS(int[] arr,int K)//binary search
        {
            int f = 0, L = arr.Length - 1;
            int mid = (f + L) / 2;
            while (f <= L)
            {
                mid = (f + L) / 2;
                if (K < arr[mid])
                {
                    L = mid - 1;
                }
                else if (K > arr[mid])
                {
                    f = mid + 1;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        private void button4_Click(object sender, EventArgs e)//search
        {
            sr.DiscardBufferedData();
            int[] arr = dic.Keys.ToArray();
            if (BS(arr,int.Parse(textBox1.Text)));
            {
                int loc = dic[int.Parse(textBox1.Text)];
                fs.Seek(loc, SeekOrigin.Begin);
                string line = sr.ReadLine();
                string[] arr1 = line.Split('|');
                textBox2.Text = arr1[1];
                textBox3.Text = arr1[2];
                return;
            }
            textBox2.Text = textBox3.Text = "N F";
        }

        private void button5_Click(object sender, EventArgs e)//delete
        {
            sr.DiscardBufferedData();
            int[] arr = dic.Keys.ToArray();
            if (BS(arr, int.Parse(textBox1.Text))) ;
            {
                int loc = dic[int.Parse(textBox1.Text)];
                fs.Seek(loc, SeekOrigin.Begin);
                sw.Write("*");
                sw.Flush();
                dic.Remove(int.Parse(textBox1.Text));
                MessageBox.Show("done");
                return;
            }
            textBox2.Text = textBox3.Text = "N F";
        }

        private void button7_Click(object sender, EventArgs e)//clear
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)//close
        {
            sw.Close();
            sr.Close();
            fs.Close();
            Dispose();
        }
    }
}
