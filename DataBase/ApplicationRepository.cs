using JobPortalSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace JobPortalSystemProject.DataBase
{
    /// <summary>
    /// Handles all database operations
    /// related to Applications table.
    /// </summary>
    public class ApplicationRepository : BaseRepository
    {
        /// <summary>
        /// Inserts new job application.
        /// Returns true if application successful.
        /// </summary>
        public bool ApplyForJob(Application application)
        {
            // Check if user already applied for same job
            string checkSql =
                @"SELECT COUNT(*)

                  FROM Applications

                  WHERE UserId = @UserId
                  AND JobId = @JobId";

            // Parameters for checking duplicate application
            SQLiteParameter[] checkParameters =
            {
                new SQLiteParameter(
                    "@UserId",
                    application.UserId
                ),

                new SQLiteParameter(
                    "@JobId",
                    application.JobId
                )
            };

            // Get count of matching applications
            int existingApplication =
                Convert.ToInt32(
                    ExecuteScalar(
                        checkSql,
                        checkParameters
                    )
                );

            // If already applied
            if (existingApplication > 0)
            {
                return false;
            }

            // INSERT query
            string sql =
                @"INSERT INTO Applications

                (UserId, JobId, ApplyDate, Status)

                VALUES

                (@UserId, @JobId,
                 @ApplyDate, @Status)";

            // Parameters for insert query
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter(
                    "@UserId",
                    application.UserId
                ),

                new SQLiteParameter(
                    "@JobId",
                    application.JobId
                ),

                new SQLiteParameter(
                    "@ApplyDate",
                    application.ApplyDate
                ),

                new SQLiteParameter(
                    "@Status",
                    application.Status
                )
            };

            // Execute INSERT query
            return ExecuteNonQuery(
                sql,
                parameters
            ) > 0;
        }


        /// <summary>
        /// Returns all applications
        /// of a specific user.
        /// </summary>
        /// use in my application

        // GET ALL APPLICATIONS OF CURRENT USER
        public object GetApplicationsByUserId(int userId)
        {
            // SQL QUERY
            string sql =
                @"SELECT
            Jobs.Title,
            Jobs.Company,
            Jobs.Location,
            Applications.ApplyDate,
            Applications.Status

          FROM Applications

          INNER JOIN Jobs
          ON Applications.JobId = Jobs.JobId

          WHERE Applications.UserId = @UserId";

            // PARAMETERS
            SQLiteParameter[] parameters =
            {
        new SQLiteParameter(
            "@UserId",
            userId
        )
    };

            // RETURN DATA
            return ExecuteList(
                sql,

                reader => new
                {
                    // JOB TITLE
                    Title =
                        GetString(
                            reader,
                            "Title"
                        ),

                    // COMPANY NAME
                    Company =
                        GetString(
                            reader,
                            "Company"
                        ),

                    // JOB LOCATION
                    Location =
                        GetString(
                            reader,
                            "Location"
                        ),

                    // APPLY DATE
                    ApplyDate =
                        GetString(
                            reader,
                            "ApplyDate"
                        ),

                    // APPLICATION STATUS
                    Status =
                        GetString(
                            reader,
                            "Status"
                        )
                },

                parameters
            );
        }

        /// <summary>
        /// Updates application status.
        /// Example:
        /// Pending, Accepted, Rejected
        /// </summary>
        public bool UpdateStatus(
            int applicationId,
            string status)
        {
            // UPDATE query
            string sql =
                @"UPDATE Applications

                  SET Status = @Status

                  WHERE ApplicationId =
                  @ApplicationId";

            // Parameters
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter(
                    "@Status",
                    status
                ),

                new SQLiteParameter(
                    "@ApplicationId",
                    applicationId
                )
            };

            // Execute UPDATE query
            return ExecuteNonQuery(
                sql,
                parameters
            ) > 0;
        }

        //To get the total number of applications of a user

        public int GetUserApplicationsCount(
    int userId)
        {
            string sql =
                @"SELECT COUNT(*)
          FROM Applications
          WHERE UserId = @UserId";

            SQLiteParameter[] parameters =
            {
        new SQLiteParameter(
            "@UserId",
            userId
        )
    };

            return Convert.ToInt32(
                ExecuteScalar(
                    sql,
                    parameters
                )
            );
        }


        // GET ALL APPLICATIONS + USER NAME + JOB TITLE + COMPANY + LOCATION + STATUS with inner join all tavles
        public object GetAllApplicationsToUpdateStatus()
        {
            // SQL QUERY
            string sql =
                @"SELECT
            Applications.ApplicationId,
            Users.Name,
            Jobs.Title,
            Jobs.Company,
            Jobs.Location,
            Applications.Status

          FROM Applications

          INNER JOIN Users
          ON Applications.UserId = Users.Id

          INNER JOIN Jobs
          ON Applications.JobId = Jobs.JobId";

            // RETURN DATA
            return ExecuteList(
                sql,

                reader => new
                {
                    // APPLICATION ID
                    ApplicationId =
                        GetInt(
                            reader,
                            "ApplicationId"
                        ),

                    // USER NAME
                    Name =
                        GetString(
                            reader,
                            "Name"
                        ),

                    // JOB TITLE
                    Title =
                        GetString(
                            reader,
                            "Title"
                        ),

                    // COMPANY
                    Company =
                        GetString(
                            reader,
                            "Company"
                        ),

                    // LOCATION
                    Location =
                        GetString(
                            reader,
                            "Location"
                        ),

                    // STATUS
                    Status =
                        GetString(
                            reader,
                            "Status"
                        )
                }
            );
        }



    }
}
