using JobPortalSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace JobPortalSystemProject.DataBase
{
    public class JobRepository : BaseRepository
    {
        // Adds new job into database
        public bool AddJob(Job job)
        {
            // Check if same job already exists
            string existingJobSql =
                @"SELECT COUNT(*)
                  FROM Jobs
                  WHERE Title = @Title
                  AND Company = @Company";

            // Parameters for checking duplicate job
            SQLiteParameter[] checkParameters =
            {
                new SQLiteParameter("@Title", job.Title),

                new SQLiteParameter("@Company", job.Company)
            };

            // Get matching jobs count
            int existingJob =
                Convert.ToInt32(
                    ExecuteScalar(
                        existingJobSql,
                        checkParameters
                    )
                );

            // If job already exists
            if (existingJob > 0)
            {
                MessageBox.Show(
                    "A job with same title and company already exists.",
                    "Duplicate Job",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            // INSERT query
            string sql =
                @"INSERT INTO Jobs
                (Title, Company, Location, Salary, Description)

                VALUES
                (@Title, @Company, @Location, @Salary, @Description)";

            // Parameters for insert query
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@Title", job.Title),

                new SQLiteParameter("@Company", job.Company),

                new SQLiteParameter("@Location", job.Location),

                new SQLiteParameter("@Salary", job.Salary),

                new SQLiteParameter("@Description", job.Description)
            };

            // Execute insert query
            return ExecuteNonQuery(sql, parameters) > 0;
        }
        //get all jobs
        public List<Job> GetAllJobs()
        {
            string sql =
                @"SELECT JobId, Title, Company,
          Location, Salary, Description
          FROM Jobs";

            return ExecuteList(
                sql,

                reader => new Job
                {
                    JobId = GetInt(reader, "JobId"),

                    Title = GetString(reader, "Title"),

                    Company = GetString(reader, "Company"),

                    Location = GetString(reader, "Location"),

                    Salary = GetString(reader, "Salary"),

                    Description = GetString(reader, "Description")
                }
            );
        }
       
        //To delete the job
        public bool deleteJob(int id)
        {
            string sql =
                @"DELETE FROM Jobs
                  WHERE JobId = @JobId";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@JobId", id)
            };
            return ExecuteNonQuery(sql, parameters) > 0;
        }
        //To update the jobs
        public bool updateJob(Job job)
        {
            string sql =
                @"UPDATE JOBS
                  SET Title = @Title,
                      Company = @Company,
                      Location = @Location,
                      Salary = @Salary,
                      Description = @Description
                  WHERE JobId = @JobId";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@Title", job.Title),
                new SQLiteParameter("@Company", job.Company),
                new SQLiteParameter("@Location", job.Location),
                new SQLiteParameter("@Salary", job.Salary),
                new SQLiteParameter("@Description", job.Description),
                new SQLiteParameter("@JobId", job.JobId)
            };
            return ExecuteNonQuery(sql, parameters) > 0;
        }

        //get all jobs count  from  dataBase
        public int GetTotalJobs()
        {
            string sql =
                @"SELECT COUNT(*)
          FROM Jobs";

            return Convert.ToInt32(
                ExecuteScalar(sql)
            );
        }

        // get jobs to show it in main dashboard 
        public List<Job> GetLatestJobs()
        {
            string sql =
                @"SELECT JobId,
                 Title,
                 Company,
                 Location,
                 Salary,
                 Description

          FROM Jobs

          ORDER BY JobId DESC

          LIMIT 3";

            return ExecuteList(
                sql,

                reader => new Job
                {
                    JobId =
                        GetInt(reader, "JobId"),

                    Title =
                        GetString(reader, "Title"),

                    Company =
                        GetString(reader, "Company"),

                    Location =
                        GetString(reader, "Location"),

                    Salary =
                        GetString(reader, "Salary"),

                    Description =
                        GetString(reader, "Description")
                }
            );
        }
    }
}