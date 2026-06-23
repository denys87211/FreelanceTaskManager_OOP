using System;
using System.Data.SQLite;
using FreelanceTaskManager.Database;

namespace FreelanceTaskManager.Services
{
    public class StatisticsService
    {
        public int GetTotalProjects()
        {
            return GetIntValue("SELECT COUNT(*) FROM projects;");
        }

        public int GetActiveProjects()
        {
            return GetIntValue("SELECT COUNT(*) FROM projects WHERE status_id IN (1, 2, 5);");
        }

        public int GetCompletedProjects()
        {
            return GetIntValue("SELECT COUNT(*) FROM projects WHERE status_id = 3;");
        }

        public int GetArchivedProjects()
        {
            return GetIntValue("SELECT COUNT(*) FROM projects WHERE status_id = 4;");
        }

        public decimal GetTotalIncome()
        {
            return GetDecimalValue("SELECT IFNULL(SUM(customer_price), 0) FROM projects;");
        }

        public decimal GetCompletedIncome()
        {
            return GetDecimalValue("SELECT IFNULL(SUM(customer_price), 0) FROM projects WHERE status_id = 3;");
        }

        public int GetTodayDeadlines()
        {
            return GetIntValue(@"
                SELECT COUNT(*) 
                FROM projects 
                WHERE DATE(deadline) = DATE('now')
                AND status_id NOT IN (3, 4);
            ");
        }

        public int GetThreeDaysDeadlines()
        {
            return GetIntValue(@"
                SELECT COUNT(*) 
                FROM projects 
                WHERE DATE(deadline) BETWEEN DATE('now') AND DATE('now', '+3 days')
                AND status_id NOT IN (3, 4);
            ");
        }

        public int GetOverdueProjects()
        {
            return GetIntValue(@"
                SELECT COUNT(*) 
                FROM projects 
                WHERE DATE(deadline) < DATE('now')
                AND status_id NOT IN (3, 4);
            ");
        }

        private int GetIntValue(string query)
        {
            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private decimal GetDecimalValue(string query)
        {
            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                return Convert.ToDecimal(command.ExecuteScalar());
            }
        }
    }
}