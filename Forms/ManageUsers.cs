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
using System.Xml.Linq;

namespace JobPortalSystemProject.Forms
{
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        // REPOSITORY OBJECT
        private UserRepository repository =
            new UserRepository();


        //Form load function
        private void ManageUsers_Load(object sender, EventArgs e)
        {
            cmbRole.Items.AddRange(
                    new object[]
                            {
                                "User",
                                "Admin"
                            }
                         );


            LoadUsers();

        }



        // LOAD ALL USERS from database
        private void LoadUsers()
        {
            // GET USERS
            var users =
                repository.GetAllUsers();

            // SHOW DATA
            dgvUsers.DataSource =
                users;

            // HIDE PASSWORD
            if (dgvUsers.Columns["Password"] != null)
            {
                dgvUsers.Columns["Password"]
                .Visible = false;
            }

            // HIDE ID
            if (dgvUsers.Columns["Id"] != null)
            {
                dgvUsers.Columns["Id"]
                .Visible = false;
            }

            // SHOW MESSAGE IF EMPTY
            lblNoUsers.Visible =
                users.Count == 0;

            if (users.Count == 0)
            {
                lblNoUsers.Text =
                    "No users found";
            }
        }


        //Searching the Jobs
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // SEARCH TEXT
            string keyword =
                txtSearch.Text
                .Trim()
                .ToLower();

            // GET ALL USERS
            var users =
                repository.GetAllUsers();

            // FILTER USERS
            var filteredUsers =
                users.FindAll(user =>

                    (user.Name != null &&
                     user.Name.ToLower()
                     .Contains(keyword))

                    ||

                    (user.Email != null &&
                     user.Email.ToLower()
                     .Contains(keyword))

                    ||

                    (user.Role != null &&
                     user.Role.ToLower()
                     .Contains(keyword))
                );

            // SHOW FILTERED USERS
            dgvUsers.DataSource =
                filteredUsers;

            // SHOW MESSAGE
            lblNoUsers.Visible =
                filteredUsers.Count == 0;

            if (filteredUsers.Count == 0)
            {
                lblNoUsers.Text =
                    "No matching users found";
            }
        }


        //Row Click function  to upate the cmbBox with the role of the selected user
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CHECK ROW
            if (e.RowIndex >= 0)
            {
                // GET ROLE
                string role =
                    dgvUsers.Rows[e.RowIndex]
                    .Cells["Role"]
                    .Value
                    .ToString();

                // SHOW ROLE
                cmbRole.Text =
                    role;
            }
        }


        // UPDATE USER function
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // CHECK USER SELECTED
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a user first."
                );

                return;
            }
            //Check ComboBox Selected
            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select role."
                );

                return;
            }

            // CONFIRMATION
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to update this user role?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            // IF NO
            if (result == DialogResult.No)
            {
                return;
            }

            // GET USER ID
            int userId =
                Convert.ToInt32(
                    dgvUsers.SelectedRows[0]
                    .Cells["Id"]
                    .Value
                );

            // GET ROLE
            string role =
                cmbRole.Text;

            // UPDATE ROLE
            bool updated =
                repository.UpdateRole(
                    userId,
                    role
                );

            // SUCCESS
            if (updated)
            {
                MessageBox.Show(
                    "User role updated successfully."
                );

                // RELOAD USERS
                LoadUsers();

                
            }
        }

        //btn to exit to afterLoginForm
        private void btnExit_Click(object sender, EventArgs e)
        {
            SessionManager.RefreshUser();

            AfterLoginForm afterLoginForm = new AfterLoginForm(SessionManager.CurrentUser);
            afterLoginForm.Show();
            // CLOSE CURRENT FORM
            this.Close();
        }
    }
}


