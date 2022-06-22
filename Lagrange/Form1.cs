using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lagrange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            string Str = textBox1.Text.Trim();

            int NumPoints;

            bool isNum = int.TryParse(Str, out NumPoints);

            if (!isNum)
            {
                return;
            }
            
            var xValues = new double[NumPoints];
            var yValues = new double[NumPoints];
            var Rand = new Random();

            for (int i = 0; i < NumPoints; i++)
            {
                xValues[i] = i;
                yValues[i] = Rand.Next(NumPoints+1);
            }

            for (int i = 0; i < NumPoints; i++)
            {
                chart1.Series[0].Points.AddXY(xValues[i], LagrangeInterpolation(xValues, yValues, i));
            }
        }

        public static double LagrangeInterpolation(double[] x, double[] y, double xval)
        {
            double yval = 0.0;
            double Products = y[0];
            for (int i = 0; i < x.Length; i++)
            {
                Products = y[i];
                for (int j = 0; j < x.Length; j++)
                {
                    if (i != j)
                    {
                        Products *= (xval - x[j]) / (x[i] - x[j]);
                    }
                }
                yval += Products;
            }
            return yval;
        }
    }
}
