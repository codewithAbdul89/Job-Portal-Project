using JobPortalSystemProject.DataBase;
using JobPortalSystemProject.Models;
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
    public partial class ManageJobs : Form
    {
        public ManageJobs()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private JobRepository repository =
    new JobRepository();

        //Btn to exit this Form
        private void btnExit_Click(object sender, EventArgs e)
        {
            AfterLoginForm afterLoginForm = new AfterLoginForm(SessionManager.CurrentUser);
            afterLoginForm.Show();
            this.Hide();
        }

        //form load function
        private void ManageJobs_Load(object sender, EventArgs e)
        {
            LoadJobs();
        }

        //load jobs from database and show in datagridview
        private void LoadJobs()
        {
            // GET JOBS
            var jobs =
                repository.GetAllJobs();

            // SHOW DATA
            dgvJobs.DataSource =
                jobs;

            // HIDE ID
            if (dgvJobs.Columns["JobId"] != null)
            {
                dgvJobs.Columns["JobId"]
                    .Visible = false;
            }

            // NO JOB MESSAGE
            lblNoJobs.Visible =
                jobs.Count == 0;

            if (jobs.Count == 0)
            {
                lblNoJobs.Text =
                    "No jobs found";
            }
        }

        //each row click function to update the txtboxes with selected job details
        private void dgvJobs_CellClick( object sender,DataGridViewCellEventArgs e)
        {
            // CHECK ROW
            if (e.RowIndex >= 0)
            {
                txtTitle.Text =
                    dgvJobs.Rows[e.RowIndex]
                    .Cells["Title"]
                    .Value
                    .ToString();

                txtCompany.Text =
                    dgvJobs.Rows[e.RowIndex]
                    .Cells["Company"]
                    .Value
                    .ToString();

                txtLocation.Text =
                    dgvJobs.Rows[e.RowIndex]
                    .Cells["Location"]
                    .Value
                    .ToString();

                txtSalary.Text =
                    dgvJobs.Rows[e.RowIndex]
                    .Cells["Salary"]
                    .Value
                    .ToString();

                txtDescription.Text =
                    dgvJobs.Rows[e.RowIndex]
                    .Cells["Description"]
                    .Value
                    .ToString();
            }
        }

        // Add Jobs
        private void btnAdd_Click(object sender,EventArgs e)
        {
            // VALIDATION
            if (
                string.IsNullOrWhiteSpace(
                    txtTitle.Text)

                ||

                string.IsNullOrWhiteSpace(
                    txtCompany.Text)

                ||

                string.IsNullOrWhiteSpace(
                    txtLocation.Text)

                ||

                string.IsNullOrWhiteSpace(
                    txtSalary.Text)

                ||

                string.IsNullOrWhiteSpace(
                    txtDescription.Text)
               )
            {
                MessageBox.Show(
                    "Please fill all fields.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // CREATE OBJECT
            Job job = new Job();

            job.Title =
                txtTitle.Text.Trim();

            job.Company =
                txtCompany.Text.Trim();

            job.Location =
                txtLocation.Text.Trim();

            job.Salary =
                txtSalary.Text.Trim();

            job.Description =
                txtDescription.Text.Trim();

            // ADD JOB
            bool added =
                repository.AddJob(job);

            // SUCCESS
            if (added)
            {
                MessageBox.Show(
                    "Job added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadJobs();

                ClearFields();
            }
        }

        //Update Jobs 
        private void btnUpdate_Click(  object sender,  EventArgs e)
        {
            // CHECK SELECTED
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a job first."
                );

                return;
            }

            // CONFIRMATION
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to update this job?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.No)
            {
                return;
            }

            // CREATE OBJECT
            Job job = new Job();

            job.JobId =
                Convert.ToInt32(
                    dgvJobs.SelectedRows[0]
                    .Cells["JobId"]
                    .Value
                );

            job.Title =
                txtTitle.Text.Trim();

            job.Company =
                txtCompany.Text.Trim();

            job.Location =
                txtLocation.Text.Trim();

            job.Salary =
                txtSalary.Text.Trim();

            job.Description =
                txtDescription.Text.Trim();

            // UPDATE
            bool updated =
                repository.updateJob(job);

            if (updated)
            {
                MessageBox.Show(
                    "Job updated successfully."
                );

                LoadJobs();

                ClearFields();
            }
        }

        //Delete Jobs
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // CHECK SELECTED
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a job first."
                );

                return;
            }

            // CONFIRMATION
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this job?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.No)
            {
                return;
            }

            // GET ID
            int jobId =
                Convert.ToInt32(
                    dgvJobs.SelectedRows[0]
                    .Cells["JobId"]
                    .Value
                );

            // DELETE
            bool deleted =
                repository.deleteJob(jobId);

            if (deleted)
            {
                MessageBox.Show(
                    "Job deleted successfully."
                );

                LoadJobs();

                ClearFields();
            }
        }

        //clear Fields after add, update or delete

        private void ClearFields()
        {
            txtTitle.Clear();

            txtCompany.Clear();

            txtLocation.Clear();

            txtSalary.Clear();

            txtDescription.Clear();
        }

        private void btnClear_Click(object sender,EventArgs e)
        {
            ClearFields();
        }


        //search Job

        private void txtSearch_TextChanged(object sender,EventArgs e)
        {
            // SEARCH TEXT
            string keyword =
                txtSearch.Text
                .Trim()
                .ToLower();

            // GET ALL JOBS
            var jobs =
                repository.GetAllJobs();

            // FILTER
            var filteredJobs =
                jobs.FindAll(job =>

                    (job.Title != null &&
                     job.Title.ToLower()
                     .Contains(keyword))

                    ||

                    (job.Company != null &&
                     job.Company.ToLower()
                     .Contains(keyword))

                    ||

                    (job.Location != null &&
                     job.Location.ToLower()
                     .Contains(keyword))
                );

            // SHOW DATA
            dgvJobs.DataSource =
                filteredJobs;

            // HIDE ID
            if (dgvJobs.Columns["JobId"] != null)
            {
                dgvJobs.Columns["JobId"]
                    .Visible = false;
            }

            // NO JOB MESSAGE
            lblNoJobs.Visible =
                filteredJobs.Count == 0;

            if (filteredJobs.Count == 0)
            {
                lblNoJobs.Text =
                    "No matching jobs found";
            }
        }

    }
}
