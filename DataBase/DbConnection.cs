using System;
using System.Data.SQLite;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace JobPortalSystemProject.DataBase
{
    public static class DbConnection
    {
        private static string _databasePath = string.Empty;
        private static string _dbConnectionString = string.Empty;

        //provde database path
        public static string DataBasePath
        {
            get //to get database path
            {
                if (string.IsNullOrEmpty(_databasePath))
                {
                    // Project root folder
                    string projectPath =
                        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                        .Parent
                        .Parent
                        .FullName;

                    // Real permanent database path
                    _databasePath = Path.Combine(
                        projectPath,
                        "DataBase",
                        "JobPortal.db");
                }

                return _databasePath;
            }
        }


        //A line of text that tells your application how to connect to database
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_dbConnectionString))
                {
                    _dbConnectionString =
                        $"Data Source={DataBasePath};Version=3;";
                }

                return _dbConnectionString;
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

    }
}