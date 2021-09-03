using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using ModelLibrary;

namespace DerivativeDisplayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            //Generate();
        }


        double QuadraticFunction(double x)
        {
            return x * x;
        }

        double CubicFunction(double x)
        {
            return x * x * x;
        }

        double SinFunction(double x)
        {
            return Math.Sin(x);
        }

        double InverseFunction(double x)
        {
            return 1 / x;
        }

        void Generate()
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    GenerateForFunction(QuadraticFunction);
                    break;
                case 1:
                    GenerateForFunction(CubicFunction);
                    break;
                case 2:
                    GenerateForFunction(SinFunction);
                    break;
                case 3:
                    GenerateForFunction(InverseFunction);
                    break;
                default:
                    throw new Exception();
            }
        }

        void GenerateForFunction(Func<double, double> f)
        {
            var fd = new FiniteDifference();
            double WrapperFunction(double x)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        return fd.Calculate(x, f, Types.Forward);
                    case 1:
                        return fd.Calculate(x, f, Types.Central);
                    case 2:
                        return fd.Calculate(x, f, Types.Backward);
                    default:
                        throw new Exception();
                }
            }
            double min = -10;
            double max = 10;
            double step = 0.01;
            PlotModel model = new() { Title = "Derivative of a function" };
            FunctionSeries function = new(f, min, max, step) { Title = "Function", StrokeThickness = 2, MarkerSize = 3};
            FunctionSeries derivative = new(WrapperFunction, min, max, step) { Title = "Derivative", StrokeThickness = 2, MarkerSize = 3 };
            model.Series.Add(function);
            model.Series.Add(derivative);
            plotView1.Model = model;

        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                Generate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                Generate();
        }
    }
}
