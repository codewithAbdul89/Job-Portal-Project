using JobPortalSystemProject.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobPortalSystemProject.Forms
{
    public partial class ManageApplication : Form
    {
        public ManageApplication()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

        }

        private ApplicationRepository repository =
   new ApplicationRepository();

        //form load 
        private void ManageApplication_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(
    new object[]
    {
        "Pending",
        "Accepted",
        "Rejected"
    }
);
            LoadApplications();
        }


        //load Appliations data from database
        private void LoadApplications()
        {
            // GET DATA
            var applications =
                repository.GetAllApplicationsToUpdateStatus();

            // SHOW DATA
            dgvApplications.DataSource =
                applications;

            // HIDE ID
            if (
                dgvApplications.Columns[
                    "ApplicationId"
                ] != null
               )
            {
                dgvApplications.Columns[
                    "ApplicationId"
                ].Visible = false;
            }

            // GRID STYLE
            dgvApplications.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvApplications.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvApplications.MultiSelect =
                false;

            dgvApplications.ReadOnly =
                true;

            dgvApplications.AllowUserToAddRows =
                false;

            dgvApplications.RowHeadersVisible =
                false;

            // LABEL
            lblNoApplications.Visible =
                dgvApplications.Rows.Count == 0;

            if (dgvApplications.Rows.Count == 0)
            {
                lblNoApplications.Text =
                    "No applications found";
            }
        }

        //Each row click event to fill the cmb Box
        private void dgvApplications_CellClick( object sender, DataGridViewCellEventArgs e)
        {
            // CHECK ROW
            if (e.RowIndex >= 0)
            {
                // GET STATUS
                string status =
                    dgvApplications
                    .Rows[e.RowIndex]
                    .Cells["Status"]
                    .Value
                    .ToString();

                // SHOW STATUS
                cmbStatus.Text =
                    status;
            }
        }

        //Update Functionality
        private void btnUpdate_Click(object sender,EventArgs e)
        {
            // CHECK ROW
            if (
                dgvApplications
                .SelectedRows.Count == 0
               )
            {
                MessageBox.Show(
                    "Please select application first."
                );

                return;
            }

            // CHECK STATUS
            if (
                cmbStatus.SelectedIndex == -1
               )
            {
                MessageBox.Show(
                    "Please select status."
                );

                return;
            }

            // CONFIRMATION
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to update application status?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            // IF NO
            if (result == DialogResult.No)
            {
                return;
            }

            // GET ID
            int applicationId =
                Convert.ToInt32(
                    dgvApplications
                    .SelectedRows[0]
                    .Cells["ApplicationId"]
                    .Value
                );

            // GET STATUS
            string status =
                cmbStatus.Text;

            // UPDATE
            bool updated =
                repository
                .UpdateStatus(
                    applicationId,
                    status
                );

            // SUCCESS
            if (updated)
            {
                MessageBox.Show(
                    "Application status updated successfully."
                );

                LoadApplications();
            }
        }


        //exit this form
        private void btnExit_Click(object sender, EventArgs e)
        {
            AfterLoginForm afterLoginForm =
                new AfterLoginForm(
                    SessionManager.CurrentUser
                );
            afterLoginForm.Show();
            this.Hide();
        }


    }
}
