using System.Windows.Forms;
using MySql.Data.MySqlClient;
using IronXL;

namespace CSC440IndividualProjectNoel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void addGradeButton_Click(object sender, EventArgs e)
        {
            addGradeMainForm addGradeMainForm = new addGradeMainForm();
            this.Hide();
            addGradeMainForm.ShowDialog();
            this.Show();
        }

        private void editGradeButton_Click(object sender, EventArgs e)
        {
            editGradeMainForm editGradeMainForm = new editGradeMainForm();
            this.Hide();
            editGradeMainForm.ShowDialog();
            this.Show();
        }

        private void deleteGradeButton_Click(object sender, EventArgs e)
        {
            deleteGradeMainForm deleteGradeMainForm = new deleteGradeMainForm();
            this.Hide();
            deleteGradeMainForm.ShowDialog();
            this.Show();
        }

        private void printTranscriptButton_Click(object sender, EventArgs e)
        {
            printTranscriptForm printTranscriptForm = new printTranscriptForm();
            this.Hide();
            printTranscriptForm.ShowDialog();
            this.Show();
        }

        private void importGradesButton_Click(object sender, EventArgs e)
        {
            importGrades importGrades = new importGrades();
            this.Hide();
            importGrades.ShowDialog();
            this.Show();
        }
    }
}
