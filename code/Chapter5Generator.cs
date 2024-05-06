using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probability_theory_generator
{
    internal class Chapter5Generator
    {
        private static readonly Random random = new Random();
        public static FinishedTask GenerateTask1()
        {
            double x = Math.Round(0.4 + random.NextDouble() * (0.9 - 0.4), 2);
            double y = Math.Round(0.4 + random.NextDouble() * (0.9 - 0.4), 2);
            double z = Math.Round(0.4 + random.NextDouble() * (0.9 - 0.4), 2);

            double p0 = Math.Round((double)((1.0 - x) * (1.0 - y) * (1.0 - z)), 5);
            double p1 = Math.Round((double)((1.0 - x) * (1.0 - y) * z + (1.0 - x) * y * (1.0 - z) + (1.0 - y) * (1.0 - z) * x), 5);
            double p2 = Math.Round((double)(x * y * (1.0 - z) + x * (1.0 - y) * z + (1.0 - x) * y * z), 5);
            double p3 = Math.Round((double)(x * y * z), 5);

            string distributionSeries = "", F = "";
            double M = 0.0, D = 0.0, G = 0.0;

            Task SetF = new Task(() =>
            {
                distributionSeries = "Ряд распределения (X: P): { ";
                for (int i = 0; i < 4; i++) 
                {
                    distributionSeries += "(" + i.ToString() + ": ";
                    if (i == 0) distributionSeries += p0.ToString() + "); ";
                    else if (i == 1) distributionSeries += p1.ToString() + "); ";
                    else if (i == 2) distributionSeries += p2.ToString() + "); ";
                    else if (i == 3) distributionSeries += p3.ToString() + ")";
                }
                distributionSeries += " }";

                F = "F(X) = { ";
                F += "[ 0;  X <= 0 ]; ";
                F += "[ " + p0.ToString() + "; 0 < X <= 1 ]; ";
                F += "[ " + Math.Round(p0 + p1, 5).ToString() + "; 1 < X <= 2 ]; ";
                F += "[ " + Math.Round(p0 + p1 + p2, 5).ToString() + "; 2 < X <= 3 ]; ";
                F += "[ 1; 3 < X < ∞ ] }";
            });

            Task Solve = new Task(() =>
            {
                M = (double)(1.0 * p1 + 2.0 * p2 + 3.0 * p3);
                D = (double)((1.0 * p1 + 4.0 * p2 + 9.0 * p3) - M * M);
                G = Math.Sqrt(D);
            });

            SetF.Start(); Solve.Start();
            Task.WaitAll(Solve, SetF);

            TaskTemplate template = JSONReader.ReadJSON("Chapter5Task1.json");
            string text = template.Text;
            text = text.Replace("x", x.ToString());
            text = text.Replace("y", y.ToString());
            text = text.Replace("z", z.ToString());
            string answer = $"{distributionSeries};   {F};   M(X) = {Math.Round(M, 5)};   D(X) = {Math.Round(D, 5)};   σ(X) = {Math.Round(G, 5)}";
            
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }

        public static FinishedTask GenerateTask2()
        {
            double x = Math.Round(0.4 + random.NextDouble() * (0.9 - 0.4), 2);

            double p0 = Math.Round((double)((1.0 - x) * (1.0 - x) * (1.0 - x)), 5);
            double p1 = Math.Round((double)((1.0 - x) * (1.0 - x) * x * 3.0), 5);
            double p2 = Math.Round((double)((1.0 - x) * x * x * 3.0), 5);
            double p3 = Math.Round((double)(x * x * x), 5);

            string distributionSeries = "";
            double D = 0.0, M = 0.0;

            Task SetDistributionSeries = new Task(() =>
            {
                distributionSeries = "Ряд распределения (X: P): { ";
                distributionSeries += "(0: " + p0.ToString() + "); ";
                distributionSeries += "(1: " + p1.ToString() + "); ";
                distributionSeries += "(2: " + p2.ToString() + "); ";
                distributionSeries += "(3: " + p3.ToString() + ") }";
            });

            Task Solve = new Task(() => 
            {
                M = (double)(1.0 * p1 + 2.0 * p2 + 3.0 * p3);
                D = (double)((1.0 * p1 + 4.0 * p2 + 9.0 * p3) - M * M);
            });

            SetDistributionSeries.Start(); Solve.Start();
            Task.WaitAll(Solve, SetDistributionSeries);

            TaskTemplate template = JSONReader.ReadJSON("Chapter5Task2.json");
            string text = template.Text;
            text = text.Replace("x", x.ToString());
            string answer = $"{distributionSeries};   M(X) = {Math.Round(M, 5)};   D(X) = {Math.Round(D, 5)}";

            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }

        public static FinishedTask GenerateTask3()
        {
            int x = random.Next(7, 11);
            x *= 10000;
            //double y = Math.Round(0.0001 + random.NextDouble() * (0.0009 - 0.0001), 4);
            double y = 0.0001;
            int z = random.Next(3, 6);
            double[] p_x = new double[z + 1];
            for (int i = 0; i <= z; i++)
            {
                double lambda = x * y;
                p_x[i] = Math.Pow(lambda, i) * Math.Exp(-lambda) / (double)SuperMath.Factorial(i);
                p_x[i] = Math.Round(p_x[i], 5);
            }
            string distributionSeries = "";
            double M = 0.0;
            Task SetDistributionSeries = new Task(() =>
            {
                distributionSeries = "Ряд распределения (X: P): { ";
                for (int i = 0; i <= z; i++)
                {
                    distributionSeries += $"({i}: {p_x[i]})";
                    if (i != z) distributionSeries += ", ";
                    else distributionSeries += " }";
                }
            });
            Task Solve = new Task(() =>
            {
                for (int i = 1; i <= z; i++)
                {
                    M += p_x[i] * (double)i;
                }
            });
            SetDistributionSeries.Start();
            Solve.Start();
            Task.WaitAll(Solve, SetDistributionSeries);
            TaskTemplate template = JSONReader.ReadJSON("Chapter5Task3.json");
            string text = template.Text;
            text = text.Replace("x", x.ToString());
            text = text.Replace("y", y.ToString());
            text = text.Replace("z", z.ToString());
            string answer = $"{distributionSeries};   M(X) = {Math.Round(M, 5)}";
            FinishedTask task = new FinishedTask(text, answer);
            return task;
        }
        public static FinishedTask GenerateTask4()
        {
            double x = Math.Round(0.1 + random.NextDouble() * (0.3 - 0.1), 1);
            double y = Math.Round(0.1 + random.NextDouble() * (0.3 - 0.1), 1);
            double z = Math.Round(0.1 + random.NextDouble() * (0.9 - 0.1), 1);
            double t = 1.0 - z;
            double p = 1.0 - x - y;
            double M_X = 0.0, M_Y = 0.0, D_X = 0.0, D_Y = 0.0, M_Z1 = 0.0, M_Z2 = 0.0, D_Z1 = 0.0, D_Z2 = 0.0;
            string distributionSeries1 = "";
            string distributionSeries2 = "";
            Task SolveA = new Task(() =>
            {
                M_X = 2.0 * p + 3.0 * x + 4.0 * y;
                M_Y = 1.0 * z + 2.0 * t;
                D_X = 4.0 * p + 9.0 * x + 16.0 * y - M_X * M_X;
                D_Y = 1.0 * z + 4.0 * t - M_Y * M_Y;
            });
            Task SolveB = new Task(() =>
            {
                distributionSeries1 = "Ряд распределения (Z1: P): { ";
                distributionSeries1 += $"({5}: {p*z}); ({6}: {p*t}); ({7}: {x*z}); ({8}: {x*t}); ({9}: {y*z}); ({10}: {y*t}) }}";
                distributionSeries2 = "Ряд распределения (Z2: P): { ";
                distributionSeries2 += $"({2}: {p*z}); ({4}: {p*t + y*z}); ({3}: {x*z}); ({6}: {x*t}); ({8}: {y*t}) }}";
            });
            Task SolveC = new Task(() =>
            {
                M_Z1 = 2.0 * M_X + M_Y;
                M_Z2 = M_X * M_Y;
                D_Z1 = 4.0 * D_X + D_Y;
                D_Z2 = (4.0 * p + 9.0 * x + 16.0 * y - M_X * M_X) * (1.0 * z + 4.0 * t - M_Y * M_Y); 
            });
            SolveA.Start();
            SolveB.Start();
            SolveA.Wait();
            SolveC.Start();
            Task.WaitAll(SolveB, SolveC);
            TaskTemplate template = JSONReader.ReadJSON("Chapter5Task4.json");
            string text = template.Text;
            text = text.Replace("x", x.ToString());
            text = text.Replace("y", y.ToString());
            text = text.Replace("z", z.ToString());
            text = text.Replace("t", t.ToString());
            string answer = $"а) M(X) = {Math.Round(M_X, 5)};   M(Y) = {Math.Round(M_Y, 5)};   D(X) = {Math.Round(D_X, 5)};   D(Y) = {Math.Round(D_Y, 5)};\n" +
                $"б) {distributionSeries1}\n{distributionSeries2}\n" +
                $"в) M(Z1) = {Math.Round(M_Z1, 5)};   M(Z2) = {Math.Round(M_Z2, 5)};   D(Z1) = {Math.Round(D_Z1, 5)};   D(Z2) = {Math.Round(D_Z2, 5)};";
            FinishedTask task = new FinishedTask(text, answer);
            return task;
        }
    }
}
