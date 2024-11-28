namespace CSC440IndividualProjectNoel
{
    partial class deleteGrade
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
            gradesNameLabel = new Label();
            gradeSelectedButton = new Button();
            studentGradesListBox = new ListBox();
            SuspendLayout();
            // 
            // gradesNameLabel
            // 
            gradesNameLabel.AutoSize = true;
            gradesNameLabel.Location = new Point(12, 9);
            gradesNameLabel.Name = "gradesNameLabel";
            gradesNameLabel.Size = new Size(67, 15);
            gradesNameLabel.TabIndex = 5;
            gradesNameLabel.Text = "\" \"'s Grades";
            // 
            // gradeSelectedButton
            // 
            gradeSelectedButton.Location = new Point(12, 202);
            gradeSelectedButton.Name = "gradeSelectedButton";
            gradeSelectedButton.Size = new Size(83, 23);
            gradeSelectedButton.TabIndex = 4;
            gradeSelectedButton.Text = "Select Grade";
            gradeSelectedButton.UseVisualStyleBackColor = true;
            gradeSelectedButton.Click += gradeSelectedButton_Click;
            // 
            // studentGradesListBox
            // 
            studentGradesListBox.FormattingEnabled = true;
            studentGradesListBox.ItemHeight = 15;
            studentGradesListBox.Location = new Point(12, 27);
            studentGradesListBox.Name = "studentGradesListBox";
            studentGradesListBox.Size = new Size(325, 169);
            studentGradesListBox.TabIndex = 3;
            // 
            // deleteGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gradesNameLabel);
            Controls.Add(gradeSelectedButton);
            Controls.Add(studentGradesListBox);
            Name = "deleteGrade";
            Text = "deleteGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gradesNameLabel;
        private Button gradeSelectedButton;
        private ListBox studentGradesListBox;
    }
}