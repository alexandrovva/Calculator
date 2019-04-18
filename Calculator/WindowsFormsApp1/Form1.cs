using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int action = 0;
        float x1, x2;
        float memory = 0;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void number_clicked(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();

            Button btn = sender as Button;
            textBox1.Text += btn.Text;   
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            x1 = 0;
            x2 = 0;
            action = 0;
        }

        private void operations(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "+":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        action = 1;
                        break;
                case "-":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        action = 2;
                        break;
                case "*":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        action = 3;
                        break;
                case "/":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        action = 4;
                        break;
                case "1/x":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        if (x1 == 0)
                        {
                            MessageBox.Show("ERROR");
                            textBox1.Clear();
                        }
                        else
                            textBox1.Text = Convert.ToString(1 / x1);
                        break;
                case "^":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        action = 5;
                        break;
                case "sqrt":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        if (x1 < 0)
                        {
                            MessageBox.Show("ERROR");
                            textBox1.Clear();
                        }
                        else
                            textBox1.Text = Convert.ToString(Math.Sqrt(x1));
                        break;
                case "%":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        action = 6;
                        break;
                case "Cos":
                        x1 = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        textBox1.Text = Convert.ToString(Math.Cos((x1 * 180) / Math.PI));
                        break;
            }
        }

        private void floating_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void back_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
                textBox1.Text += text[i];
        }

        public void memory_clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "MC":
                            memory = 0;
                            break;
                case "MR":
                            if (x1 == 0)
                            {
                                x1 = memory;
                                textBox1.Text = Convert.ToString(x1);
                            }
                            else
                                textBox1.Text = Convert.ToString(memory);
                            break;
                case "MS":
                            x1 = float.Parse(textBox1.Text);
                            memory = x1;
                            x1 = 0;
                            break;
                case "M+":
                            x1 = float.Parse(textBox1.Text);
                            textBox1.Clear();
                            textBox1.Text = Convert.ToString(memory + x1);
                            break;
                case "M-":
                            x1 = float.Parse(textBox1.Text);
                            textBox1.Clear();
                            textBox1.Text = Convert.ToString(memory - x1);
                            break;
            }
        }

        private void result_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case 1:
                        x2 = x1 + float.Parse(textBox1.Text);
                        textBox1.Clear();
                        textBox1.Text = Convert.ToString(x2);
                        break;
                case 2:
                        x2 = x1 - float.Parse(textBox1.Text);
                        textBox1.Clear();
                        textBox1.Text = Convert.ToString(x2);
                        break;
                case 3:
                        x2 = x1 * float.Parse(textBox1.Text);
                        textBox1.Clear();
                        textBox1.Text = Convert.ToString(x2);
                        break;
                case 4:
                        x2 = x1 / float.Parse(textBox1.Text);
                        textBox1.Clear();
                        if (x2 == 0)
                        {
                            MessageBox.Show("ERROR");
                            textBox1.Clear();
                        }
                        else
                            textBox1.Text = Convert.ToString(x2);
                            break;
                case 5:
                        x2 = int.Parse(textBox1.Text);
                        for (int i = 1; i < x2; i++)
                            x1 *= x1;
                        textBox1.Clear();
                        textBox1.Text = Convert.ToString(x1);
                        break;
                case 6:
                        x2 = int.Parse(textBox1.Text);
                        textBox1.Text = Convert.ToString(x2*x1/100);
                        break;
            }
                x1 = 0;
                x2 = 0;
                action = 0;
        }

    }
}
