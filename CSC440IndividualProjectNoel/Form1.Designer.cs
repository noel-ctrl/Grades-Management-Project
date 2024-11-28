namespace CSC440IndividualProjectNoel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addGradeButton = new Button();
            editGradeButton = new Button();
            deleteGradeButton = new Button();
            printTranscriptButton = new Button();
            importGradesButton = new Button();
            SuspendLayout();
            // 
            // addGradeButton
            // 
            addGradeButton.Location = new Point(27, 18);
            addGradeButton.Name = "addGradeButton";
            addGradeButton.Size = new Size(101, 23);
            addGradeButton.TabIndex = 0;
            addGradeButton.Text = "Add a grade";
            addGradeButton.UseVisualStyleBackColor = true;
            addGradeButton.Click += addGradeButton_Click;
            // 
            // editGradeButton
            // 
            editGradeButton.Location = new Point(27, 60);
            editGradeButton.Name = "editGradeButton";
            editGradeButton.Size = new Size(101, 23);
            editGradeButton.TabIndex = 1;
            editGradeButton.Text = "Edit a grade";
            editGradeButton.UseVisualStyleBackColor = true;
            editGradeButton.Click += editGradeButton_Click;
            // 
            // deleteGradeButton
            // 
            deleteGradeButton.Location = new Point(27, 105);
            deleteGradeButton.Name = "deleteGradeButton";
            deleteGradeButton.Size = new Size(101, 23);
            deleteGradeButton.TabIndex = 2;
            deleteGradeButton.Text = "Delete a grade";
            deleteGradeButton.UseVisualStyleBackColor = true;
            deleteGradeButton.Click += deleteGradeButton_Click;
            // 
            // printTranscriptButton
            // 
            printTranscriptButton.Location = new Point(27, 149);
            printTranscriptButton.Name = "printTranscriptButton";
            printTranscriptButton.Size = new Size(101, 23);
            printTranscriptButton.TabIndex = 3;
            printTranscriptButton.Text = "Print transcript";
            printTranscriptButton.UseVisualStyleBackColor = true;
            printTranscriptButton.Click += printTranscriptButton_Click;
            // 
            // importGradesButton
            // 
            importGradesButton.Location = new Point(27, 199);
            importGradesButton.Name = "importGradesButton";
            importGradesButton.Size = new Size(101, 23);
            importGradesButton.TabIndex = 4;
            importGradesButton.Text = "Import grades";
            importGradesButton.UseVisualStyleBackColor = true;
            importGradesButton.Click += importGradesButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(importGradesButton);
            Controls.Add(printTranscriptButton);
            Controls.Add(deleteGradeButton);
            Controls.Add(editGradeButton);
            Controls.Add(addGradeButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button addGradeButton;
        private Button editGradeButton;
        private Button deleteGradeButton;
        private Button printTranscriptButton;
        private Button importGradesButton;
    }
}
