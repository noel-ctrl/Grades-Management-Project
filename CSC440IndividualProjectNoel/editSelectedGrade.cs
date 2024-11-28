using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSC440IndividualProjectNoel
{
    public partial class editSelectedGrade : Form
    {
        int studentId;
        public editSelectedGrade(int studentId, string studentName, string coursePrefix, int courseNo, DateTime year, string semester, int creditHours)
        {
            InitializeComponent();
            this.studentId = studentId;
            yearTimePicker.Format = DateTimePickerFormat.Custom;
            yearTimePicker.CustomFormat = "yyyy";
            yearTimePicker.ShowUpDown = true;
            studentIdTextBox.Text = studentId.ToString();
            studentNameTextBox.Text = studentName;
            coursePrefixTextBox.Text = coursePrefix;
            courseNumberTextBox.Text = courseNo.ToString();
            yearTimePicker.Value = year;
            semesterTextBox.Text = semester;
            creditHoursTextBox.Text = creditHours.ToString();
        }

        private void updateGradebutton_Click(object sender, EventArgs e)
        {
            if (gradeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "UPDATE noelfr_studentGrades " +
                             "SET grade = @grade " +
                             "WHERE studentID = @studentId AND " +
                             "crnNo = (SELECT crnNo FROM noelfr_crn WHERE coursePrefix = @coursePrefix " +
                             "AND courseNo = @courseNo AND year = @year AND semester = @semester)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@grade", gradeComboBox.SelectedItem.ToString()[0]);
                cmd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text.ToString());
                cmd.Parameters.AddWithValue("@coursePrefix", coursePrefixTextBox.Text);
                cmd.Parameters.AddWithValue("@courseNo", courseNumberTextBox.Text);
                cmd.Parameters.AddWithValue("@year", yearTimePicker.Value.Year);
                cmd.Parameters.AddWithValue("@semester", semesterTextBox.Text);
                cmd.ExecuteNonQuery();

                updateGpa(studentId);

                MessageBox.Show("Grade updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void updateGpa(int studentId)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            conn.Open();
            string gpaSql = "SELECT noelfr_studentGrades.grade, noelfr_crn.creditHours FROM noelfr_studentGrades " +
                "JOIN noelfr_crn ON noelfr_studentGrades.crnNo = noelfr_crn.crnNo " +
                "WHERE noelfr_studentGrades.studentID = @studentId";


            MySqlCommand gpaCmd = new MySqlCommand(gpaSql, conn);
            gpaCmd.Parameters.AddWithValue("@studentId", studentId);
            MySqlDataReader reader = gpaCmd.ExecuteReader();

            double totalPoints = 0;
            int totalCreditHours = 0;

            while (reader.Read())
            {
                string grade = reader.GetString("grade");
                int creditHours = reader.GetInt32("creditHours");
                totalPoints += GetGradePoints(grade) * creditHours;
                totalCreditHours += creditHours;
            }
            reader.Close();

            double gpa = Math.Round(totalPoints / totalCreditHours, 2);

            string updateGpaSql = "UPDATE noelfr_studentinfo SET gpa = @gpa WHERE studentID = @studentId";
            MySqlCommand updateGpaCmd = new MySqlCommand(updateGpaSql, conn);
            updateGpaCmd.Parameters.AddWithValue("@gpa", gpa);
            updateGpaCmd.Parameters.AddWithValue("@studentId", studentId);
            updateGpaCmd.ExecuteNonQuery();

        }

        private double GetGradePoints(string grade)
        {
            switch (grade)
            {
                case "A": return 4.0;
                case "B": return 3.0;
                case "C": return 2.0;
                case "D": return 1.0;
                case "F": return 0.0;
                default: return 0.0;
            }
        }
    }
}
