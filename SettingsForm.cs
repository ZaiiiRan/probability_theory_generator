using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace probability_theory_generator
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            linkLabel1.Text = Settings.JSONDirectory;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Сообщение об ошибке", -2, HorizontalAlignment.Left);
            UpdateErrors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.JSONDirectory = folderBrowserDialog.SelectedPath;
                linkLabel1.Text = Settings.JSONDirectory;
                Settings.SaveSettings();
                UpdateErrors();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Settings.JSONDirectory);
        }

        private void UpdateErrors()
        {
            listView1.Items.Clear();
            List<string> errors = Settings.CheckFiles();
            foreach (string error in errors)
            {
                ListViewItem row = new ListViewItem(error);
                listView1.Items.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateErrors();
        }
    }
}
