using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class LoginForm : Form
    {
        public bool LoginFlag { get; set; }
        public int UserID { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            LoginFlag = false;
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonLogin_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.UsersTableAdapter usersTable = new DataSet1TableAdapters.UsersTableAdapter();

            DataTable dt = usersTable.GetDataByUsernameAndPassword(metroTextBoxUser.Text, metroTextBoxPassword.Text);

            if (dt.Rows.Count > 0)
            {
                // Valid login
                MessageBox.Show("Login Successful");
                UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                LoginFlag = true;
            }
            else
            {
                // Not valid
                MessageBox.Show("Login Unsuccessful");
                LoginFlag = false;
            }
            Close();
        }
    }
}
