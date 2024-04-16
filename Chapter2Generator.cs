using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace probability_theory_generator
{
    internal class Chapter2Generator
    {
        public static FinishedTask GenerateTask1()
        {
            Random random = new Random();
            int r1 = 1, r2 = 7;
            int x = random.Next(r1, r2);
            int z = random.Next(r1, r2);
            int yNum = random.Next(0, 2);
            string y = (yNum % 2 == 0) ? "четного" : "нечетного";

            string a = "", b = "", c = "";
            Task SolveA = new Task(() =>
            {
                SortedSet<int> A = new SortedSet<int>();
                SortedSet<int> B = new SortedSet<int>();

                A.Add(x);
                if (yNum % 2 == 0)
                {
                    for (int i = 0; i <= 6; i += 2) B.Add(i);
                }
                else
                {
                    for (int i = 1; i <= 6; i += 2) B.Add(i);
                }

                A.UnionWith(B);
                a += "{ ";
                foreach (int i in A)
                {
                    a += $"{i} ";
                }
                a += " }";
                if (A.Count == 0) { a = "∅"; }
            });
            Task SolveB = new Task(() =>
            {
                SortedSet<int> A = new SortedSet<int>();
                SortedSet<int> B = new SortedSet<int>();
                SortedSet<int> C = new SortedSet<int>();
                A.Add(x);
                if (yNum % 2 == 0)
                {
                    for (int i = 0; i <= 6; i += 2) B.Add(i);
                }
                else
                {
                    for (int i = 1; i <= 6; i += 2) B.Add(i);
                }
                for (int i = 1; i <= z; i++)
                {
                    C.Add(i);
                }

                B.ExceptWith(C);
                A.IntersectWith(B);
                b += "{ ";
                foreach (int i in A)
                {
                    b += $"{i} ";
                }
                b += " }";
                if (A.Count == 0) { b = "∅"; }
            });
            Task SolveC = new Task(() =>
            {
                SortedSet<int> A = new SortedSet<int>();
                SortedSet<int> B = new SortedSet<int>();
                A.Add(x);
                if (yNum % 2 == 0)
                {
                    for (int i = 1; i <= 6; i += 2) B.Add(i);
                }
                else
                {
                    for (int i = 0; i <= 6; i += 2) B.Add(i);
                }

                A.IntersectWith(B);
                c += "{ ";
                foreach (int i in A)
                {
                    c += $"{i} ";
                }
                c += " }";
                if (A.Count == 0) { c = "∅"; }
            });

            SolveA.Start();
            SolveB.Start();
            SolveC.Start();

            Task.WaitAll(SolveA, SolveC);

            TaskTemplate template = JSONReader.ReadJSON("Chapter2Task1.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y);
            text = text.Replace("Z", z.ToString());
            string answer = $"{{1, 2, 3, 4, 5, 6}}; а) {a}; б) {b}; в) {c}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
        public static FinishedTask GenerateTask2()
        {
            Random random = new Random();
            double x = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);
            double y = Math.Round(random.NextDouble() * (1.0 - 0.1) + 0.1, 1);

            double a = 0, b = 0, c = 0;
            Task SolveA = new Task(() =>
            {
                a = (double)(x * (1.0 - y) + (1.0 - x) * y + x * y);
            });
            Task SolveB = new Task(() =>
            {
                b = (double)((1.0 - x) * (1.0 - y));
            });
            Task SolveC = new Task(() =>
            {
                c = (double)(y * (1.0 - x));
            });

            SolveA.Start();
            SolveB.Start();
            SolveC.Start();

            Task.WaitAll(SolveA, SolveC);

            TaskTemplate template = JSONReader.ReadJSON("Chapter2Task2.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            string answer = $"а) {Math.Round(a, 5)}; б) {Math.Round(b, 5)}; в) {Math.Round(c, 5)}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
        public static FinishedTask GenerateTask3()
        {
            Random random = new Random();
            int x = random.Next(1, 10);
            int y = random.Next(1, 10);
            int z = random.Next(1, 10);

            double a = (double)((double)x / 10 * (1.0 - (double)y / 10) * (1.0 - (double)z / 10) + (double)y / 10
                * (1.0 - (double)x / 10) * (1.0 - (double)z / 10) + (double)z / 10 * (1.0 - (double)x / 10) * (1.0 - (double)y / 10));

            TaskTemplate template = JSONReader.ReadJSON("Chapter2Task3.json");
            string text = template.Text;
            text = text.Replace("X", x.ToString());
            text = text.Replace("Y", y.ToString());
            text = text.Replace("Z", z.ToString());
            string answer = $"{Math.Round(a)}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
    }
}
