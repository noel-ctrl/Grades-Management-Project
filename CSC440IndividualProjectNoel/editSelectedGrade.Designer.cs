namespace CSC440IndividualProjectNoel
{
    partial class editSelectedGrade
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
            yearTimePicker = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            gradeComboBox = new ComboBox();
            creditHoursTextBox = new TextBox();
            label6 = new Label();
            updateGradebutton = new Button();
            courseNumberTextBox = new TextBox();
            coursePrefixTextBox = new TextBox();
            studentNameTextBox = new TextBox();
            studentIdTextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            semesterTextBox = new TextBox();
            SuspendLayout();
            // 
            // yearTimePicker
            // 
            yearTimePicker.Enabled = false;
            yearTimePicker.Location = new Point(12, 269);
            yearTimePicker.Name = "yearTimePicker";
            yearTimePicker.Size = new Size(100, 23);
            yearTimePicker.TabIndex = 35;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 320);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 34;
            label8.Text = "Semester:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 251);
            label7.Name = "label7";
            label7.Size = new Size(32, 15);
            label7.TabIndex = 33;
            label7.Text = "Year:";
            // 
            // gradeComboBox
            // 
            gradeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gradeComboBox.FormattingEnabled = true;
            gradeComboBox.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            gradeComboBox.Location = new Point(12, 468);
            gradeComboBox.Name = "gradeComboBox";
            gradeComboBox.Size = new Size(100, 23);
            gradeComboBox.TabIndex = 32;
            // 
            // creditHoursTextBox
            // 
            creditHoursTextBox.Location = new Point(12, 406);
            creditHoursTextBox.Name = "creditHoursTextBox";
            creditHoursTextBox.ReadOnly = true;
            creditHoursTextBox.Size = new Size(100, 23);
            creditHoursTextBox.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 388);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 30;
            label6.Text = "Credit hours:";
            // 
            // updateGradebutton
            // 
            updateGradebutton.Location = new Point(12, 516);
            updateGradebutton.Name = "updateGradebutton";
            updateGradebutton.Size = new Size(100, 23);
            updateGradebutton.TabIndex = 29;
            updateGradebutton.Text = "Update Grade";
            updateGradebutton.UseVisualStyleBackColor = true;
            updateGradebutton.Click += updateGradebutton_Click;
            // 
            // courseNumberTextBox
            // 
            courseNumberTextBox.Location = new Point(12, 204);
            courseNumberTextBox.Name = "courseNumberTextBox";
            courseNumberTextBox.ReadOnly = true;
            courseNumberTextBox.Size = new Size(100, 23);
            courseNumberTextBox.TabIndex = 28;
            // 
            // coursePrefixTextBox
            // 
            coursePrefixTextBox.Location = new Point(12, 142);
            coursePrefixTextBox.Name = "coursePrefixTextBox";
            coursePrefixTextBox.ReadOnly = true;
            coursePrefixTextBox.Size = new Size(100, 23);
            coursePrefixTextBox.TabIndex = 27;
            // 
            // studentNameTextBox
            // 
            studentNameTextBox.Location = new Point(12, 85);
            studentNameTextBox.Name = "studentNameTextBox";
            studentNameTextBox.ReadOnly = true;
            studentNameTextBox.Size = new Size(100, 23);
            studentNameTextBox.TabIndex = 26;
            // 
            // studentIdTextBox
            // 
            studentIdTextBox.Location = new Point(12, 27);
            studentIdTextBox.Name = "studentIdTextBox";
            studentIdTextBox.ReadOnly = true;
            studentIdTextBox.Size = new Size(100, 23);
            studentIdTextBox.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 450);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 24;
            label5.Text = "Grade:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 186);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 23;
            label4.Text = "Course number:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 124);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 22;
            label3.Text = "Course prefix:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 21;
            label2.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 20;
            label1.Text = "Student ID:";
            // 
            // semesterTextBox
            // 
            semesterTextBox.Location = new Point(12, 338);
            semesterTextBox.Name = "semesterTextBox";
            semesterTextBox.ReadOnly = true;
            semesterTextBox.Size = new Size(100, 23);
            semesterTextBox.TabIndex = 36;
            // 
            // editSelectedGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 552);
            Controls.Add(semesterTextBox);
            Controls.Add(yearTimePicker);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(gradeComboBox);
            Controls.Add(creditHoursTextBox);
            Controls.Add(label6);
            Controls.Add(updateGradebutton);
            Controls.Add(courseNumberTextBox);
            Controls.Add(coursePrefixTextBox);
            Controls.Add(studentNameTextBox);
            Controls.Add(studentIdTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "editSelectedGrade";
            Text = "editSelectedGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker yearTimePicker;
        private Label label8;
        private Label label7;
        private ComboBox gradeComboBox;
        private TextBox creditHoursTextBox;
        private Label label6;
        private Button updateGradebutton;
        private TextBox courseNumberTextBox;
        private TextBox coursePrefixTextBox;
        private TextBox studentNameTextBox;
        private TextBox studentIdTextBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox semesterTextBox;
    }
}