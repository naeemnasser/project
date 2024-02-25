using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Z.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Resources
{
    public partial class Bisection : Form
    {

        double xr = 0;
        public Bisection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Bisection_Load(object sender, EventArgs e)
        {

        }
        double F(double xz)
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
        }
        void iter(ref double x, ref double y)
        {
            if (F(x) * F(xr) < 0.0)
            {
                y = xr;
            }
            else
            {
                x = xr;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double E = Convert.ToDouble(error.Text.ToString());
                double errorx = 0, xl = Convert.ToDouble(Xlt.Text.ToString()), xu = Convert.ToDouble(Xut.Text.ToString());
                int i = 0;
                double xrold;
                do
                {
                    xrold = xr;
                    xr = (xl + xu) / 2;

                    if (F(xr) == 0.0)
                        break;

                    bisectionDGV.Rows.Add(i, xl, F(xl), xr, F(xr), xu, F(xu), errorx);
                    iter(ref xl, ref  xu);
                    
                    errorx = Math.Abs((xr - xrold)/xr) * 100;
                    i++;
                } while (errorx >= E);
                bisectionDGV.Rows.Add(i, xl, F(xl), xr, F(xr), xu, F(xu), errorx);
                label4.Text = xr.ToString();
                label7.Text = errorx.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("invalid value ");
            }

        }


        
        private void button4_Click(object sender, EventArgs e)
        {
            Home b = new Home();
            this.Close();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Xlt.Clear(); error.Clear(); Xut.Clear();
            label4.Text = null;
            label7.Text = null;
            textBox1.Clear();
            bisectionDGV.Rows.Clear();
        }

        private void Xut_TextChanged(object sender, EventArgs e)
        {

        }

        private void bisectionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
                    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Xlt_TextChanged(object sender, EventArgs e)
        {

        }

        private void error_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

