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
    public partial class deleteGrade : Form
    {
        int studentId;
        string studentName;
        public deleteGrade(int studentId, string studentName)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.studentName = studentName;
            gradesNameLabel.Text = studentName + "'s Grades";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "SELECT noelfr_studentGrades.grade, noelfr_crn.coursePrefix, noelfr_crn.courseNo, noelfr_crn.year, noelfr_crn.semester, noelfr_crn.creditHours " +
                             "FROM noelfr_studentGrades " +
                             "JOIN noelfr_crn ON noelfr_studentGrades.crnNo = noelfr_crn.crnNo " +
                             "WHERE noelfr_studentGrades.studentID = @studentId " +
                             "ORDER BY noelfr_crn.year, " +
                             "CASE noelfr_crn.semester " +
                             "WHEN 'spring' THEN 1 " +
                             "WHEN 'summer' THEN 2 " +
                             "WHEN 'fall' THEN 3 " +
                             "WHEN 'winter' THEN 4 " +
                             "ELSE 5 END";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    string grade = myReader["grade"].ToString();
                    string coursePrefix = myReader["coursePrefix"].ToString();
                    int courseNo = Convert.ToInt32(myReader["courseNo"]);
                    DateTime year = new DateTime(Convert.ToInt32(myReader["year"]), 1, 1);
                    string semester = myReader["semester"].ToString();
                    int creditHours = Convert.ToInt32(myReader["creditHours"]);

                    //string summary = coursePrefix + " " + courseNo + " " + year + " " + semester + " " + creditHours + " " + grade;
                    string output = coursePrefix + " " + courseNo + " " + semester + " " + year.Year + " Credit Hours: " + creditHours + " Grade: " + grade;
                    studentGradesListBox.Items.Add(output);
                }
                myReader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gradeSelectedButton_Click(object sender, EventArgs e)
        {
            if (studentGradesListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a grade to edit.");
            }
            else
            {
                //parse selected text
                string selected = studentGradesListBox.SelectedItem.ToString();
                string[] parts = selected.Split(' ');

                string coursePrefix = parts[0];
                int courseNo = Convert.ToInt32(parts[1]);
                string semester = parts[2];
                DateTime year = new DateTime(Convert.ToInt32(parts[3]), 1, 1);

                int creditHoursIndex = Array.IndexOf(parts, "Credit");
                int creditHours = int.Parse(parts[creditHoursIndex + 2]);

                int gradeIndex = Array.IndexOf(parts, "Grade:");
                string grade = parts[gradeIndex + 1];

                //ask user if they are sure they want to delete the grade
                DialogResult dialogResult = MessageBox.Show("Student ID: " + studentId
                    + "\nStudent name: " + studentName + "\nCourse: " + coursePrefix + " " + courseNo + " " + semester + " " + year.Year
                    + "\nGrade: " + grade, "Are you sure you want to delete this grade?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
                    MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                    try
                    {
                        conn.Open();
                        string delete = "DELETE FROM noelfr_studentGrades WHERE studentID = @studentId " +
                            "AND crnNo = (SELECT crnNo FROM noelfr_crn WHERE coursePrefix = @coursePrefix " +
                            "AND courseNo = @courseNo AND year = @year AND semester = @semester)";
                        MySqlCommand cmd = new MySqlCommand(delete, conn);
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                        cmd.Parameters.AddWithValue("@courseNo", courseNo);
                        cmd.Parameters.AddWithValue("@year", year.Year);
                        cmd.Parameters.AddWithValue("@semester", semester);
                        cmd.ExecuteNonQuery();
                        updateGpa(studentId);
                        MessageBox.Show("Grade deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
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
