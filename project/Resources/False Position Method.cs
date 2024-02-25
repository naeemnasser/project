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
    public partial class FalsePosition : Form
    {
        double xr = 0;
        double xrold;
        public FalsePosition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FalsePosition_Load(object sender, EventArgs e)
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
           // return Math.Pow(x, 3) + x - 1;
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
                do
                {
                    xrold = xr;
                    xr = xu - ((F(xu) * (xl - xu)) / (F(xl) - F(xu)));

                    errorx = Math.Abs((xr - xrold) / xr) * 100;
                    FPositionDGV.Rows.Add(i, xl, F(xl), xr, F(xr), xu, F(xu), errorx);
                    if (F(xr) == 0.0)
                        break;

                    iter(ref xl, ref  xu);

                    i++;
                } while (errorx >= E);
                FPositionDGV.Rows.Add(i, xl, F(xl), xr, F(xr), xu, F(xu), errorx);
                label4.Text = xr.ToString();
                label7.Text = errorx.ToString();
            }
            catch (Exception q)
            {

                MessageBox.Show(q.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Xlt.Clear(); error.Clear(); Xut.Clear();
            label4.Text = null;
            label7.Text = null;
            textBox1.Clear();
            FPositionDGV.Rows.Clear();
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
    }
}
