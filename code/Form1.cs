using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace probability_theory_generator
{
    public partial class MainForm : Form
    {
        private Dictionary<byte, Dictionary<byte, bool>> selectedTasks;
        public MainForm()
        {
            InitializeComponent();
            selectedTasks = new Dictionary<byte, Dictionary<byte, bool>>();
            for (byte i = 1; i <= 7; i++)
            {
                if (i == 6) continue;
                Dictionary<byte, bool> tasks = new Dictionary<byte, bool>();
                switch (i)
                {
                    case 1:
                        tasks.Add(1, true);
                        tasks.Add(2, true);
                        break;
                    case 2:
                        tasks.Add(1, true);
                        tasks.Add(2, true);
                        tasks.Add(3, true);
                        break;
                    case 3:
                        tasks.Add(1, true);
                        tasks.Add(2, true);
                        tasks.Add(3, true);
                        break;
                    case 4:
                        tasks.Add(1, true);
                        tasks.Add(2, true);
                        tasks.Add(3, true);
                        break;
                    case 5:
                        tasks.Add(1, true);
                        tasks.Add(2, true);
                        tasks.Add(3, true);
                        tasks.Add(4, true);
                        break;
                    case 7:
                        tasks.Add(1, true);
                        tasks.Add(2, true);
                        tasks.Add(3, true);
                        break;
                }
                selectedTasks.Add(i, tasks);
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            int count;
            try
            {
                count = Convert.ToInt32(variantsCount.Text);
                if (count < 1 && count > 500) throw new ArgumentException();
            }
            catch
            {
                MessageBox.Show("Количество вариантов должно быть целочисленным положительным числом в диапазоне [1, 500]!");
                return;
            }
            if (Settings.CheckFiles().Count != 0)
            {
                MessageBox.Show("Ошибка при загрузке шаблонов задач!");
                return;
            }
            string tasks = "";
            string answers = "Ответы:\n\n";

            goButton.Enabled = false;

            try
            {
                for (int i = 1; i <= count; i++)
                {
                    tasks += $"Вариант {i}:\n";
                    answers += $"Вариант {i}:\n";
                    int j = 1;
                    FinishedTask t;
                    if (chapter1CheckBox.Checked == true)
                    {
                        if (selectedTasks[1][1] == true)
                        {
                            t = Chapter1Generator.GenerateTask1();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[1][2] == true)
                        {
                            t = Chapter1Generator.GenerateTask2();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                    }

                    if (chapter2CheckBox.Checked == true)
                    {
                        if (selectedTasks[2][1] == true)
                        {
                            t = Chapter2Generator.GenerateTask1();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[2][2] == true)
                        {
                            t = Chapter2Generator.GenerateTask2();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[2][3] == true)
                        {
                            t = Chapter2Generator.GenerateTask3();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                    }

                    if (chapter3CheckBox.Checked == true)
                    {
                        if (selectedTasks[3][1] == true)
                        {
                            t = Chapter3Generator.GenerateTask1();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[3][2] == true)
                        {
                            t = Chapter3Generator.GenerateTask2();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n"; 
                            j++;
                        }
                        if (selectedTasks[3][3] == true)
                        {
                            t = Chapter3Generator.GenerateTask3();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                    }

                    if (chapter4CheckBox.Checked == true)
                    {
                        if (selectedTasks[4][1] == true)
                        {
                            t = Chapter4Generator.GenerateTask1();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[4][2] == true)
                        {
                            t = Chapter4Generator.GenerateTask2();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[4][3] == true)
                        {
                            t = Chapter4Generator.GenerateTask3();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                    }

                    if (chapter5CheckBox.Checked == true)
                    {
                        if (selectedTasks[5][1] == true)
                        {
                            t = Chapter5Generator.GenerateTask1();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[5][2] == true)
                        {
                            t = Chapter5Generator.GenerateTask2();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[5][3] == true)
                        {
                            t = Chapter5Generator.GenerateTask3();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[5][4] == true)
                        {
                            t = Chapter5Generator.GenerateTask4();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                    }

                    if (chapter7CheckBox.Checked == true)
                    {
                        if (selectedTasks[7][1]) {
                            t = Chapter7Generator.GenerateTask1();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[7][2])
                        {
                            t = Chapter7Generator.GenerateTask2();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                        if (selectedTasks[7][3])
                        {
                            t = Chapter7Generator.GenerateTask3();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n";
                            j++;
                        }
                    }

                    tasks += "\f";
                    answers += "\n\n";
                }

                FileWriter.WriteToDOCX(tasks + answers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            goButton.Enabled = true;

        }

        public void Chapter1MenuItem_Click(object sender, EventArgs e)
        {
            Chapter1Form chapter1 = new Chapter1Form(selectedTasks[1]);
            chapter1.ShowDialog();
        }

        private void chapter2MenuItem_Click(object sender, EventArgs e)
        {
            Chapter2Form chapter2 = new Chapter2Form(selectedTasks[2]);
            chapter2.ShowDialog();
        }

        private void chapter3MenuItem_Click(object sender, EventArgs e)
        {
            Chapter3Form chapter3 = new Chapter3Form(selectedTasks[3]);
            chapter3.ShowDialog();
        }

        private void chapter4MenuItem_Click(object sender, EventArgs e)
        {
            Chapter4Form chapter4 = new Chapter4Form(selectedTasks[4]);
            chapter4.ShowDialog();
        }

        private void chapter5MenuItem_Click(object sender, EventArgs e)
        {
            Chapter5Form chapter5 = new Chapter5Form(selectedTasks[5]);
            chapter5.ShowDialog();
        }

        private void chapter7MenuItem_Click(object sender, EventArgs e)
        {
            Chapter7Form chapter7 = new Chapter7Form(selectedTasks[7]);
            chapter7.ShowDialog();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
        }

        private void infoMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm form = new InfoForm();
            form.ShowDialog();
        }


        private void chapter1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chapter1CheckBox.Checked) chapter1MenuItem.Enabled = true;
            else chapter1MenuItem.Enabled = false;
        }

        private void chapter2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chapter2CheckBox.Checked) chapter2MenuItem.Enabled = true;
            else chapter2MenuItem.Enabled = false;
        }

        private void chapter3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chapter3CheckBox.Checked) chapter3MenuItem.Enabled = true;
            else chapter3MenuItem.Enabled = false;
        }

        private void chapter4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chapter4CheckBox.Checked) chapter4MenuItem.Enabled = true;
            else chapter4MenuItem.Enabled = false;
        }

        private void chapter5CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chapter5CheckBox.Checked) chapter5MenuItem.Enabled = true;
            else chapter5MenuItem.Enabled = false;
        }

        private void chapter7CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chapter7CheckBox.Checked) chapter7MenuItem.Enabled = true;
            else chapter7MenuItem.Enabled = false;
        }
    }
}
