using System;
using System.Data.SQLite;
using System.IO;

namespace JobPortalSystemProject.DataBase
{
    public static class DbConnection
    {
        private static string _databasePath = string.Empty;
        private static string _dbConnectionString = string.Empty;

        public static string DataBasePath
        {
            get
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

        public static bool TestConnection()
        {
            try
            {
                if (!File.Exists(DataBasePath))
                    return false;

                using (var conn = GetConnection())
                {
                    conn.Open();

                    return conn.State ==
                        System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}