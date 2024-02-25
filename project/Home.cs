using project.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void select(object sender, EventArgs e)
        {

            switch (comboBox1.Text)
            {
                case "Bisection Method":
                    Bisection b = new Bisection();
                    b.Show();
                    break;
                case "False Position Method":
                    FalsePosition f = new FalsePosition();
                    f.Show();
                    break;
                case "Simple Fixed-Point Method":
                   FixedPoint s = new FixedPoint();
                    s.Show();
                    break;
                case "Newton Method":
                    NewtonMethod n = new NewtonMethod();
                    n.Show();
                    break;
                case "Gauss elimination":
                    GaussElimination g = new GaussElimination();
                    g.Show();
                    break;
                case "LU decomposition":
                    LUDecomposition l = new LUDecomposition();
                    l.Show();
                    break;
                case "Crammer's rule":
                    CramersRule c = new CramersRule();
                    c.Show();
                    break;

                default:
                    Console.WriteLine("Default case");
                    break;
            }
           
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

       

    }
}
