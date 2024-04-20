﻿using System;
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
                        tasks.Add(1, false);
                        tasks.Add(2, false);
                        break;
                    case 2:
                        tasks.Add(1, false);
                        tasks.Add(2, false);
                        tasks.Add(3, false);
                        break;
                    case 3:
                        tasks.Add(1, false);
                        tasks.Add(2, false);
                        tasks.Add(3, false);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 7:
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
            string tasks = "";
            string answers = "";

            //после реализации всех глав этот try catch уберем
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
                            j++;
                        }
                        if (selectedTasks[3][2] == true)
                        {
                            t = Chapter3Generator.GenerateTask2();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n\n"; 
                            j++;
                        }
                        if (selectedTasks[3][3] == true)
                        {
                            t = Chapter3Generator.GenerateTask3();
                            tasks += $"{j}) " + t.Text + "\n\n";
                            answers += $"{j}) " + t.Answer + "\n\n";
                            j++;
                        }
                    }

                    tasks += "\n\n";
                    answers += "\n\n";
                }

                FileWriter.WriteToDOCX(tasks + answers);
                //.Write(tasks + answers);
                //MessageBox.Show("Варианты записаны в файл!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void Chapter1MenuItem_Click(object sender, EventArgs e)
        {
            Chapter1Form chapter1 = new Chapter1Form(selectedTasks[1]);
            chapter1.Show();
        }

        private void chapter2MenuItem_Click(object sender, EventArgs e)
        {
            Chapter2Form chapter2 = new Chapter2Form(selectedTasks[2]);
            chapter2.Show();
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

        private void chapter3MenuItem_Click(object sender, EventArgs e)
        {
            Chapter3Form chapter3 = new Chapter3Form(selectedTasks[3]);
            chapter3.Show();
        }
    }
}
