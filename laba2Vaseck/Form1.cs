using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace laba2Vaseck
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            String Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            textBox1.Text = "Version: " + Version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Pvp(double T)
                {
                double A = 14.9571;
                double B = 3231.225;
                double C = -98.138;
                double O = Math.Exp(A - B / (T + C));
                return O;
                }
            double Pvpr(double T)
            {
                double a = -11.806;
                double b = 12.0699;
                double c = -20.477;
                double d = 13.884;
                double Tc = 588.1;
                double Pc = 3.897;
                double Tg = T / Tc;
                double g = 1 - Tg;
                double O = Math.Exp((1/Tg)*(a*g + b * Math.Pow(g,1.5) + c * Math.Pow(g,2.5) + d * Math.Pow(g,5)))*Pc;
                return O;
            }
            
            int i = 318;
            int s = 0;
            double[] T = new double[18];
            while (i <= 403)
            {
                T[s] = i;
                s++;
                i += 5;
            }
            double[] Ant = new double[18];
            double[] Vag = new double[18];
            for (int j = 0; j < 18; j++)
            {
                Ant[j] = Pvp(T[j]);
                Vag[j] = Pvpr(T[j]);
                textBox2.Text += "Температура: " + T[j].ToString() + " Формула Антуана: " + Ant[j].ToString() + " Формула Вагнера: " + Vag[j].ToString() + " Точность: " + (Ant[j] - Vag[j]).ToString() + Environment.NewLine;
            }


        }
    }
}
