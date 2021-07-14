using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Fit_Decreasing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            int boxsize = Convert.ToInt32(textBox2.Text);
            FFD.FirstFitDecreasingAlgorithm(str, boxsize);
            listBox1.Items.Add("Gereken kutu sayısı: " + FFD.requiredBox);
            listBox1.Items.Add("\n");
            for (int i = 0; i < FFD.numbers.Length; i++)
            {
                listBox1.Items.Add(FFD.numbers[i] + " elemanı:  " + (FFD.boxNumber[i] + 1) + ". kutuya");
            }
            listBox1.Items.Add("\n");
            listBox1.Items.Add("Yerleştirilmiştir.");
        }
    }
}
