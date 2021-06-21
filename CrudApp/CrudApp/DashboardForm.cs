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
    public partial class DashboardForm : Form
    {
        DataAccess appData = new DataAccess();
        public DashboardForm(Admin admin)
        {
            InitializeComponent();
            label_id.Text = $"ID: {admin.AdminId}";
            label_name.Text = $"Admin: {admin.AdminName}";
        }

        #region UI Components
        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            appData.RefreshUsersGridView(dataGridDashboard);
        }

        private void dataGridDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int userID = (int)dataGridDashboard.Rows[e.RowIndex].Cells[0].Value;
            UserOperationForm userOperationForm = new UserOperationForm(userID);
            userOperationForm.ShowDialog();
            dataGridDashboard.Rows.Clear();
            appData.RefreshUsersGridView(dataGridDashboard);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserOperationForm userOperationForm = new UserOperationForm();
            userOperationForm.ShowDialog();
            dataGridDashboard.Rows.Clear();
            appData.RefreshUsersGridView(dataGridDashboard);
        }

        #endregion


    }
}
