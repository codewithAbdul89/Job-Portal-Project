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
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        //load previous data if avilable
        private void UserProfile_Load(object sender, EventArgs e)
        {
            txtPhone.Focus();

            // REFRESH LATEST USER DATA
            SessionManager.RefreshUser();

            // COMBOBOX DATA
            cmbEducation.Items.AddRange(
                new object[]
                {
            "Matric",
            "Intermediate",
            "Bachelor",
            "Master",
            "PhD"
                }
            );

            cmbGender.Items.AddRange(
                new object[]
                {
            "Male",
            "Female",
            "Other"
                }
            );

            // CURRENT USER
            User currentUser =
                SessionManager.CurrentUser;

            // LOAD TEXTBOXES
            txtPhone.Text =
                currentUser.Phone;

            txtProvince.Text =
                currentUser.Province;

            txtCity.Text =
                currentUser.City;

            txtExperience.Text =
                currentUser.Experience;

            txtPostalCode.Text =
                currentUser.PostalCode;

            // EDUCATION COMBO
            if (!string.IsNullOrWhiteSpace(
                currentUser.Education))
            {
                cmbEducation.Text =
                    currentUser.Education;
            }
            else
            {
                cmbEducation.SelectedIndex = 0;
            }

            // GENDER COMBO
            if (!string.IsNullOrWhiteSpace(
                currentUser.Gender))
            {
                cmbGender.Text =
                    currentUser.Gender;
            }
            else
            {
                cmbGender.SelectedIndex = 0;
            }
        }

        // UPDATE PROFILE   
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // CURRENT USER
            User user =
                SessionManager.CurrentUser;

            // GET VALUES
            user.Phone =
                txtPhone.Text.Trim();

            user.Province =
                txtProvince.Text.Trim();

            user.City =
                txtCity.Text.Trim();

            user.Education =
                cmbEducation.Text;

            user.Experience =
                txtExperience.Text.Trim();

            user.Gender =
                cmbGender.Text;

            user.PostalCode =
                txtPostalCode.Text.Trim();

            // REPOSITORY
            UserRepository repository =
                new UserRepository();

            // UPDATE PROFILE
            bool updated =
                repository.UpdateProfile(user);

            // SUCCESS
            if (updated)
            {
                SessionManager.RefreshUser();
                MessageBox.Show(
                    "Profile updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
           
        }



    }
}
