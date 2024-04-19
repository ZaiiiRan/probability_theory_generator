using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace probability_theory_generator
{
    public static class Chapter1Generator
    {
        private static readonly Random r = new Random();
        public static FinishedTask GenerateTask1()
        {
            int r1 = 3, r2 = 8;
            int X = r.Next(r1, r2);
            int A = r.Next(1, X - X / 2);
            int B = r.Next(A + 1, X);
            double a = 0;
            double b = 0;
            Task solveA = new Task(() => a = (double)1 / SuperMath.Factorial(X));
            Task solveB = new Task(() => b = (double)SuperMath.Factorial(X - (B - A + 1)) / SuperMath.Factorial(X));
            solveA.Start();
            solveB.Start();
            Task.WaitAll(solveA, solveB);
            solveA.Dispose();
            solveB.Dispose();
            TaskTemplate template = JSONReader.ReadJSON("Chapter1Task1.json");
            string text = template.Text;
            text = text.Replace("X", X.ToString());
            text = text.Replace("A", A.ToString());
            text = text.Replace("B", B.ToString());
            string answer = $"{Math.Round(a, 5)}; {Math.Round(b, 5)}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
        public static FinishedTask GenerateTask2()
        {
            int r1 = 2, r2 = 5;
            int A = r.Next(r1, r2);
            int B = r.Next(r1, r2);
            int C = r.Next(r1, r2);
            int X = r.Next(r1, Math.Min(8, A + B + C - 1));

            double a = 0, b = 0;
            Task solveA = new Task(() => a = (double)SuperMath.NumberOfCombinations(A + B, X) / SuperMath.NumberOfCombinations(A + B + C, X));
            Task solveB = new Task(() => b = (double)SuperMath.NumberOfCombinations(A, 1) * SuperMath.NumberOfCombinations(B, 1)
                * SuperMath.NumberOfCombinations(C, 1) / SuperMath.NumberOfCombinations(A + B + C, X));
            solveA.Start();
            solveB.Start();
            Task.WaitAll(solveA, solveB);
            solveA.Dispose();
            solveB.Dispose();
            TaskTemplate template = JSONReader.ReadJSON("Chapter1Task2.json");
            string text = template.Text;
            text = text.Replace("A", A.ToString());
            text = text.Replace("B", B.ToString());
            text = text.Replace("C", C.ToString());
            text = text.Replace("X", X.ToString());
            string answer = $"{Math.Round(a, 5)}; {Math.Round(b, 5)}";
            FinishedTask finishedTask = new FinishedTask(text, answer);
            return finishedTask;
        }
    }
}
