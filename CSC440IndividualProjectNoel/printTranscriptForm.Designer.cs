namespace CSC440IndividualProjectNoel
{
    partial class printTranscriptForm
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
            studentIdTextBox = new TextBox();
            printTranscriptButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 4;
            label1.Text = "Student ID:";
            // 
            // studentIdTextBox
            // 
            studentIdTextBox.Location = new Point(12, 29);
            studentIdTextBox.Name = "studentIdTextBox";
            studentIdTextBox.Size = new Size(100, 23);
            studentIdTextBox.TabIndex = 3;
            studentIdTextBox.KeyPress += studentIdTextBox_KeyPress;
            // 
            // printTranscriptButton
            // 
            printTranscriptButton.Location = new Point(12, 58);
            printTranscriptButton.Name = "printTranscriptButton";
            printTranscriptButton.Size = new Size(75, 23);
            printTranscriptButton.TabIndex = 5;
            printTranscriptButton.Text = "Print Transcript";
            printTranscriptButton.UseVisualStyleBackColor = true;
            // 
            // printTranscriptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(printTranscriptButton);
            Controls.Add(label1);
            Controls.Add(studentIdTextBox);
            Name = "printTranscriptForm";
            Text = "printTranscriptForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox studentIdTextBox;
        private Button printTranscriptButton;
    }
}