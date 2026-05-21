using JobPortalSystemProject.DataBase;
using JobPortalSystemProject.Models;
using System;
using System.Windows.Forms;

namespace JobPortalSystemProject.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        private void SignUpForm_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        //label to open login form
        private void labelLoginBtn_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        //SignUp Functionality
        private void SignUpUser()
        {
            try
            {
                // GET VALUES
                string name =
                    txtName.Text.Trim();

                string email =
                    txtEmail.Text.Trim();

                string password =
                    txtPassword.Text.Trim();

                // VALIDATION
                if (name == "" ||
                    email == "" ||
                    password == "")
                {
                    MessageBox.Show(
                        "Please fill all fields.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (!email.Contains("@"))
                {
                    MessageBox.Show(
                        "Invalid Email.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                User user = new User();

                user.Name = name;
                user.Email = email;
                user.Password = password;

                // OPTIONAL DEFAULT VALUES
                user.Role = "User";
                user.PostalCode = "";
                user.Gender = "";
                user.Phone = "";
                user.City = "";
                user.Province = "";
                user.Education = "";
                user.Experience = "";

                // REPOSITORY OBJECT
                UserRepository repository =
                    new UserRepository();

                // INSERT INTO DATABASE
                bool result =
                    repository.SignUp(user);

                // IF SUCCESS
                if (result)
                {
                    MessageBox.Show(
                        "Account Created Successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // OPEN LOGIN FORM
                    LoginForm login =
                        new LoginForm();

                    login.Show();

                    this.Hide();
                }

                // IF FAILED
                else
                {
                    MessageBox.Show(
                        "Email already exists.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //signup btn 
        private void btnSigUp_Click(object sender, EventArgs e)
        { 
            SignUpUser();
        }

    
        //Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            WelcomeDashboard welcomeDashboard=new WelcomeDashboard();
            welcomeDashboard.Show();
            this.Hide();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignUpUser();
            }
        }
    }
}
