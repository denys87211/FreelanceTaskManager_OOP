using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FreelanceTaskManager.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            bool isDatabaseCreated = DbConnection.CreateDatabaseIfNotExists();

            string scriptPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Database",
                "DatabaseScript.sql"
            );

            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException("Файл DatabaseScript.sql не знайдено.");
            }

            string sqlScript = File.ReadAllText(scriptPath);

            using (SQLiteConnection connection = DbConnection.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(sqlScript, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            if (isDatabaseCreated)
            {
                MessageBox.Show(
                    "Базу даних успішно створено!",
                    "Інформація",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}