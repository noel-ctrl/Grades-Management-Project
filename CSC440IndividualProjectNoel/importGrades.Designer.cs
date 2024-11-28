namespace CSC440IndividualProjectNoel
{
    partial class importGrades
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
            ImportFolderButton = new Button();
            importSingleButton = new Button();
            importSingleGradesFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // ImportFolderButton
            // 
            ImportFolderButton.Location = new Point(12, 12);
            ImportFolderButton.Name = "ImportFolderButton";
            ImportFolderButton.Size = new Size(166, 23);
            ImportFolderButton.TabIndex = 0;
            ImportFolderButton.Text = "Import Folder of Excel Files";
            ImportFolderButton.UseVisualStyleBackColor = true;
            ImportFolderButton.Click += ImportFolderButton_Click;
            // 
            // importSingleButton
            // 
            importSingleButton.Location = new Point(12, 41);
            importSingleButton.Name = "importSingleButton";
            importSingleButton.Size = new Size(166, 23);
            importSingleButton.TabIndex = 1;
            importSingleButton.Text = "Import Single Excel File";
            importSingleButton.UseVisualStyleBackColor = true;
            importSingleButton.Click += importSingleButton_Click;
            // 
            // importGrades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(importSingleButton);
            Controls.Add(ImportFolderButton);
            Name = "importGrades";
            Text = "importGrades";
            ResumeLayout(false);
        }

        #endregion

        private Button ImportFolderButton;
        private Button importSingleButton;
        private OpenFileDialog importSingleGradesFileDialog;
        private FolderBrowserDialog folderBrowserDialog;
    }
}