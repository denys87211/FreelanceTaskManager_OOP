using System.Data.SQLite;
using FreelanceTaskManager.Database;

namespace FreelanceTaskManager.Helpers
{
    public static class AppSettings
    {
        public static string GetSetting(string key)
        {
            string query = @"
                SELECT setting_value
                FROM app_settings
                WHERE setting_key = @key;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@key", key);

                object result = command.ExecuteScalar();

                return result?.ToString();
            }
        }

        public static void SetSetting(string key, string value)
        {
            string query = @"
                UPDATE app_settings
                SET setting_value = @value
                WHERE setting_key = @key;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@key", key);
                command.Parameters.AddWithValue("@value", value);

                command.ExecuteNonQuery();
            }
        }
    }
}