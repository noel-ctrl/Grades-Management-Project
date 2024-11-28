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
    public partial class printTranscriptForm : Form
    {
        public printTranscriptForm()
        {
            InitializeComponent();
        }

        private void searchStudentIdButton_Click(object sender, EventArgs e)
        {
            
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
