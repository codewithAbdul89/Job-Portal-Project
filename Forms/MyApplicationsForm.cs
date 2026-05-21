using JobPortalSystemProject.DataBase;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JobPortalSystemProject.Forms
{
    public partial class MyApplicationsForm : Form
    {
        public MyApplicationsForm()
        {
            InitializeComponent();
          

        }

        private void MyApplicationsForm_Load(object sender, EventArgs e)
        {
            LoadApplications();
        }

        // LOAD USER APPLICATIONS
        private void LoadApplications()
        {
            // CURRENT USER ID
            int userId =
                SessionManager
                .CurrentUser
                .Id;

            // REPOSITORY OBJECT
            ApplicationRepository repository =
                new ApplicationRepository();

            // GET USER APPLICATIONS
            var applications =
                repository.GetApplicationsByUserId(
                    userId
                );

            // SHOW DATA IN GRID
            dgvApplications.DataSource =
                applications;

            // MAKE GRID BEAUTIFUL
            dgvApplications.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // SHOW MESSAGE IF NO APPLICATIONS
            lblNoApplications.Visible =
                dgvApplications.Rows.Count == 0;
        }

    }
}
