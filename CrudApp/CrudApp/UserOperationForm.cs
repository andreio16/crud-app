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
    public partial class UserOperationForm : Form
    {
        User user;
        DataAccess appData = new DataAccess();
        public UserOperationForm(int userID)
        {
            InitializeComponent();
            this.Text = "Edit/Delete User";
            btnAdd.Enabled = false;
            btnAdd.Visible = false;
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            user = appData.SelectUserWithUserId(userID);
            textBoxUserName.Text  = user.UserName;
            textBoxLastName.Text  = user.LastName;
            textBoxFirstName.Text = user.FirstName;
            textBoxUserName.ForeColor  = Color.Black;
            textBoxLastName.ForeColor  = Color.Black;
            textBoxFirstName.ForeColor = Color.Black;
        }

        public UserOperationForm()
        {
            InitializeComponent();
            this.Text = "Add User";
            btnSave.Enabled = false;
            btnSave.Visible = false;
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
        }

        #region UI Components
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = textBoxUserName.Text;
                var password = textBoxPassword.Text;
                var lastName = textBoxLastName.Text;
                var firstName = textBoxFirstName.Text;
                user = new User(userName, firstName, lastName, password);
                appData.InsertNewUser(user);
                MessageBox.Show("User has been added to the dashboard!");
            }
            catch (Exception ex) { MessageBox.Show("Insert query error: " + ex.Message); }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = textBoxUserName.Text;
                var password = textBoxPassword.Text;
                var lastName = textBoxLastName.Text;
                var firstName = textBoxFirstName.Text;
                user = new User(user.UserId, userName, firstName, lastName);
                appData.UpdateExistingUser(user);
                MessageBox.Show("User updated successfully!");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Update query error: " + ex.Message); }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                appData.DeleteUserWithID(user.UserId);
                MessageBox.Show("User deleted successfully!");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Update query error: " + ex.Message); }
        }
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
        private void textBoxLastName_Enter(object sender, EventArgs e)
        {

            if (textBoxLastName.Text == "Last Name")
            {
                textBoxLastName.Text = "";
                textBoxLastName.ForeColor = Color.Black;
            }
        }
        private void textBoxLastName_Leave(object sender, EventArgs e)
        {

            if (textBoxLastName.Text == "")
            {
                textBoxLastName.Text = "Last Name";
                textBoxLastName.ForeColor = Color.Silver;
            }
        }
        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {

            if (textBoxFirstName.Text == "First Name")
            {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = Color.Black;
            }
        }
        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {

            if (textBoxFirstName.Text == "")
            {
                textBoxFirstName.Text = "First Name";
                textBoxFirstName.ForeColor = Color.Silver;
            }
        }

        #endregion




    }
}
