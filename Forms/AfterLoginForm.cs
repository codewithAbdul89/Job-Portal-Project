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
    public partial class AfterLoginForm : Form
    {

        //Construcrtor
        public AfterLoginForm(User user)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            lblUserName1.Text 
                = SessionManager.CurrentUser.Name;

            CheckRole();

            //Open the main dashboard form by default when the user logs in
            OpenChildForm(new MainDashBoard() );
        }


        private void btnColorChanger(object btnName){
            btnDashBoard.BackColor = Color.FromArgb(59, 35, 24);
            btnBrowseJobs.BackColor = Color.FromArgb(59, 35, 24);
            btnMyApplications.BackColor = Color.FromArgb(59, 35, 24);
            btnProfile.BackColor = Color.FromArgb(59, 35, 24);
            btnManageUsers.BackColor= Color.FromArgb(59, 35, 24);
            btnManageJobs.BackColor= Color.FromArgb(59, 35, 24);
            btnManageApplications.BackColor= Color.FromArgb(59, 35, 24);

            ((Button)btnName).BackColor = Color.Orange;
        }


        //to change the color of button
        private void AfterLoginForm_Load(object sender, EventArgs e)
        {
            btnDashBoard.BackColor =Color.Orange;
        }

        //check roles to hide buttons
        private void CheckRole()
        {
            if (SessionManager.CurrentUser.Role == "Admin")
            {
                btnManageUsers.Visible = true;

                btnManageJobs.Visible = true;

                btnManageApplications.Visible = true;

                lblRole.Text =
                SessionManager.CurrentUser.Role;

                lblName.Text =
                SessionManager.CurrentUser.Name;
            }

            else
            {
                btnManageUsers.Visible = false;

                btnManageJobs.Visible = false;

                btnManageApplications.Visible = false;

                lblRole.Text =
               SessionManager.CurrentUser.Name;
            }
        }


        //logOut
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            WelcomeDashboard welcomeDashboard=new WelcomeDashboard();
            welcomeDashboard.Show();
            this.Hide();
        }

        //To open child form in the main container panel
        private void OpenChildForm(Form childForm)
        {
            pnlContainer.Controls.Clear();

            childForm.TopLevel = false;

            childForm.Dock = DockStyle.Fill;

            childForm.FormBorderStyle =
                FormBorderStyle.None;

            pnlContainer.Controls.Add(childForm);

            childForm.BringToFront();

            childForm.Show();
        }

        private void btnBrowseJobs_Click(object sender, EventArgs e)
        {
            btnColorChanger(btnBrowseJobs);
            OpenChildForm(new BrowseJobsForm());
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            btnColorChanger(btnDashBoard);
            OpenChildForm(new MainDashBoard());
        }


        private void btnProfile_Click(object sender, EventArgs e)
        {
            btnColorChanger(btnProfile);
            OpenChildForm(new UserProfile());
        }

        private void btnManageJobs_Click(object sender, EventArgs e)
        {
            btnColorChanger(btnManageJobs);
            ManageJobs manageJobs = new ManageJobs();
            manageJobs.Show();
            this.Hide();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            btnColorChanger(btnManageUsers);
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
            this.Hide();
        }

        private void btnManageApplications_Click(object sender, EventArgs e)
        {
            btnColorChanger(btnManageApplications);
            ManageApplication manageApplication = new ManageApplication();
            manageApplication.Show();
            this.Hide();
        }

        private void btnMyApplications_Click(object sender, EventArgs e)
        {
            btnColorChanger(btnMyApplications);
            OpenChildForm(new MyApplicationsForm());
        }
    }
}
    