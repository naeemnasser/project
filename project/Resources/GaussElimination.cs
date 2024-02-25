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
    public partial class GaussElimination : Form
    {
        double m21=0, m31=0, m32=0 ;
        public GaussElimination()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home b = new Home();
            this.Close();
            b.Show();
        }

        private void GaussElimination_Load(object sender, EventArgs e)
        {

        }

       




        public void tryx(object sender, EventArgs e)
        {
            try
            {
                double[,] a = new double[3, 4] {
             {Convert.ToDouble((_11.Text)), Convert.ToDouble((_12.Text)), Convert.ToDouble((_13.Text)), Convert.ToDouble((_14.Text))} ,   
          {Convert.ToDouble((_21.Text)),Convert.ToDouble((_22.Text)),Convert.ToDouble((_23.Text)),Convert.ToDouble((_24.Text))} ,   
         {Convert.ToDouble((_31.Text)), Convert.ToDouble((_32.Text)),Convert.ToDouble((_33.Text)),Convert.ToDouble((_34.Text))}  
        };
                m21 = a[1, 0] / a[0, 0];
                m31 = a[2, 0] / a[0, 0];

                for (int j = 0; j < 4; j++)
                {
                    double e2 = a[1, j];
                    double e1 = ((m21) * a[0, j]);
                    a[1, j] = e2 - e1;
                }


                for (int j = 0; j < 4; j++)
                {
                    double e3 = a[2, j];
                    double e1 = ((m31) * a[0, j]);
                    a[2, j] = e3 - e1;
                }
                m32 = a[2, 1] / a[1, 1];
                for (int j = 0; j < 4; j++)
                {
                    double e3 = a[2, j];
                    double e1 = ((m32) * a[1, j]);
                    a[2, j] = e3 - e1;
                }
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

        private void button3_Click(object sender, EventArgs e)
        {
            _11.Clear(); _12.Clear(); _13.Clear(); _14.Clear();
            _21.Clear(); _22.Clear(); _23.Clear(); _24.Clear();
            _31.Clear(); _32.Clear(); _33.Clear(); _34.Clear();
             label2.Text=null; label4.Text=null;  label7.Text = null;
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _11_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
