namespace CSC440IndividualProjectNoel
{
    partial class addGrade
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            studentIdTextBox = new TextBox();
            studentNameTextBox = new TextBox();
            coursePrefixTextBox = new TextBox();
            courseNumberTextBox = new TextBox();
            addGradebutton = new Button();
            label6 = new Label();
            creditHoursTextBox = new TextBox();
            gradeComboBox = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            yearTimePicker = new DateTimePicker();
            semesterComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Student ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 124);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 2;
            label3.Text = "Course prefix:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 186);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 3;
            label4.Text = "Course number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 450);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 4;
            label5.Text = "New grade:";
            // 
            // studentIdTextBox
            // 
            studentIdTextBox.Location = new Point(12, 27);
            studentIdTextBox.Name = "studentIdTextBox";
            studentIdTextBox.ReadOnly = true;
            studentIdTextBox.Size = new Size(100, 23);
            studentIdTextBox.TabIndex = 5;
            // 
            // studentNameTextBox
            // 
            studentNameTextBox.Location = new Point(12, 85);
            studentNameTextBox.Name = "studentNameTextBox";
            studentNameTextBox.ReadOnly = true;
            studentNameTextBox.Size = new Size(100, 23);
            studentNameTextBox.TabIndex = 6;
            // 
            // coursePrefixTextBox
            // 
            coursePrefixTextBox.Location = new Point(12, 142);
            coursePrefixTextBox.Name = "coursePrefixTextBox";
            coursePrefixTextBox.Size = new Size(100, 23);
            coursePrefixTextBox.TabIndex = 7;
            coursePrefixTextBox.KeyPress += coursePrefixTextBox_KeyPress;
            // 
            // courseNumberTextBox
            // 
            courseNumberTextBox.Location = new Point(12, 204);
            courseNumberTextBox.Name = "courseNumberTextBox";
            courseNumberTextBox.Size = new Size(100, 23);
            courseNumberTextBox.TabIndex = 8;
            courseNumberTextBox.KeyPress += courseNumberTextBox_KeyPress;
            // 
            // addGradebutton
            // 
            addGradebutton.Location = new Point(12, 516);
            addGradebutton.Name = "addGradebutton";
            addGradebutton.Size = new Size(100, 23);
            addGradebutton.TabIndex = 10;
            addGradebutton.Text = "Add Grade";
            addGradebutton.UseVisualStyleBackColor = true;
            addGradebutton.Click += addGradebutton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 388);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 11;
            label6.Text = "Credit hours:";
            // 
            // creditHoursTextBox
            // 
            creditHoursTextBox.Location = new Point(12, 406);
            creditHoursTextBox.Name = "creditHoursTextBox";
            creditHoursTextBox.Size = new Size(100, 23);
            creditHoursTextBox.TabIndex = 12;
            creditHoursTextBox.KeyPress += creditHoursTextBox_KeyPress;
            // 
            // gradeComboBox
            // 
            gradeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gradeComboBox.FormattingEnabled = true;
            gradeComboBox.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            gradeComboBox.Location = new Point(12, 468);
            gradeComboBox.Name = "gradeComboBox";
            gradeComboBox.Size = new Size(100, 23);
            gradeComboBox.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 251);
            label7.Name = "label7";
            label7.Size = new Size(32, 15);
            label7.TabIndex = 14;
            label7.Text = "Year:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 320);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 15;
            label8.Text = "Semester:";
            // 
            // yearTimePicker
            // 
            yearTimePicker.Location = new Point(12, 269);
            yearTimePicker.Name = "yearTimePicker";
            yearTimePicker.Size = new Size(100, 23);
            yearTimePicker.TabIndex = 18;
            // 
            // semesterComboBox
            // 
            semesterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            semesterComboBox.FormattingEnabled = true;
            semesterComboBox.Items.AddRange(new object[] { "Spring", "Summer", "Fall", "Winter" });
            semesterComboBox.Location = new Point(12, 338);
            semesterComboBox.Name = "semesterComboBox";
            semesterComboBox.Size = new Size(100, 23);
            semesterComboBox.TabIndex = 19;
            // 
            // addGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(semesterComboBox);
            Controls.Add(yearTimePicker);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(gradeComboBox);
            Controls.Add(creditHoursTextBox);
            Controls.Add(label6);
            Controls.Add(addGradebutton);
            Controls.Add(courseNumberTextBox);
            Controls.Add(coursePrefixTextBox);
            Controls.Add(studentNameTextBox);
            Controls.Add(studentIdTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "addGrade";
            Text = "addGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox studentIdTextBox;
        private TextBox studentNameTextBox;
        private TextBox coursePrefixTextBox;
        private TextBox courseNumberTextBox;
        private Button addGradebutton;
        private Label label6;
        private TextBox creditHoursTextBox;
        private ComboBox gradeComboBox;
        private Label label7;
        private Label label8;
        private DateTimePicker yearTimePicker;
        private ComboBox semesterComboBox;
    }
}