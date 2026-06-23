using System;

namespace FreelanceTaskManager.Models
{
    /// <summary>
    /// Базовий клас для всіх видів фріланс-проєктів.
    /// Містить спільні дані, а поведінку дедлайну визначають класи-нащадки.
    /// </summary>
    public abstract class Project
    {
        public int ProjectId { get; set; }

        public string OrderNumber { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectType { get; set; }

        public string Subject { get; set; }
        public string Specialty { get; set; }

        public decimal CustomerPrice { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }
        public DateTime? RevisionDeadline { get; set; }

        public int StatusId { get; set; }
        public int PriorityId { get; set; }

        public string StatusName { get; set; }
        public string PriorityName { get; set; }

        public string FolderPath { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? ArchivedAt { get; set; }

        [System.ComponentModel.DisplayName("Категорія проєкту")]
        public abstract string ProjectCategory { get; }

        public abstract DateTime GetEffectiveDeadline();
    }
}
