using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probability_theory_generator
{
    public static class FileWriter
    {
        public static void Write(string str, string path = "C:\\temp\\file.txt")
        {
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(str);
            streamWriter.Close();
        }
    }
}
