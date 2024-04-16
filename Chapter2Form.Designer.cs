namespace probability_theory_generator
{
    partial class Chapter2Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.task2CheckBox = new System.Windows.Forms.CheckBox();
            this.task1CheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.task3CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(137, 141);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 31);
            this.button1.TabIndex = 15;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // task2CheckBox
            // 
            this.task2CheckBox.AutoSize = true;
            this.task2CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.task2CheckBox.Location = new System.Drawing.Point(37, 69);
            this.task2CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.task2CheckBox.Name = "task2CheckBox";
            this.task2CheckBox.Size = new System.Drawing.Size(286, 24);
            this.task2CheckBox.TabIndex = 14;
            this.task2CheckBox.Text = "Задача 2 (Автомеханик и ремонт)";
            this.task2CheckBox.UseVisualStyleBackColor = true;
            // 
            // task1CheckBox
            // 
            this.task1CheckBox.AutoSize = true;
            this.task1CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.task1CheckBox.Location = new System.Drawing.Point(37, 41);
            this.task1CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.task1CheckBox.Name = "task1CheckBox";
            this.task1CheckBox.Size = new System.Drawing.Size(199, 24);
            this.task1CheckBox.TabIndex = 13;
            this.task1CheckBox.Text = "Задача 1 (Множества)";
            this.task1CheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Выберите задачи из второй главы:";
            // 
            // task3CheckBox
            // 
            this.task3CheckBox.AutoSize = true;
            this.task3CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.task3CheckBox.Location = new System.Drawing.Point(37, 97);
            this.task3CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.task3CheckBox.Name = "task3CheckBox";
            this.task3CheckBox.Size = new System.Drawing.Size(189, 24);
            this.task3CheckBox.TabIndex = 16;
            this.task3CheckBox.Text = "Задача 3 (Снайперы)";
            this.task3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Chapter2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 182);
            this.Controls.Add(this.task3CheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.task2CheckBox);
            this.Controls.Add(this.task1CheckBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Chapter2Form";
            this.Text = "Глава 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox task2CheckBox;
        private System.Windows.Forms.CheckBox task1CheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox task3CheckBox;
    }
}