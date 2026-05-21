using System;
using JobPortalSystemProject.DataBase;
using JobPortalSystemProject.Models;
using System.Windows.Forms;
namespace JobPortalSystemProject.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        //load function to make focus on email text box
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        // LOGIN FUNCTION
        private void LoginUser()
        {
            try
            {
                // GET VALUES
                string email =
                    txtEmail.Text.Trim();

                string password =
                    txtPassword.Text.Trim();

                // VALIDATION
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(
                        "Please enter email and password.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // REPOSITORY OBJECT
                UserRepository repository =
                    new UserRepository();

                // LOGIN CHECK
                User user =
                    repository.Login(
                        email,
                        password
                    );

                // LOGIN SUCCESS
                if (user != null)
                {
                    MessageBox.Show(
                        "Login Successful",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // STORE CURRENT USER
                    SessionManager.CurrentUser =
                        user;

                    // HIDE LOGIN FORM


                    // OPEN DASHBOARD
                    AfterLoginForm dashboard =
                        new AfterLoginForm(user);

                    dashboard.Show();

                    this.Hide();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            WelcomeDashboard welcomeDashboard = new WelcomeDashboard();
            welcomeDashboard.Show();
            this.Hide();
        }

        private void labelSignUpBtn_Click(object sender, EventArgs e)
        {
            SignUpForm signUp = new SignUpForm();
            signUp.Show();
            this.Hide();
        }

        //Run login Function on Enter button
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginUser();
            }
        }
    }
}
