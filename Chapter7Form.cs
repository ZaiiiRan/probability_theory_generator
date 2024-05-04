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
    public partial class Chapter7Form : Form
    {
        Dictionary<byte, bool> selectedTasks;
        public Chapter7Form(Dictionary<byte, bool> selectedTasks)
        {
            InitializeComponent();
            this.selectedTasks = selectedTasks;
            task1CheckBox.Checked = selectedTasks[1];
            task2CheckBox.Checked = selectedTasks[2];
            task3CheckBox.Checked = selectedTasks[3];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedTasks[1] = task1CheckBox.Checked == true;
            selectedTasks[2] = task2CheckBox.Checked == true;
            selectedTasks[3] = task3CheckBox.Checked == true;
            this.Close();
        }
    }
}
