using BCrypt.Net;
using JobPortalSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security;
using System.Windows.Forms;

namespace JobPortalSystemProject.DataBase
{
     
    /// Handles all database operations related to Users table.
    /// Inherits common database methods from BaseRepository.
     
    public class UserRepository : BaseRepository
    {
         
        /// Adds new user into database.
        /// Password is hashed before saving.
        /// Returns true if insert successful.
        /// Returns false if email already exists.
         
        public bool SignUp(User user)
        {
            // SQL query to check if email already exists
            string checkSql =
                @"SELECT COUNT(*)
                  FROM Users
                  WHERE Email = @Email";

            // Parameters for query
            SQLiteParameter[] checkParameters =
            {
                new SQLiteParameter("@Email", user.Email)
            };

            // ExecuteScalar returns one value only
            // COUNT(*) returns number of matching rows
            int existingUsers =
                Convert.ToInt32(
                    ExecuteScalar(checkSql, checkParameters)
                );

            // If email already exists
            if (existingUsers > 0)
            {
               MessageBox.Show(
                    "Email already exists. Please use a different email.",
                    "Duplicate Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;   
            }

            // Convert normal password into secure hashed password
            string hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(user.Password);

            // SQL INSERT query
            string sql =
                @"INSERT INTO Users
                (Name, Email, Password, Role)

                VALUES
                (@Name, @Email, @Password, @Role)";

            // Parameters for INSERT query
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@Name", user.Name),

                new SQLiteParameter("@Email", user.Email),

                new SQLiteParameter("@Password", hashedPassword),

                new SQLiteParameter("@Role", user.Role)
            };

            // Execute INSERT query
            // Returns affected rows count
            int rowsAffected =
                ExecuteNonQuery(sql, parameters);

            // If rows > 0 insert successful
            return rowsAffected > 0;
        }

         
        /// Checks login credentials.
        /// Returns matching User object if login successful.
        /// Returns null if email or password incorrect.
         
        public User? Login(string email, string password)
        {
            // SQL query to get user by email
            string sql =
                @"SELECT Id, Name, Email, Password, Role
                  FROM Users
                  WHERE Email = @Email";

            // Parameters for query
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@Email", email)
            };

            // ExecuteSingle gets one row only
            // Converts database row into User object
            User? user = ExecuteSingle(
                sql,

                reader => new User
                {
                    Id = GetInt(reader, "Id"),

                    Name = GetString(reader, "Name"),

                    Email = GetString(reader, "Email"),

                    Password = GetString(reader, "Password"),

                    Role = GetString(reader, "Role")
                },

                parameters
            );

            // If user not found
            if (user == null)
            {
                MessageBox.Show(
                    "Email not found. Please check your email or sign up.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }

            // Verify entered password with hashed password
            bool isPasswordCorrect =
                BCrypt.Net.BCrypt.Verify(
                    password,
                    user.Password
                );

            // If password incorrect
            if (!isPasswordCorrect)
            {
               MessageBox.Show(
                    "Incorrect password. Please try again.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;    
            }

            // Optional security step
            // Hide password before returning object
            user.Password = string.Empty;

            // Login successful
            return user;
        }

         
        /// Returns all users from database.
        /// Password is not included for security reasons.
         
        public List<User> GetAllUsers()
        {
            // SQL query
            string sql =
                @"SELECT Id, Name, Email, Role, Phone, Province, City, Education, Experience, PostalCode,Gender
                  FROM Users";

            // ExecuteList gets multiple rows
            // Converts rows into List<User>
            return ExecuteList(
                sql,

                reader => new User
                {
                    Id = GetInt(reader, "Id"),

                    Name = GetString(reader, "Name"),

                    Email = GetString(reader, "Email"),

                    Role = GetString(reader, "Role"),
                    
                    Phone = GetString(reader, "Phone"),

                    Province = GetString(reader, "Province"),

                    City = GetString(reader, "City"),

                    Education = GetString(reader, "Education"),

                    Experience = GetString(reader, "Experience"),

                    PostalCode=
                    GetString(reader,"PostalCode"),

                    Gender = GetString
                            (reader,"Gender")

                }
            );
        }

        public bool UpdateProfile(User user)
        {
            string sql =
                @"UPDATE Users

          SET
        PostalCode = @PostalCode,
          Phone = @Phone,
          Province=@Province,
          City = @City,
          Education = @Education,
          Experience=@Experience,
          Gender=@Gender

          WHERE Id = @Id";

            SQLiteParameter[] parameters =
            {
        new SQLiteParameter("@Gender", user.Gender),
        new SQLiteParameter("@PostalCode", user.PostalCode),
        new SQLiteParameter("@Phone", user.Phone),

        new SQLiteParameter("@Province", user.Province),

        new SQLiteParameter("@City", user.City),

        new SQLiteParameter("@Education", user.Education),
        new SQLiteParameter("@Experience", user.Experience),

        new SQLiteParameter("@Id", user.Id)
    };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        //get user by id from database
        public User GetUserById(int id)
        {
            string sql =
                @"SELECT *

          FROM Users

          WHERE Id = @Id";

            SQLiteParameter[] parameters =
            {
        new SQLiteParameter("@Id", id)
    };

            return ExecuteSingle(
                sql,

                reader => new User
                {
                    Id = GetInt(reader, "Id"),
                    Name = GetString(reader, "Name"),
                    Email = GetString(reader, "Email"),
                    Phone = GetString(reader, "Phone"),
                    Province = GetString(reader, "Province"),
                    City = GetString(reader, "City"),
                    Education = GetString(reader, "Education"),
                    Experience = GetString(reader, "Experience"),
                    Gender = GetString(reader, "Gender"),
                    PostalCode = GetString(reader, "PostalCode")
                },

                parameters
            );
        }

        // GET TOTAL USERS COUNT
        public int GetTotalUsers()
        {
            // SQL QUERY
            string sql =
                @"SELECT COUNT(*)
          FROM Users";

            // EXECUTE QUERY
            return Convert.ToInt32(
                ExecuteScalar(sql)
            );
        }

        // UPDATE USER ROLE
        public bool UpdateRole(int userId,string role)
        {
            // SQL QUERY
            string sql =
                @"UPDATE Users

          SET Role = @Role

          WHERE Id = @Id";

            // PARAMETERS
            SQLiteParameter[] parameters =
            {
        new SQLiteParameter(
            "@Role",
            role
        ),

        new SQLiteParameter(
            "@Id",
            userId
        )
    };

            // EXECUTE QUERY
            return ExecuteNonQuery(
                sql,
                parameters
            ) > 0;
        }

    }
}