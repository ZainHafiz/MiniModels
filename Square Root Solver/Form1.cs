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
using OxyPlot.Axes;

namespace SquareRootSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Generate();
        }

        public void Generate()
        {
            PlotModel model = new() { Title = "Square Root Algorithm Performance"};
            LineSeries bisection = new LineSeries()
            {
                Title = $"Bisection",
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerType = MarkerType.Circle
            };
            LineSeries newtonRaphson = new LineSeries()
            {
                Title = $"Newton-Raphson",
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerType = OxyPlot.MarkerType.Circle
            };
            for (int i = 0; i < 100; i++)
            {
                ulong biCount = SquareRootSolver.Solve(i, Method.Bisection).Item2;
                ulong nrCount = SquareRootSolver.Solve(i, Method.NewtonRaphson).Item2;
                bisection.Points.Add(new DataPoint(i, biCount));
                newtonRaphson.Points.Add(new DataPoint(i, nrCount));
            }
            model.Series.Add(bisection);
            model.Series.Add(newtonRaphson);
            plotView1.Model = model;
        }
    }
}
