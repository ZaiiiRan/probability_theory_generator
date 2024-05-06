using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace probability_theory_generator
{
    internal class Chapter3Generator
    {
        private static readonly Random random = new Random();
        public static FinishedTask GenerateTask1()
        {
            int xCount = random.Next(3, 8);
            double ans = 1.0;
            string word = "";
            string possibleLetters = "авелрфь";
            Task Solve = new Task(() =>
            {
                for (int i = 0; i < xCount; i++)
                {
                    ans =(double) ans * ((double)1 / (xCount - i));
                }
            });
            Task createWord = new Task(() =>
            {
                int i = xCount;
                while (i > 0)
                {
                    int index = random.Next(0, possibleLetters.Length);
                    word += possibleLetters[index];
                    possibleLetters = possibleLetters.Remove(index, 1);
                    i--;
                }
            });
            Solve.Start();
            createWord.Start();
            Task.WaitAll(Solve, createWord);
            TaskTemplate template = JSONReader.ReadJSON("Chapter3Task1.json");
            string text = template.Text;
            text = text.Replace("X", word);
            string answer = $"{Math.Round(ans, 7).ToString()}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }

        public static FinishedTask GenerateTask2()
        {
            double x = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double y = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double z = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double ans = Math.Round(((double) 1 / 3 * (x + y + z)), 5);
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
            double p = x * a + y * b;
            double p1 = 0.0, p2 = 0.0;
            Task Solve1 = new Task(() =>
            {
                p1 = (x * a) / p; 
            });
            Task Solve2 = new Task(() =>
            {
                p2 = (y * b) / p;
            });
            Solve1.Start();
            Solve2.Start();
            Task.WaitAll(Solve1, Solve2);
            string answer = (p1 > p2) ? "У" : "УУ"; 
            TaskTemplate template = JSONReader.ReadJSON("Chapter3Task3.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            text = text.Replace("A", a.ToString());
            text = text.Replace("B", b.ToString());
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
    }
}
