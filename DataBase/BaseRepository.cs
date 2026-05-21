using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace JobPortalSystemProject.DataBase
{
    // Cannot create object directly
    public abstract class BaseRepository
    {
        // Call ConnectionString property from DbConnection
        protected string GetConnectionString()
        {
            return DbConnection.ConnectionString;
        }

        // Call GetConnection() method from DbConnection
        protected SQLiteConnection GetConnection()
        {
            return DbConnection.GetConnection();
        }

        // Executes INSERT, UPDATE, DELETE queries Returns affected rows count if count>0 mean our operation is successful
        protected int ExecuteNonQuery(
            string sql,
            SQLiteParameter[]? parameters = null)
        {
            // Using automatically disposes memory/resources
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd =
                    new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    // call SqLite commmand 
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Executes query returning single value like  COUNT,MAX,Min or use to check if email or something exists in database
        protected object ExecuteScalar(
            string sql,
            SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd =
                    new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        // Executes SELECT query and returns DataTable
        protected DataTable ExecuteReader(
            string sql,
            SQLiteParameter[]? parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd =
                    new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (var adapter =
                        new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Safely gets string value from database reader
        protected string GetString(
            SQLiteDataReader reader,//Reader represents:Current database row
            string columnName)
        {
            int ordinal =
                reader.GetOrdinal(columnName);//provide the index of the column based on its name for fast

            return reader.IsDBNull(ordinal)
                ? string.Empty
                : reader.GetString(ordinal);
        }

        // Safely gets integer value from database reader
        protected int GetInt(
            SQLiteDataReader reader,
            string columnName)
        {
            int ordinal =
                reader.GetOrdinal(columnName);

            return reader.IsDBNull(ordinal)
                ? 0
                : reader.GetInt32(ordinal);
        }

        // Returns last inserted row ID only
        protected long GetLastInsertRowId()
        {
            object result =
                ExecuteScalar(
                    "SELECT last_insert_rowid();");

            return result != null
                ? Convert.ToInt64(result)
                : 0;
        }


        // Executes query and returns single object from database row. Used when only one row object is expected like getting user by email or id
        protected T ExecuteSingle<T>(
            string sql,
            Func<SQLiteDataReader, T> mapper,
            SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd =
                    new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return mapper(reader);
                        }

                        return default(T)!;
                    }
                }
            }
        }


        // Executes query and returns list of objects. Used when multiple records are expected.

        protected List<T> ExecuteList<T>(
            string sql,
            Func<SQLiteDataReader, T> mapper,
            SQLiteParameter[]? parameters = null)
        {
            List<T> results = new List<T>();

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd =
                    new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(mapper(reader));
                        }
                    }
                }
            }

            return results;
        }

    }
}


