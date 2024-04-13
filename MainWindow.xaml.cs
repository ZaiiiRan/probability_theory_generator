﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace probability_theory_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<byte, Dictionary<byte, bool>> selectedTasks;
        public MainWindow()
        {
            InitializeComponent();
            selectedTasks = new();
            for (byte i = 1; i <= 7; i++)
            {
                if (i == 6) continue;
                Dictionary<byte, bool> tasks = new();
                switch (i)
                {
                    case 1:
                        tasks.Add(1, false);
                        tasks.Add(2, false);
                        break;
                    case 2:
                        break;
                    case 3:
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

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            int count;
            try
            {
                count = Convert.ToInt32(variantsCount.Text);
                if (count < 1) throw new ArgumentException();
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
                    if (chapter1CheckBox.IsChecked == true)
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

                    tasks += "\n\n";
                    answers += "\n\n";
                }

                FileWriter.Write(tasks + answers);
                MessageBox.Show("Варианты записаны в файл!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Chapter1 chapter1 = new(selectedTasks[1]);
            chapter1.Show();
        }

        private void chapter1CheckBox_Checked(object sender, RoutedEventArgs e) => Chapter1MenuItem.IsEnabled = true;

        private void chapter1CheckBox_Unchecked(object sender, RoutedEventArgs e) => Chapter1MenuItem.IsEnabled=false;

        private void chapter2CheckBox_Checked(object sender, RoutedEventArgs e) => Chapter2MenuItem.IsEnabled = true;

        private void chapter2CheckBox_Unchecked(object sender, RoutedEventArgs e) => Chapter2MenuItem.IsEnabled=false;

        private void chapter3CheckBox_Checked(object sender, RoutedEventArgs e) => Chapter3MenuItem.IsEnabled = true;

        private void chapter3CheckBox_Unchecked(object sender, RoutedEventArgs e) => Chapter3MenuItem.IsEnabled=false;

        private void chapter4CheckBox_Checked(object sender, RoutedEventArgs e) => Chapter4MenuItem.IsEnabled = true;

        private void chapter4CheckBox_Unchecked(object sender, RoutedEventArgs e) => Chapter4MenuItem.IsEnabled = false;

        private void chapter5CheckBox_Checked(object sender, RoutedEventArgs e) => Chapter5MenuItem.IsEnabled = true;

        private void chapter5CheckBox_Unchecked(object sender, RoutedEventArgs e) => Chapter5MenuItem.IsEnabled=false;

        private void chapter7CheckBox_Checked(object sender, RoutedEventArgs e) => Chapter7MenuItem.IsEnabled = true;

        private void chapter7CheckBox_Unchecked(object sender, RoutedEventArgs e) => Chapter7MenuItem.IsEnabled = false;
    }
}