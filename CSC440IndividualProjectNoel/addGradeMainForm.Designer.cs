﻿namespace CSC440IndividualProjectNoel
{
    partial class addGradeMainForm
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
            studentIdTextBox = new TextBox();
            label1 = new Label();
            searchStudentIdButton = new Button();
            SuspendLayout();
            // 
            // studentIdTextBox
            // 
            studentIdTextBox.Location = new Point(12, 29);
            studentIdTextBox.Name = "studentIdTextBox";
            studentIdTextBox.Size = new Size(100, 23);
            studentIdTextBox.TabIndex = 0;
            studentIdTextBox.KeyPress += studentIdTextBox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Student ID:";
            // 
            // searchStudentIdButton
            // 
            searchStudentIdButton.Location = new Point(12, 58);
            searchStudentIdButton.Name = "searchStudentIdButton";
            searchStudentIdButton.Size = new Size(75, 23);
            searchStudentIdButton.TabIndex = 2;
            searchStudentIdButton.Text = "Search";
            searchStudentIdButton.UseVisualStyleBackColor = true;
            searchStudentIdButton.Click += searchStudentIdButton_Click;
            // 
            // addGradeMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(searchStudentIdButton);
            Controls.Add(label1);
            Controls.Add(studentIdTextBox);
            Name = "addGradeMainForm";
            Text = "addGradeMainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox studentIdTextBox;
        private Label label1;
        private Button searchStudentIdButton;
    }
}