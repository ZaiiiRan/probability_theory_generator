using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probability_theory_generator
{
    public class FinishedTask
    {
        public string Text { get; private set; }
        public string Answer { get; private set; }
        public FinishedTask(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }
    }
}
