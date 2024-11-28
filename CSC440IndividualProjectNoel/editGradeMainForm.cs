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
    public partial class editGradeMainForm : Form
    {
        public editGradeMainForm()
        {
            InitializeComponent();
        }



        private void searchStudentIdButton_Click(object sender, EventArgs e)
        {

            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "SELECT * FROM noelfr_studentInfo WHERE studentID = " + studentIdTextBox.Text;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    int studentId = Convert.ToInt32(myReader["studentID"]);
                    string studentName = myReader["name"].ToString();
                    myReader.Close();
                    //string gpa = myReader["gpa"].ToString();
                    //MessageBox.Show("Student ID: " + studentId + "\nStudent Name: " + studentName + "\nGPA: " + gpa);
                    editGrade editGrade = new editGrade(studentId, studentName);
                    this.Hide();
                    editGrade.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("Student ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }






        private void studentIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
