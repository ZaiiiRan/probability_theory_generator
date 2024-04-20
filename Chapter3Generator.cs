using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probability_theory_generator
{
    internal class Chapter3Generator
    {
        private static readonly Random random = new Random();

        public static FinishedTask GenerateTask2()
        {
            double x = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double y = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double z = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double ans = Math.Round((1 / 3 * (x + y + z)), 5);
            TaskTemplate template = JSONReader.ReadJSON("Chapter3Task2.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            text = text.Replace("Z", z.ToString());
            string answer = $"{ans.ToString()}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }

        public static FinishedTask GenerateTask3()
        {
            double x = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double y = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double a = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double b = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);

            TaskTemplate template = JSONReader.ReadJSON("Chapter3Task3.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            text = text.Replace("A", a.ToString());
            text = text.Replace("B", b.ToString());
            string answer = $"";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
    }
}
