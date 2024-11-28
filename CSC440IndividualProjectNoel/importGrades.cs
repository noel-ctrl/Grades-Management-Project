using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using MySql.Data.MySqlClient;

namespace CSC440IndividualProjectNoel
{
    public partial class importGrades : Form
    {
        public importGrades()
        {
            InitializeComponent();
        }

        private void ImportFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select Folder";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string folderName = System.IO.Path.GetFileName(folderPath);
                string[] folderInfo = folderName.Split(' ');

                if (folderInfo.Length != 3 || folderInfo[0] != "Grades" ||
                    folderInfo[1].Length != 4 || !folderInfo[1].All(char.IsDigit) ||
                    !new[] { "Spring", "Summer", "Fall", "Winter" }.Contains(folderInfo[2], StringComparer.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Folder name is not in the correct format. " +
                        "Please rename the folder to the following format: Grades Year Semester",
                        "Folder Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string folderYear = folderInfo[1];
                string folderSemester = folderInfo[2];

                string[] files = System.IO.Directory.GetFiles(folderPath);
                List<string> nonExcelFiles = new List<string>();
                List<string> invalidFiles = new List<string>();

                foreach (string file in files)
                {
                    if (file.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(file);
                        string[] fileInfo = fileName.Split(' ');

                        if (fileInfo.Length != 5 || fileInfo[2] != folderYear || !fileInfo[3].Equals(folderSemester, StringComparison.OrdinalIgnoreCase))
                        {
                            invalidFiles.Add(file);
                        }
                        else
                        {
                            importSingleFile(file);
                        }
                    }
                    else
                    {
                        nonExcelFiles.Add(file);
                    }
                }

                if (nonExcelFiles.Count > 0)
                {
                    MessageBox.Show("The following files are not Excel files and were not processed:\n" + string.Join("\n", nonExcelFiles), "Non-Excel Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (invalidFiles.Count > 0)
                {
                    MessageBox.Show("The following files do not match the folder's year and semester and were not processed:\n" + string.Join("\n", invalidFiles), "Invalid Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void importSingleButton_Click(object sender, EventArgs e)
        {
            importSingleGradesFileDialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            importSingleGradesFileDialog.Title = "Import Grades";
            if (importSingleGradesFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = importSingleGradesFileDialog.FileName;
                importSingleFile(filePath);
            }
        }

        private bool isValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != '-' && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool isValidGrade(string grade)
        {
            string[] validGrades = { "A", "B", "C", "D", "F" };
            return validGrades.Contains(grade);
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

        private void importSingleFile(string filePath)
        {
            MessageBox.Show("File Path: " + filePath);
            //parse file path to just get the file name
            int lastSlash = filePath.LastIndexOf('\\');
            string fileName = filePath.Substring(lastSlash + 1, filePath.LastIndexOf('.') - lastSlash - 1);
            MessageBox.Show("File Name: " + fileName);

            //parse file name to get course info
            string[] courseInfo = fileName.Split(' ');
            if (courseInfo.Length == 5)
            {
                string coursePrefix = courseInfo[0];
                string courseNumber = courseInfo[1];
                string year = courseInfo[2];
                string semester = courseInfo[3];
                string creditHours = courseInfo[4];
                string errorString = "The following errors were found in the file name: ";
                bool errorFound = false;

                if (!coursePrefix.All(char.IsLetter))
                {
                    errorString += "\nCourse Prefix is not all letters.";
                    errorFound = true;
                }
                if (!courseNumber.All(char.IsDigit))
                {
                    errorString += "\nCourse Number is not all digits.";
                    errorFound = true;
                }
                if (year.Length != 4 || !year.All(char.IsDigit))
                {
                    errorString += "\nYear is not 4 digits.";
                    errorFound = true;
                }
                if (semester != "Fall" && semester != "Spring" && semester != "Summer" && semester != "Winter")
                {
                    errorString += "\nSemester is not Spring, Summer, Fall or Winter.";
                    errorFound = true;
                }
                if (creditHours.Length != 1 || !char.IsDigit(creditHours[0]))
                {
                    errorString += "\nCredit Hours is not a single digit.";
                    errorFound = true;
                }
                if (errorFound == true)
                {
                    MessageBox.Show(errorString, "File Name Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //file name valid, continue
                    //MessageBox.Show("File name is valid.");
                    WorkBook workBook = WorkBook.Load(filePath);
                    WorkSheet gradesSheet = workBook.GetWorkSheet("Grades");
                    //MessageBox.Show("No of rows: "+gradesSheet.Rows.Length.ToString());
                    var headerRow = gradesSheet.Rows[0];
                    if (headerRow == null || headerRow.Columns.Length != 3 ||
                        headerRow.Columns[0].StringValue != "Name" ||
                        headerRow.Columns[1].StringValue != "ID" ||
                        headerRow.Columns[2].StringValue != "Grade")
                    {
                        MessageBox.Show("The first row must contain the words: Name, ID, and Grade.", "Header Row Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string nameColErrors = "Errors in 'Name' Column:";
                    string idColErrors = "Errors in 'ID' Column:";
                    string gradeColErrors = "Errors in 'Grade' Column:";
                    bool rowError = false;
                    for (int i = 1; i < gradesSheet.Rows.Length; i++)
                    {
                        if (gradesSheet.Rows[i].Columns[0] == null || !isValidName(gradesSheet.Rows[i].Columns[0].StringValue))
                        {
                            nameColErrors += "\nRow " + (i + 1) + ": Name is not valid.";
                            rowError = true;
                        }
                        if (gradesSheet.Rows[i].Columns[1] == null || !gradesSheet.Rows[i].Columns[1].StringValue.All(char.IsDigit))
                        {
                            idColErrors += "\nRow " + (i + 1) + ": ID is not valid.";
                            rowError = true;
                        }
                        if (gradesSheet.Rows[i].Columns[2] == null || gradesSheet.Rows[i].Columns[2].StringValue.Length != 1 || !isValidGrade(gradesSheet.Rows[i].Columns[2].StringValue))
                        {
                            gradeColErrors += "\nRow " + (i + 1) + ": Grade is not valid.";
                            rowError = true;
                        }
                    }
                    if (rowError == true)
                    {
                        MessageBox.Show(nameColErrors + "\n"
                            + idColErrors + "\n"
                            + gradeColErrors, "Row Errors",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
                        MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                        try
                        {
                            conn.Open();
                            string checkCourseExists = "SELECT COUNT(*) FROM noelfr_crn WHERE coursePrefix = @coursePrefix " +
                                "AND courseNo = @courseNo AND year = @year AND semester = @semester";

                            MySql.Data.MySqlClient.MySqlCommand checkCourseExistsCmd =
                                new MySql.Data.MySqlClient.MySqlCommand(checkCourseExists, conn);
                            checkCourseExistsCmd.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                            checkCourseExistsCmd.Parameters.AddWithValue("@courseNo", courseNumber);
                            checkCourseExistsCmd.Parameters.AddWithValue("@year", year);
                            checkCourseExistsCmd.Parameters.AddWithValue("@semester", semester);

                            int courseExists = Convert.ToInt32(checkCourseExistsCmd.ExecuteScalar());
                            if (courseExists == 0)
                            {
                                //insert course into crn table if it doesnt exist yet
                                string insertCourse = "INSERT INTO noelfr_crn (coursePrefix, courseNo, year, semester, creditHours) " +
                                    "VALUES (@coursePrefix, @courseNo, @year, @semester, @creditHours)";
                                MySql.Data.MySqlClient.MySqlCommand insertCourseCmd =
                                    new MySql.Data.MySqlClient.MySqlCommand(insertCourse, conn);
                                insertCourseCmd.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                                insertCourseCmd.Parameters.AddWithValue("@courseNo", courseNumber);
                                insertCourseCmd.Parameters.AddWithValue("@year", year);
                                insertCourseCmd.Parameters.AddWithValue("@semester", semester);
                                insertCourseCmd.Parameters.AddWithValue("@creditHours", creditHours);
                                insertCourseCmd.ExecuteNonQuery();
                            }

                            //retrieve crnNo
                            string getCRN = "SELECT crnNo FROM noelfr_crn WHERE coursePrefix = @coursePrefix " +
                                "AND courseNo = @courseNo AND year = @year AND semester = @semester";
                            MySql.Data.MySqlClient.MySqlCommand getCRNCmd = new MySql.Data.MySqlClient.MySqlCommand(getCRN, conn);
                            getCRNCmd.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                            getCRNCmd.Parameters.AddWithValue("@courseNo", courseNumber);
                            getCRNCmd.Parameters.AddWithValue("@year", year);
                            getCRNCmd.Parameters.AddWithValue("@semester", semester);
                            int crnNo = Convert.ToInt32(getCRNCmd.ExecuteScalar());


                            //insert grades
                            for (int i = 1; i < gradesSheet.Rows.Length; i++)
                            {
                                string name = gradesSheet.Rows[i].Columns[0].StringValue;
                                int id = Convert.ToInt32(gradesSheet.Rows[i].Columns[1].StringValue);
                                string grade = gradesSheet.Rows[i].Columns[2].StringValue;

                                string checkStudentExists = "SELECT COUNT(*) FROM noelfr_studentinfo WHERE studentID = @studentID";
                                MySql.Data.MySqlClient.MySqlCommand checkStudentExistsCmd =
                                    new MySql.Data.MySqlClient.MySqlCommand(checkStudentExists, conn);
                                checkStudentExistsCmd.Parameters.AddWithValue("@studentID", id);
                                int studentExists = Convert.ToInt32(checkStudentExistsCmd.ExecuteScalar());
                                if (studentExists == 0)
                                {
                                    //then add this student to the database
                                    string insertStudent = "INSERT INTO noelfr_studentinfo (studentID, name, gpa) " +
                                        "VALUES (@studentID, @name, @gpa)";
                                    MySql.Data.MySqlClient.MySqlCommand insertStudentCmd =
                                        new MySql.Data.MySqlClient.MySqlCommand(insertStudent, conn);
                                    insertStudentCmd.Parameters.AddWithValue("@studentID", id);
                                    insertStudentCmd.Parameters.AddWithValue("@name", name);
                                    insertStudentCmd.Parameters.AddWithValue("@gpa", 0.0);
                                    insertStudentCmd.ExecuteNonQuery();
                                }

                                //check if student already has grade for this crn
                                string checkGradeExists = "SELECT 1 FROM noelfr_studentGrades WHERE studentID = @studentID AND crnNo = @crnNo";
                                MySqlCommand checkGradeExistsCmd = new MySqlCommand(checkGradeExists, conn);
                                checkGradeExistsCmd.Parameters.AddWithValue("@studentID", id);
                                checkGradeExistsCmd.Parameters.AddWithValue("@crnNo", crnNo);
                                object gradeExists = checkGradeExistsCmd.ExecuteScalar();

                                if (gradeExists != null)
                                {
                                    MessageBox.Show("Student ID " + id + " already has a grade for course: " 
                                        + coursePrefix + " " + courseNumber + " " + year + " " + semester + " Credit hours: " + creditHours +".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    continue;
                                }

                                //insert grade
                                string insertGrade = "INSERT INTO noelfr_studentGrades (studentID, crnNo, grade) " +
                                    "VALUES (@studentID, @crnNo, @grade)";
                                MySql.Data.MySqlClient.MySqlCommand insertGradeCmd =
                                    new MySql.Data.MySqlClient.MySqlCommand(insertGrade, conn);
                                insertGradeCmd.Parameters.AddWithValue("@studentID", id);
                                insertGradeCmd.Parameters.AddWithValue("@grade", grade);
                                insertGradeCmd.Parameters.AddWithValue("@crnNo", crnNo);
                                insertGradeCmd.ExecuteNonQuery();

                                updateGpa(id);


                            }
                            MessageBox.Show("Grades imported successfully.");



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }

            }
            else if (courseInfo.Length != 5)
            {
                MessageBox.Show("File name is not in the correct format. " +
                    "Please rename the file to the following format: CourseName CourseNumber Semester Year CreditHours");
            }
        }

    }
}
