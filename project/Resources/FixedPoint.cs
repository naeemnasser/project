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
    public partial class FixedPoint : Form
    {

        public FixedPoint()
        {
            InitializeComponent();
        }

       

        private void FixedPoint_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                double E = Convert.ToDouble(error.Text.ToString());
                double errorx = 0, x = Convert.ToDouble(Xi.Text.ToString()), rootx = 0;
                int i = 0;
                do
                {

                    FixedDGV.Rows.Add(i, x, f(x), errorx);
                    errorx = Math.Abs(f(x) - x) * 100;


                    x = f(x);
                    rootx = x;
                    i++;
                } while (errorx > E);
                FixedDGV.Rows.Add(i, x, f(x), errorx);
                label4.Text = rootx.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("invalid value ");
            }

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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FixedDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


            if (e.Control is TextBox) //If it is a DataGridViewTextBoxCell
            {

                (e.Control as TextBox).MaxLength = 4; //Set the MaxLength to 4

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Xi.Clear(); error.Clear();
            label4.Text = null;
            textBox1.Clear();
            FixedDGV.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home b = new Home();
            this.Close();
            b.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}