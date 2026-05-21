using JobPortalSystemProject.DataBase;
using JobPortalSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JobPortalSystemProject.Forms
{
    public partial class MainDashBoard : Form
    {
        public MainDashBoard()
        {
            InitializeComponent();
            ApplicationRepository repository =
    new ApplicationRepository();

            // TOTAL APPLICATIONS
            JobRepository repository1 =
       new JobRepository();

            lblTotalJobs.Text =
                repository1
                .GetTotalJobs()
                .ToString();

            // CURRENT all USER APPLICATIONS count
            lblAppliedJob.Text =
                repository
                .GetUserApplicationsCount(
                    SessionManager.CurrentUser.Id
                )
                .ToString();


            // REPOSITORY OBJECT
            UserRepository UserRepository =
                new UserRepository();

            // SHOW TOTAL USERS to admin only
            lblTotalusers.Text =
                UserRepository
                .GetTotalUsers()
                .ToString();

            if (SessionManager.CurrentUser.Role == "Admin")
            {
                pnlAllUser.Visible = true;
                pnlAppliedJobs.Visible = false;
            }
            else {
                pnlAllUser.Visible = false;
                pnlAppliedJobs.Visible = true;
            }



        }

        private void MainDashBoard_Load(object sender, EventArgs e)
        {
            JobRepository repository =
         new JobRepository();

            List<Job> jobs =
                repository.GetLatestJobs();

            foreach (Job job in jobs)
            {
                AddJobCard(
                    job.Title,
                    job.Company,
                    job.Location
                );
            }


        }

        private void AddJobCard(
    string title,
    string company,
    string location)
        {
            Panel card = new Panel();

            card.Size =
                new Size(1000, 80);

            card.BackColor = Color.White;

            card.Margin =
                new Padding(10);

            // TITLE
            Label lblTitle = new Label();

            lblTitle.Text = title;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold
                );

            lblTitle.Location =
                new Point(20, 15);

            lblTitle.AutoSize = true;

            // COMPANY
            Label lblCompany = new Label();

            lblCompany.Text = company;

            lblCompany.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            lblCompany.Location =
                new Point(20, 45);

            lblCompany.AutoSize = true;

            // LOCATION
            Label lblLocation = new Label();

            lblLocation.Text = location;

            lblLocation.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            lblLocation.Location =
                new Point(500, 30);

            lblLocation.AutoSize = true;

            // ADD CONTROLS
            card.Controls.Add(lblTitle);

            card.Controls.Add(lblCompany);

            card.Controls.Add(lblLocation);

            // ADD CARD INTO FLOW PANEL
            flowJobs.Controls.Add(card);
        }
    }
}
