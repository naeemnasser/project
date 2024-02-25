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
    public partial class CramersRule : Form
    {
        double[,] ca = new double[3, 4];
        public CramersRule()
        {
            InitializeComponent();
        }

        private void CramersRule_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home b = new Home();
            this.Close();
            b.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                double[,] a = new double[3, 4] {
             {Convert.ToDouble((_11.Text)), Convert.ToDouble((_12.Text)), Convert.ToDouble((_13.Text)), Convert.ToDouble((_14.Text))} ,   
          {Convert.ToDouble((_21.Text)),Convert.ToDouble((_22.Text)),Convert.ToDouble((_23.Text)),Convert.ToDouble((_24.Text))} ,   
         {Convert.ToDouble((_31.Text)), Convert.ToDouble((_32.Text)),Convert.ToDouble((_33.Text)),Convert.ToDouble((_34.Text))}  
        };
               
                CopyMatrix(a, ca);
                double[] detA = new double[4];
                double c0, c1, c2, det;
                c0 = a[0, 0] * ((a[1, 1] * a[2, 2]) - (a[1, 2] * a[2, 1]));
                c1 = a[0, 1] * ((a[1, 0] * a[2, 2]) - (a[1, 2] * a[2, 0]));
                c2 = a[0, 2] * ((a[1, 0] * a[2, 1]) - (a[1, 1] * a[2, 0]));

                det = c0 - c1 + c2;
                label11.Text = det.ToString();
                for (int i = 0; i < 3; i++)
                {
                    a[0, i] = a[0, 3];
                    a[1, i] = a[1, 3];
                    a[2, i] = a[2, 3];

                    c0 = a[0, 0] * ((a[1, 1] * a[2, 2]) - (a[1, 2] * a[2, 1]));
                    c1 = a[0, 1] * ((a[1, 0] * a[2, 2]) - (a[1, 2] * a[2, 0]));
                    c2 = a[0, 2] * ((a[1, 0] * a[2, 1]) - (a[1, 1] * a[2, 0]));


                    detA[i] = c0 - c1 + c2;
                    CopyMatrix(ca, a);


                }
                label16.Text = detA[0].ToString(); label12.Text = detA[1].ToString(); label14.Text = detA[2].ToString();


                label2.Text += (detA[0] / det).ToString();
                label4.Text += (detA[1] / det).ToString();
                label7.Text += (detA[2] / det).ToString();





            }
            catch (Exception)
            {

                MessageBox.Show("invalid value ");
            }
        }


        void CopyMatrix(double[,] _x, double[,] _y)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _y[i,j] = _x[i,j];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _11.Clear(); _12.Clear(); _13.Clear(); _14.Clear();
            _21.Clear(); _22.Clear(); _23.Clear(); _24.Clear();
            _31.Clear(); _32.Clear(); _33.Clear(); _34.Clear();
            label2.Text = null; label4.Text = null; label7.Text = null;
            label16.Text = null; label11.Text = null; label14.Text = null; label12.Text = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
