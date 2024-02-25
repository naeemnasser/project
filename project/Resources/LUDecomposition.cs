using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Resources
{
    public partial class LUDecomposition : Form
    {
        double m21 = 0, m31 = 0, m32 = 0;
        double[,] a = new double[3, 4];
        public LUDecomposition()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            Home b = new Home();
            this.Close();
            b.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
        void gauss()
        {
          a[0,0]= Convert.ToDouble((_11.Text));a[0,1]=Convert.ToDouble((_12.Text));a[0,2]=Convert.ToDouble((_13.Text));a[0,3]=Convert.ToDouble((_14.Text));
          a[1,0]= Convert.ToDouble((_21.Text));a[1,1]=Convert.ToDouble((_22.Text));a[1,2]=Convert.ToDouble((_23.Text));a[1,3]=Convert.ToDouble((_24.Text));
            a[2,0]= Convert.ToDouble((_31.Text));a[2,1]=Convert.ToDouble((_32.Text));a[2,2]=Convert.ToDouble((_33.Text));a[2,3]=Convert.ToDouble((_34.Text));


            
            m21 = a[1,0] / a[0,0]; 
            m31 = a[2,0] / a[0,0];
           
            for (int j = 0; j < 4; j++)
            {
                double e2 = a[1,j];
                double e1 = ((m21) * a[0,j]);
                a[1,j] = e2 - e1;
            }

           
            for (int j = 0; j < 4; j++)
            {
                double e3 = a[2,j];
                double e1 = ((m31) * a[0,j]);
                a[2,j] = e3 - e1;
            }
            m32 = a[2, 1] / a[1, 1];
            for (int j = 0; j < 4; j++)
            {
                double e3 = a[2,j];
                double e1 = ((m32) * a[1,j]);
                a[2,j] = e3 - e1;
            }
           
        
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                double[,] u = new double[3, 3]; double[,] l = new double[3, 3]; double[] b = new double[3];
                b[0] = Convert.ToDouble((_14.Text));
                b[1] = Convert.ToDouble((_24.Text));
                b[2] = Convert.ToDouble((_34.Text));
                gauss();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        u[i, j] = a[i, j];
                    }
                }
                textBox1.Text = u[2, 2].ToString(); textBox2.Text = u[1, 2].ToString(); textBox3.Text = u[0, 2].ToString();
                textBox4.Text = u[2, 1].ToString(); textBox5.Text = u[1, 1].ToString(); textBox6.Text = u[0, 1].ToString();
                textBox7.Text = u[2, 0].ToString(); textBox8.Text = u[1, 0].ToString(); textBox9.Text = u[0, 0].ToString();
                l[0, 1] = 0;
                l[0, 2] = 0;
                l[1, 2] = 0;

                l[0, 0] = 1;
                l[1, 1] = 1;
                l[2, 2] = 1;
                l[1, 0] = m21;
                l[2, 0] = m31;
                l[2, 1] = m32;
                textBox10.Text = l[2, 2].ToString(); textBox11.Text = l[1, 2].ToString(); textBox12.Text = l[0, 2].ToString();
                textBox13.Text = l[2, 1].ToString(); textBox14.Text = l[1, 1].ToString(); textBox15.Text = l[0, 1].ToString();
                textBox16.Text = l[2, 0].ToString(); textBox17.Text = l[1, 0].ToString(); textBox18.Text = l[0, 0].ToString();
                double c1 = b[0] / l[0, 0];
                double c2 = (b[1] - (l[1, 0] * c1)) / l[1, 1];
                double c3 = (b[2] - ((l[2, 0] * c1) + (l[2, 1] * c2))) / l[2, 2];
                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        a[i, j] = u[i, j];
                    }
                }

                a[1, 3] = c2;
                a[0, 3] = c1;
                a[2, 3] = c3;
                double x3 = a[2, 3] / a[2, 2];
                double x2 = (a[1, 3] - (a[1, 2] * x3)) / a[1, 1];
                double x1 = (a[0, 3] - ((a[0, 1] * x2) + (a[0, 2] * x3))) / a[0, 0];

                label2.Text += x1.ToString();
                label4.Text += x2.ToString();
                label7.Text += x3.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("invalid value ");
            }

        }

        private void LUDecomposition_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _11.Clear(); _12.Clear(); _13.Clear(); _14.Clear();
            _21.Clear(); _22.Clear(); _23.Clear(); _24.Clear();
            _31.Clear(); _32.Clear(); _33.Clear(); _34.Clear();
            label2.Text = null; label4.Text = null; label7.Text = null;
            textBox10.Clear(); textBox11.Clear(); textBox12.Clear();
            textBox13.Clear(); textBox14.Clear(); textBox15.Clear();
            textBox16.Clear(); textBox17.Clear(); textBox18.Clear();

            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            textBox7.Clear(); textBox8.Clear(); textBox9.Clear();
           

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            //foreach (Control item in LUDecompositio)
           
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void _11_TextChanged(object sender, EventArgs e)
        {

        }

        private void _12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
