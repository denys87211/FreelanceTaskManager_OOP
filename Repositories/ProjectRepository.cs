using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using FreelanceTaskManager.Database;
using FreelanceTaskManager.Models;

namespace FreelanceTaskManager.Repositories
{
    public class ProjectRepository
    {
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();

            string query = @"
                SELECT 
                    p.project_id,
                    p.order_number,
                    p.project_title,
                    p.project_type,
                    p.subject,
                    p.specialty,
                    p.customer_price,
                    p.currency,
                    p.description,
                    p.deadline,
                    p.revision_deadline,
                    p.status_id,
                    s.status_name,
                    p.priority_id,
                    pr.priority_name,
                    p.folder_path,
                    p.created_at,
                    p.completed_at,
                    p.archived_at
                FROM projects p
                INNER JOIN project_statuses s ON p.status_id = s.status_id
                INNER JOIN project_priorities pr ON p.priority_id = pr.priority_id
                ORDER BY p.deadline ASC;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    projects.Add(ReadProject(reader));
                }
            }

            return projects;
        }

        public Project GetProjectById(int projectId)
        {
            string query = @"
                SELECT 
                    p.project_id,
                    p.order_number,
                    p.project_title,
                    p.project_type,
                    p.subject,
                    p.specialty,
                    p.customer_price,
                    p.currency,
                    p.description,
                    p.deadline,
                    p.revision_deadline,
                    p.status_id,
                    s.status_name,
                    p.priority_id,
                    pr.priority_name,
                    p.folder_path,
                    p.created_at,
                    p.completed_at,
                    p.archived_at
                FROM projects p
                INNER JOIN project_statuses s ON p.status_id = s.status_id
                INNER JOIN project_priorities pr ON p.priority_id = pr.priority_id
                WHERE p.project_id = @projectId;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@projectId", projectId);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadProject(reader);
                    }
                }
            }

            return null;
        }

        public int GetCurrentStatusId(int projectId)
        {
            string query = @"
                SELECT status_id
                FROM projects
                WHERE project_id = @projectId;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@projectId", projectId);

                object result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }

        public void AddProject(Project project)
        {
            string query = @"
                INSERT INTO projects (
                    order_number,
                    project_title,
                    project_type,
                    subject,
                    specialty,
                    customer_price,
                    currency,
                    description,
                    deadline,
                    revision_deadline,
                    status_id,
                    priority_id,
                    folder_path
                )
                VALUES (
                    @orderNumber,
                    @projectTitle,
                    @projectType,
                    @subject,
                    @specialty,
                    @customerPrice,
                    @currency,
                    @description,
                    @deadline,
                    @revisionDeadline,
                    @statusId,
                    @priorityId,
                    @folderPath
                );

                SELECT last_insert_rowid();
            ";

            int newProjectId;

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@orderNumber", project.OrderNumber);
                command.Parameters.AddWithValue("@projectTitle", project.ProjectTitle);
                command.Parameters.AddWithValue("@projectType", project.ProjectType);
                command.Parameters.AddWithValue("@subject", project.Subject);
                command.Parameters.AddWithValue("@specialty", project.Specialty);
                command.Parameters.AddWithValue("@customerPrice", project.CustomerPrice);
                command.Parameters.AddWithValue("@currency", project.Currency);
                command.Parameters.AddWithValue("@description", project.Description);
                command.Parameters.AddWithValue("@deadline", project.Deadline);
                command.Parameters.AddWithValue("@revisionDeadline", (object)project.RevisionDeadline ?? DBNull.Value);
                command.Parameters.AddWithValue("@statusId", project.StatusId);
                command.Parameters.AddWithValue("@priorityId", project.PriorityId);
                command.Parameters.AddWithValue("@folderPath", project.FolderPath);

                newProjectId = Convert.ToInt32(command.ExecuteScalar());
            }

            AddStatusHistory(
                newProjectId,
                0,
                project.StatusId,
                "Проєкт створено"
            );
        }

        public void UpdateProject(Project project)
        {
            int oldStatusId = GetCurrentStatusId(project.ProjectId);

            string query = @"
                UPDATE projects
                SET
                    order_number = @orderNumber,
                    project_title = @projectTitle,
                    project_type = @projectType,
                    subject = @subject,
                    specialty = @specialty,
                    customer_price = @customerPrice,
                    currency = @currency,
                    description = @description,
                    deadline = @deadline,
                    revision_deadline = @revisionDeadline,
                    status_id = @statusId,
                    priority_id = @priorityId,
                    folder_path = @folderPath,
                    updated_at = CURRENT_TIMESTAMP,
                    completed_at = CASE 
                        WHEN @statusId = 3 THEN CURRENT_TIMESTAMP
                        ELSE completed_at
                    END,
                    archived_at = CASE 
                        WHEN @statusId = 4 THEN CURRENT_TIMESTAMP
                        ELSE archived_at
                    END
                WHERE project_id = @projectId;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@projectId", project.ProjectId);
                command.Parameters.AddWithValue("@orderNumber", project.OrderNumber);
                command.Parameters.AddWithValue("@projectTitle", project.ProjectTitle);
                command.Parameters.AddWithValue("@projectType", project.ProjectType);
                command.Parameters.AddWithValue("@subject", project.Subject);
                command.Parameters.AddWithValue("@specialty", project.Specialty);
                command.Parameters.AddWithValue("@customerPrice", project.CustomerPrice);
                command.Parameters.AddWithValue("@currency", project.Currency);
                command.Parameters.AddWithValue("@description", project.Description);
                command.Parameters.AddWithValue("@deadline", project.Deadline);
                command.Parameters.AddWithValue("@revisionDeadline", (object)project.RevisionDeadline ?? DBNull.Value);
                command.Parameters.AddWithValue("@statusId", project.StatusId);
                command.Parameters.AddWithValue("@priorityId", project.PriorityId);
                command.Parameters.AddWithValue("@folderPath", project.FolderPath);

                command.ExecuteNonQuery();
            }

            if (oldStatusId != project.StatusId)
            {
                AddStatusHistory(
                    project.ProjectId,
                    oldStatusId,
                    project.StatusId,
                    "Статус змінено під час редагування проєкту"
                );
            }
        }

        public void ArchiveProject(int projectId)
        {
            int oldStatusId = GetCurrentStatusId(projectId);

            string query = @"
        UPDATE projects
        SET 
            status_id = 4,
            archived_at = CURRENT_TIMESTAMP,
            updated_at = CURRENT_TIMESTAMP
        WHERE project_id = @projectId;
    ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@projectId", projectId);
                command.ExecuteNonQuery();
            }

            if (oldStatusId != 4)
            {
                AddStatusHistory(
                    projectId,
                    oldStatusId,
                    4,
                    "Проєкт переміщено в архів"
                );
            }
        }

        public void AddStatusHistory(int projectId, int oldStatusId, int newStatusId, string comment)
        {
            string query = @"
                INSERT INTO project_status_history (
                    project_id,
                    old_status_id,
                    new_status_id,
                    comment
                )
                VALUES (
                    @projectId,
                    @oldStatusId,
                    @newStatusId,
                    @comment
                );
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@projectId", projectId);

                if (oldStatusId == 0)
                    command.Parameters.AddWithValue("@oldStatusId", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@oldStatusId", oldStatusId);

                command.Parameters.AddWithValue("@newStatusId", newStatusId);
                command.Parameters.AddWithValue("@comment", comment);

                command.ExecuteNonQuery();
            }
        }

        public string GetStatusHistoryText(int projectId)
        {
            StringBuilder text = new StringBuilder();

            string query = @"
                SELECT 
                    h.changed_at,
                    old_s.status_name AS old_status,
                    new_s.status_name AS new_status,
                    h.comment
                FROM project_status_history h
                LEFT JOIN project_statuses old_s ON h.old_status_id = old_s.status_id
                INNER JOIN project_statuses new_s ON h.new_status_id = new_s.status_id
                WHERE h.project_id = @projectId
                ORDER BY h.changed_at DESC;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@projectId", projectId);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return "Історія зміни статусів для цього проєкту відсутня.";
                    }

                    text.AppendLine("Історія зміни статусів:");
                    text.AppendLine();

                    while (reader.Read())
                    {
                        string changedAt = Convert.ToDateTime(reader["changed_at"]).ToString("dd.MM.yyyy HH:mm");

                        string oldStatus = reader["old_status"] == DBNull.Value
                            ? "Без статусу"
                            : reader["old_status"].ToString();

                        string newStatus = reader["new_status"].ToString();

                        string comment = reader["comment"] == DBNull.Value
                            ? ""
                            : reader["comment"].ToString();

                        text.AppendLine($"{changedAt}");
                        text.AppendLine($"{oldStatus} → {newStatus}");

                        if (!string.IsNullOrWhiteSpace(comment))
                            text.AppendLine($"Коментар: {comment}");

                        text.AppendLine();
                    }
                }
            }

            return text.ToString();
        }

        public List<Project> SearchProjects(string searchText, int statusId, int priorityId, DateTime? deadline)
        {
            List<Project> projects = new List<Project>();

            string query = @"
                SELECT 
                    p.project_id,
                    p.order_number,
                    p.project_title,
                    p.project_type,
                    p.subject,
                    p.specialty,
                    p.customer_price,
                    p.currency,
                    p.description,
                    p.deadline,
                    p.revision_deadline,
                    p.status_id,
                    s.status_name,
                    p.priority_id,
                    pr.priority_name,
                    p.folder_path,
                    p.created_at,
                    p.completed_at,
                    p.archived_at
                FROM projects p
                INNER JOIN project_statuses s ON p.status_id = s.status_id
                INNER JOIN project_priorities pr ON p.priority_id = pr.priority_id
                WHERE
                    (@searchText = '' 
                        OR p.order_number LIKE @searchPattern 
                        OR p.project_title LIKE @searchPattern)
                    AND (@statusId = 0 OR p.status_id = @statusId)
                    AND (@priorityId = 0 OR p.priority_id = @priorityId)
                    AND (@deadline IS NULL OR DATE(p.deadline) <= DATE(@deadline))
                ORDER BY p.deadline ASC;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchText", searchText);
                command.Parameters.AddWithValue("@searchPattern", "%" + searchText + "%");
                command.Parameters.AddWithValue("@statusId", statusId);
                command.Parameters.AddWithValue("@priorityId", priorityId);
                command.Parameters.AddWithValue("@deadline", deadline.HasValue ? (object)deadline.Value.ToString("yyyy-MM-dd") : DBNull.Value);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(ReadProject(reader));
                    }
                }
            }

            return projects;
        }

        public List<Project> GetProjectsForCalendarDate(DateTime date)
        {
            List<Project> projects = new List<Project>();

            string query = @"
                SELECT 
                    p.project_id,
                    p.order_number,
                    p.project_title,
                    p.project_type,
                    p.subject,
                    p.specialty,
                    p.customer_price,
                    p.currency,
                    p.description,
                    p.deadline,
                    p.revision_deadline,
                    p.status_id,
                    s.status_name,
                    p.priority_id,
                    pr.priority_name,
                    p.folder_path,
                    p.created_at,
                    p.completed_at,
                    p.archived_at
                FROM projects p
                INNER JOIN project_statuses s ON p.status_id = s.status_id
                INNER JOIN project_priorities pr ON p.priority_id = pr.priority_id
                WHERE DATE(p.deadline) = DATE(@date)
                ORDER BY p.deadline ASC;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(ReadProject(reader));
                    }
                }
            }

            return projects;
        }

        public List<Project> GetProjectsForNextDays(int days)
        {
            List<Project> projects = new List<Project>();

            string query = @"
                SELECT 
                    p.project_id,
                    p.order_number,
                    p.project_title,
                    p.project_type,
                    p.subject,
                    p.specialty,
                    p.customer_price,
                    p.currency,
                    p.description,
                    p.deadline,
                    p.revision_deadline,
                    p.status_id,
                    s.status_name,
                    p.priority_id,
                    pr.priority_name,
                    p.folder_path,
                    p.created_at,
                    p.completed_at,
                    p.archived_at
                FROM projects p
                INNER JOIN project_statuses s ON p.status_id = s.status_id
                INNER JOIN project_priorities pr ON p.priority_id = pr.priority_id
                WHERE 
                    DATE(p.deadline) BETWEEN DATE('now') AND DATE('now', '+' || @days || ' days')
                    AND p.status_id NOT IN (3, 4)
                ORDER BY p.deadline ASC;
            ";

            using (SQLiteConnection connection = DbConnection.GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@days", days);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(ReadProject(reader));
                    }
                }
            }

            return projects;
        }

        private Project ReadProject(SQLiteDataReader reader)
        {
            DateTime? revisionDeadline = reader["revision_deadline"] == DBNull.Value
                ? null
                : Convert.ToDateTime(reader["revision_deadline"]);

            Project project = ProjectFactory.Create(revisionDeadline);

            project.ProjectId = Convert.ToInt32(reader["project_id"]);
            project.OrderNumber = reader["order_number"].ToString();
            project.ProjectTitle = reader["project_title"].ToString();
            project.ProjectType = reader["project_type"].ToString();
            project.Subject = reader["subject"].ToString();
            project.Specialty = reader["specialty"].ToString();
            project.CustomerPrice = Convert.ToDecimal(reader["customer_price"]);
            project.Currency = reader["currency"].ToString();
            project.Description = reader["description"].ToString();
            project.Deadline = Convert.ToDateTime(reader["deadline"]);
            project.RevisionDeadline = revisionDeadline;
            project.StatusId = Convert.ToInt32(reader["status_id"]);
            project.StatusName = reader["status_name"].ToString();
            project.PriorityId = Convert.ToInt32(reader["priority_id"]);
            project.PriorityName = reader["priority_name"].ToString();
            project.FolderPath = reader["folder_path"].ToString();
            project.CreatedAt = Convert.ToDateTime(reader["created_at"]);
            project.CompletedAt = reader["completed_at"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["completed_at"]);
            project.ArchivedAt = reader["archived_at"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["archived_at"]);

            return project;
        }
    }
}
