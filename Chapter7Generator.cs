using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace probability_theory_generator
{
    internal class Chapter7Generator
    {
        private static readonly Random random = new Random();

        public static FinishedTask GenerateTask1()
        {
            int a = random.Next(30, 40);
            int b = random.Next(50, 71);
            if (a % 2 == 0 && b % 2 != 0 || a % 2 != 0 && b % 2 == 0)
            {
                a++;
            }
            int x = a + (b - a) / 2;
            int y = random.Next(a + 4, b - 4);
            double sigma = Math.Round((double)Math.Abs(a - x) / 5, 5);
            string p = $"P({a} < X < {y}) = Φ( {y - x} / {sigma} ) - Φ( {a - x} / {sigma} )";

            TaskTemplate template = JSONReader.ReadJSON("Chapter7Task1.json");
            string text = template.Text;
            text = text.Replace("x", x.ToString());
            text = text.Replace("y", y.ToString());
            text = text.Replace("a", a.ToString());
            text = text.Replace("b", b.ToString());

            string answer = $"σ = |{a} - {x}| / 5;    {p}";

            FinishedTask task = new FinishedTask(text, answer);
            
            return task;
        }

        public static FinishedTask GenerateTask2()
        {
            double x = Math.Round(0.1 + random.NextDouble() * (0.5 - 0.1), 1);
            double y = Math.Round((double)random.Next(11, 30) / 1000, 3);

            double error = 1.0 / x;
            double p = Math.Round(1.0 - error * ((x - y) - y), 5);

            TaskTemplate template = JSONReader.ReadJSON("Chapter7Task2.json");
            string text = template.Text;
            text = text.Replace("x", x.ToString());
            text = text.Replace("y", y.ToString());

            string answer = $"{p.ToString()}";

            FinishedTask task = new FinishedTask(text , answer);
            return task;
        }
    }
}
