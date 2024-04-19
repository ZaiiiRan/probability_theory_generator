using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

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
        public static void WriteToDOCX(string str)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Files(*.docx)|*.docx";
            saveFileDialog.DefaultExt = "docx";
            saveFileDialog.Title = "Сохранение в Word";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Word.Application wordApp = new Word.Application();
                    Word.Document doc = wordApp.Documents.Add();
                    doc.Content.Text = str;
                    doc.SaveAs2(saveFileDialog.FileName);
                    doc.Close();
                    wordApp.Quit();
                    MessageBox.Show($"Варианты записаны в файл!\n{saveFileDialog.FileName}");
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при сохранении файла!");
                }
            }
        }
    }
}
