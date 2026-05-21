using System;
using System.Windows.Forms;

namespace JobPortalSystemProject.Forms
{
    public partial class WelcomeDashboard : Form
    {
        public WelcomeDashboard()
        {
            InitializeComponent();

        }


        //function to show welcome message when user click on any label on top Panel
        private void labelsWelcome()
        {
            MessageBox.Show("Welcome to Job Portal System! Please login or sign up to continue.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //login btn
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm login=new LoginForm();
            login.Show();
            this.Hide();
            
        }

        //sign up btn
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUp=new SignUpForm();
            signUp.Show();
            this.Hide();
        }
        //login btn2
        private void loginBtn2_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
        //SignUpBtn2
        private void SignUpBtn2_Click(object sender, EventArgs e)
        {
            SignUpForm signUp = new SignUpForm();
            signUp.Show();
            this.Hide();
        }

        // add welcome function on evry label
        private void lblHome_Click(object sender, EventArgs e)
        {
            labelsWelcome();
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            labelsWelcome();
        }

        private void lblServices_Click(object sender, EventArgs e)
        {
            labelsWelcome();
        }

        private void lblContact_Click(object sender, EventArgs e)
        {
            labelsWelcome();
        }
    }
}
