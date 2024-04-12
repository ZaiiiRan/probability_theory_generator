using Newtonsoft.Json;
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
    public class TaskTemplate
    {
        [JsonProperty("text")]
        public string Text { get; private set; }

        [JsonProperty("parametres")]
        public List<string> Parametres { get; set; }
        public TaskTemplate(string text, List<string> parametres)
        {
            Text = text;
            Parametres = parametres;
        }
    }
}
