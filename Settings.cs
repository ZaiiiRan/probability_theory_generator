using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using probability_theory_generator.Properties;
using System.Windows.Forms;

namespace probability_theory_generator
{
    internal class Settings
    {
        public static string JSONDirectory;
        public static void LoadSettings()
        {
            try
            {
                string filePath = "settings.ini";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine("default");
                    }
                }
                JSONDirectory = File.ReadAllText("settings.ini").Trim();
                if (JSONDirectory == "")
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine("default");
                    }
                }
                if (JSONDirectory == "default" || JSONDirectory == "")
                {
                    JSONDirectory = $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TaskTemplates")}";
                }
            }
            catch
            {
                JSONDirectory = $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TaskTemplates")}";
            }

        }
        public static void SaveSettings()
        {
            try
            {
                string filePath = "settings.ini";
                using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate))
                {
                    fileStream.SetLength(0);
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(JSONDirectory);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении настроек");
            }
        }

        public static List<string> CheckFiles()
        {
            List<string> errors = new List<string>();
            try
            {
                JSONReader.ReadJSON("Chapter1Task1.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter1Task1.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter1Task2.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter1Task2.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter2Task1.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter2Task1.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter2Task2.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter2Task2.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter2Task3.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter2Task3.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter3Task1.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter3Task1.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter3Task2.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter3Task2.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter3Task3.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter3Task3.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter4Task1.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter4Task1.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter4Task2.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter4Task2.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter4Task3.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter4Task3.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter5Task1.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter5Task1.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter5Task2.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter5Task2.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter5Task3.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter5Task3.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter5Task4.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter5Task4.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter7Task1.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter7Task1.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter7Task2.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter7Task2.json отсутствует или поврежден");
            }
            try
            {
                JSONReader.ReadJSON("Chapter7Task3.json");
            }
            catch
            {
                errors.Add("Шаблон Chapter7Task3.json отсутствует или поврежден");
            }

            return errors;
        }
    }
}
