using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Expressions;
using MetroFramework;
using System.Windows.Forms;

namespace project.Resources
{
    public partial class NewtonMethod : Form
    {
        public NewtonMethod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
        double f(double xz)
        {
            try
            {
                string w = textBox1.Text; double result;
                result = Eval.Execute<double>(textBox1.Text.ToString(), new { x = xz });
                return (result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0.0d;
            }
           // return (-(Math.Pow(x, 2)) + 1.8 * x + 2.5);
        }
        double fDash(double xz)
        {

            try
            {
                string w = textBox1.Text; double result;
                result = Eval.Execute<double>(textBox2.Text.ToString(), new { x = xz });
                return (result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0.0d;
            }
           
            //return (-2 * x + 1.8);
        }

        private void button2_Click(object sender, EventArgs e)
         {
             try
             {
                 double E = Convert.ToDouble(error.Text.ToString());
                 double errorx = 0, x = Convert.ToDouble(Xi.Text.ToString()), rootx = 0, xnew;
                 int i = 0;
                 do
                 {
                     xnew = x - (f(x) / fDash(x));
                     errorx = (Math.Abs((xnew - x)/xnew) * 100);
                     newtonDGV.Rows.Add(i, x, f(x), fDash(x), xnew, errorx);
                     rootx = x;
                     x = xnew;
                     i++;
                 } while (errorx > E);
                 label4.Text = rootx.ToString();
             }
             catch (Exception)
             {

                 MessageBox.Show("invalid value ");
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Xi.Clear(); error.Clear();
            label4.Text = null;
            textBox1.Clear();
            textBox2.Clear();
            newtonDGV.Rows.Clear();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home b = new Home();
            this.Close();
            b.Show();
        }

        private void error_TextChanged(object sender, EventArgs e)
        {

        }

        private void Xi_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewtonMethod_Load(object sender, EventArgs e)
        {

        }
    }
}
