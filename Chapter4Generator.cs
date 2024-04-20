using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probability_theory_generator
{
    internal class Chapter4Generator
    {
        private static readonly Random random = new Random();
        public static FinishedTask GenerateTask1()
        {
            int x = random.Next(4, 8);
            double y = Math.Round(random.NextDouble() * (1.0 - 0.1), 1);
            int z = random.Next(1, x);
            int i = z;
            double p = 0.0;
            while (i != x + 1)
            {
                p = (double)p + (SuperMath.NumberOfCombinations(x, i) * Math.Pow(y, i) * Math.Pow((1.0 - y), (x - i)));
                i++;
            }
            TaskTemplate template = JSONReader.ReadJSON("Chapter4Task1.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            text = text.Replace("Z", z.ToString());
            string answer = $"{Math.Round(p, 7)}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }

        public static FinishedTask GenerateTask2()
        {
            int x = random.Next(8, 13) * 10;
            double y = Math.Round(random.NextDouble() * (0.2 - 0.1) + 0.1, 3);
            int a = random.Next(8, 15);
            int b = random.Next(20, 27);
            string answA = "", answB = "";
            Task SolveA = new Task(() =>
            {
                double sq = Math.Sqrt((double)x * y * (1-y));
                double X = ((double)a - (double)x * y) / sq;
                answA = $"{Math.Round((double)1 / sq, 7)} * φ({Math.Round(X, 7)})";
            });
            Task SolveB = new Task(() =>
            {
                double sq = Math.Sqrt((double)x * y * (1 - y));
                double X2 = ((double)b - (double)x * y) / sq;
                double X1 = ((double)0 - (double)x * y) / sq;
                answB = $"Φ({Math.Round(X2, 7)}) - Φ({Math.Round(X1, 7)})";
            });
            SolveA.Start(); SolveB.Start();
            Task.WaitAll(SolveA, SolveB);
            TaskTemplate template = JSONReader.ReadJSON("Chapter4Task2.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            text = text.Replace("A", a.ToString());
            text = text.Replace("B", b.ToString());
            string answer = $"а) {answA}; б) {answB}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }

        public static FinishedTask GenerateTask3()
        {
            double x = Math.Round(random.NextDouble() * (0.005 - 0.001) + 0.001, 3);
            int y = random.Next(3, 8) * 1000;
            int z = random.Next(2, 10);

            double sq = Math.Sqrt((double) y * x * (1.0 - x));
            double X2 = ((double)y - (double)y * x) / sq;
            double X1 = ((double)z - (double)y * x) / sq;

            TaskTemplate template = JSONReader.ReadJSON("Chapter4Task3.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            text = text.Replace("Z", z.ToString());
            string answer = $"Φ({Math.Round(X2, 7)}) - Φ({Math.Round(X1, 7)})";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
    }
}
