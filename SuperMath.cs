using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace probability_theory_generator
{
    public static class SuperMath
    {
        public static long Factorial(int a)
        {
            int result = 1;
            while (a > 1)
            {
                result *= a;
                a--;
            }
            return result;
        }
        public static long NumberOfCombinations(int n, int k)
        {
            if (n == k) return 1;
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
    }
}
