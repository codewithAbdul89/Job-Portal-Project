using System;

namespace JobPortalSystemProject.Models
{
    // Represents a user of the Job Portal System.
    public class User
    {
        // Primary key of Users table.
        // Auto increment integer ID.
        public int Id { get; set; }

        // Full name of user.
        public string Name { get; set; }

        // User email address.
        // Used for login.
        public string Email { get; set; }

        // User password.
        public string Password { get; set; }

        // User role.
        // Example:
        // Admin
        // User
        public string Role { get; set; }

        public string PostalCode { get; set; }

        public string Gender { get; set; }

        // User phone number.
        public string Phone { get; set; }

        // User province/state.
        public string Province { get; set; }

        // User city.
        public string City { get; set; }

        // User education details.
        public string Education { get; set; }

        // User experience details.
        public string Experience { get; set; }

        // Constructor.
        // Sets default values.
        public User()
        {
            Name = string.Empty;

            Email = string.Empty;

            Password = string.Empty;

            Phone = string.Empty;
            PostalCode=string.Empty;
            Gender = string.Empty;

            Province = string.Empty;

            City = string.Empty;

            Education = string.Empty;

            Experience = string.Empty;

            // Default role
            Role = "User";
        }
    }
}