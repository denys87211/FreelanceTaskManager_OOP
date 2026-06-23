using System;
using System.Data.SQLite;
using System.IO;

namespace FreelanceTaskManager.Database
{
    public static class DbConnection
    {
        private static readonly string DatabaseFile = "FreelanceTaskManager.db";

        public static string ConnectionString
        {
            get
            {
                return $"Data Source={DatabaseFile};Version=3;";
            }
        }

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static bool CreateDatabaseIfNotExists()
        {
            if (!File.Exists(DatabaseFile))
            {
                SQLiteConnection.CreateFile(DatabaseFile);
                return true;
            }

            return false;
        }
    }
}