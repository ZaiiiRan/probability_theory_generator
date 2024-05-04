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
                    distributionSeries += i.ToString() + ": ";
                    if (i == 0) distributionSeries += p0.ToString() + "; ";
                    else if (i == 1) distributionSeries += p1.ToString() + "; ";
                    else if (i == 2) distributionSeries += p2.ToString() + "; ";
                    else if (i == 3) distributionSeries += p3.ToString();
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
                distributionSeries += "0: " + p0.ToString() + "; ";
                distributionSeries += "1: " + p1.ToString() + "; ";
                distributionSeries += "2: " + p2.ToString() + "; ";
                distributionSeries += "3: " + p3.ToString() + " }";
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

    }
}
