using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudApp.BusinessLogic;

namespace CrudApp
{
    public partial class MainForm : Form
    {
        DataAccess appData = new DataAccess();

        public MainForm()
        {
            InitializeComponent();
            ActiveControl = btnLogin;
        }

        #region UI Components
        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "User Name")
            {
                textBoxUserName.Text = "";
                textBoxUserName.ForeColor = Color.Black;
            }
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "")
            {
                textBoxUserName.Text = "User Name";
                textBoxUserName.ForeColor = Color.Silver;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.ForeColor = Color.Silver;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin admin = null;

            if (appData.CheckCredentials(textBoxUserName.Text, textBoxPassword.Text, ref admin))
            {

                MessageBox.Show($"Welcome to Dashboard Mr.Admin aka @{admin.AdminName}");
                Hide();
                DashboardForm dashboardForm = new DashboardForm(admin);
                dashboardForm.Show();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect. Try again");
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
        #endregion

    }
}
