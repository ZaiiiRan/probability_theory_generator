using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace probability_theory_generator
{
    public class JSONReader
    {
        public static TaskTemplate ReadJSON(string fileName)
        {
            string json = File.ReadAllText(fileName);
            var template = JsonConvert.DeserializeObject<TaskTemplate>(json);
            return template;
        }
    }
}
