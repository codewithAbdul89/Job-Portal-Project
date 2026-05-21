using JobPortalSystemProject.DataBase;
using JobPortalSystemProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace JobPortalSystemProject.Forms
{
    public partial class BrowseJobsForm : Form
    {
        public BrowseJobsForm()
        {
            InitializeComponent();
        }
        
        //form load function
        private void BrowseJobsForm_Load(object sender, EventArgs e)
        {
            LoadJobs();
        }

        //make repo object
        private JobRepository repository =new JobRepository();
       
        //Load all jobs from dataBase
        private void LoadJobs()
        {
            List<Job> jobs =
                repository.GetAllJobs();
           
            dgvJobs.DataSource = jobs;

            dgvJobs.Columns["JobId"].Visible = false;

            dgvJobs.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.Fill;

            lblNoJobs.Visible =
                jobs.Count == 0;
        }

        // load jobs on the base of search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword =
                    txtSearch.Text
                    .Trim()
                    .ToLower();

                // GET ALL JOBS
                List<Job> allJobs =
                    repository.GetAllJobs();

                // FILTER JOBS
                List<Job> filteredJobs =
                    allJobs.FindAll(job =>

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

                // SHOW FILTERED DATA
                dgvJobs.DataSource = null;

                dgvJobs.DataSource =
                    filteredJobs;

                // HIDE ID COLUMN
                if (dgvJobs.Columns["JobId"] != null)
                {
                    dgvJobs.Columns["JobId"].Visible =
                        false;
                }

                // SHOW MESSAGE
                lblNoJobs.Visible =
                    filteredJobs.Count == 0;

                if (filteredJobs.Count == 0)
                {
                    lblNoJobs.Text =
                        "No matching jobs found";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                // CHECK JOB SELECTED
                if (dgvJobs.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select a job first.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // CURRENT USER
                SessionManager.RefreshUser();
                var currentUser = SessionManager.CurrentUser;

                // PROFILE VALIDATION
                if (
                    string.IsNullOrWhiteSpace(currentUser.Phone) ||
                    string.IsNullOrWhiteSpace(currentUser.City) ||
                    string.IsNullOrWhiteSpace(currentUser.Province) ||
                    string.IsNullOrWhiteSpace(currentUser.Education) ||
                    string.IsNullOrWhiteSpace(currentUser.Experience)
                   )
                {
                    MessageBox.Show(
                        "Please complete your profile first before applying for jobs.",
                        "Profile Incomplete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // GET JOB ID
                int jobId =
                    Convert.ToInt32(
                        dgvJobs.SelectedRows[0]
                        .Cells["JobId"].Value
                    );

                // CONFIRMATION
                DialogResult result =
                    MessageBox.Show(
                        "Do you want to apply for this job?",
                        "Confirm Application",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                // IF NO
                if (result == DialogResult.No)
                {
                    return;
                }

                // USER ID
                int userId =
                    currentUser.Id;

                // DATE
                DateTime applyDate =
    DateTime.Now;

                // STATUS
                string status = "Pending";

                // REPOSITORY
                ApplicationRepository repository =
                    new ApplicationRepository();

                JobPortalSystemProject.Models.Application application =
     new JobPortalSystemProject.Models.Application();

                application.UserId =
                    userId;

                application.JobId =
                    jobId;

                application.ApplyDate =
                    applyDate;

                application.Status =
                    status;

                // APPLY JOB
                bool applied =
                    repository.ApplyForJob(
                        application
                    );


                // SUCCESS
                if (applied)
                {
                    MessageBox.Show(
                        "Job applied successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                // ALREADY APPLIED
                else
                {
                    MessageBox.Show(
                        "You already applied for this job.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}