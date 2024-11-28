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
    public partial class addGrade : Form
    {
        int studentId;
        public addGrade(int studentId, string name)
        {
            InitializeComponent();
            studentIdTextBox.Text = studentId.ToString();
            studentNameTextBox.Text = name;
            this.studentId = studentId;
            yearTimePicker.Format = DateTimePickerFormat.Custom;
            yearTimePicker.CustomFormat = "yyyy";
            yearTimePicker.ShowUpDown = true;
        }

        private void addGradebutton_Click(object sender, EventArgs e)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            if (courseNumberTextBox.Text == "" || coursePrefixTextBox.Text == "" || creditHoursTextBox.Text == "" || gradeComboBox.SelectedIndex == -1 || yearTimePicker.Value == null || semesterComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int courseNumber = Convert.ToInt32(courseNumberTextBox.Text);
                string coursePrefix = coursePrefixTextBox.Text;
                int creditHours = Convert.ToInt32(creditHoursTextBox.Text);
                string grade = gradeComboBox.SelectedItem.ToString();
                DateTime year = yearTimePicker.Value;
                string semester = semesterComboBox.SelectedItem.ToString();
                conn.Open();

                string checkExists = "SELECT 1 FROM noelfr_crn WHERE coursePrefix = @coursePrefix " +
                    "AND courseNo = @courseNo AND year = @year AND semester = @semester";
                MySql.Data.MySqlClient.MySqlCommand checkExistsCmd = new MySql.Data.MySqlClient.MySqlCommand(checkExists, conn);
                checkExistsCmd.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                checkExistsCmd.Parameters.AddWithValue("@courseNo", courseNumber);
                checkExistsCmd.Parameters.AddWithValue("@year", year.Year);
                checkExistsCmd.Parameters.AddWithValue("@semester", semester);
                object exists = checkExistsCmd.ExecuteScalar();

                int crn;
                if (exists == null)
                {
                    string sql = "INSERT INTO noelfr_crn (coursePrefix, courseNo, year, semester, creditHours) " +
                        "VALUES (@coursePrefix, @courseNo, @year, @semester, @creditHours)";

                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                    cmd.Parameters.AddWithValue("@courseNo", courseNumber);
                    cmd.Parameters.AddWithValue("@year", year.Year);
                    cmd.Parameters.AddWithValue("@semester", semester);
                    cmd.Parameters.AddWithValue("@creditHours", creditHours);
                    cmd.ExecuteNonQuery();

                    crn = Convert.ToInt32(new MySqlCommand("SELECT LAST_INSERT_ID()", conn).ExecuteScalar());

                }
                else
                {
                    
                    string getCRN = "SELECT crnNo FROM noelfr_crn WHERE coursePrefix = @coursePrefix " +
                        "AND courseNo = @courseNo " +
                        "AND year = @year AND semester = @semester";
                    MySqlCommand getCRNCmd = new MySqlCommand(getCRN, conn);
                    getCRNCmd.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                    getCRNCmd.Parameters.AddWithValue("@courseNo", courseNumber);
                    getCRNCmd.Parameters.AddWithValue("@year", year.Year);
                    getCRNCmd.Parameters.AddWithValue("@semester", semester);
                    object result = getCRNCmd.ExecuteScalar();
                    if (result != null)
                    {
                        crn = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Error retrieving CRN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    

                }

                //check if student already has grade for this crn
                string checkGradeExists = "SELECT 1 FROM noelfr_studentGrades WHERE studentID = @studentID AND crnNo = @crnNo";
                MySqlCommand checkGradeExistsCmd = new MySqlCommand(checkGradeExists, conn);
                checkGradeExistsCmd.Parameters.AddWithValue("@studentID", studentId);
                checkGradeExistsCmd.Parameters.AddWithValue("@crnNo", crn);
                object gradeExists = checkGradeExistsCmd.ExecuteScalar();

                if (gradeExists != null)
                {
                    MessageBox.Show("This student already has a grade for this course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //add grade

                string gradeSql = "INSERT INTO noelfr_studentGrades (studentID, crnNo, grade) " +
                    "VALUES (@studentID, @crnNo, @grade)";
                MySqlCommand gradeCmd = new MySqlCommand(gradeSql, conn);
                gradeCmd.Parameters.AddWithValue("@studentId", studentId);
                gradeCmd.Parameters.AddWithValue("@crnNo", crn);
                gradeCmd.Parameters.AddWithValue("@grade", grade);
                gradeCmd.ExecuteNonQuery();

                updateGpa(studentId);

                MessageBox.Show("Grade added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
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


        private void coursePrefixTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void creditHoursTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void courseNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
