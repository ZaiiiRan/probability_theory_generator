using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace probability_theory_generator
{
    /// <summary>
    /// Логика взаимодействия для Chapter1.xaml
    /// </summary>
    public partial class Chapter1 : Window
    {
        Dictionary<byte, bool> selectedTasks;
        public Chapter1(Dictionary<byte, bool> selectedTasks)
        {
            InitializeComponent();
            this.selectedTasks = selectedTasks;
            task1CheckBox.IsChecked = selectedTasks[1] ;
            task2CheckBox.IsChecked = selectedTasks[2];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedTasks[1] = task1CheckBox.IsChecked == true;
            selectedTasks[2] = task2CheckBox.IsChecked == true;
            this.Close();
        }
    }
}
