using System.Collections.Generic;
using System.Text;
using FreelanceTaskManager.Models;
using FreelanceTaskManager.Repositories;

namespace FreelanceTaskManager.Services
{
    public class ReminderService
    {
        private readonly ProjectRepository _projectRepository;

        public ReminderService()
        {
            _projectRepository = new ProjectRepository();
        }

        public string GetDeadlineReminderText()
        {
            List<Project> projects = _projectRepository.GetProjectsForNextDays(3);

            if (projects.Count == 0)
                return string.Empty;

            StringBuilder text = new StringBuilder();

            text.AppendLine($"Проєктів до здачі: {projects.Count}");

            foreach (Project project in projects)
            {
                text.AppendLine($"{project.OrderNumber} — {project.GetEffectiveDeadline():dd.MM.yyyy HH:mm}");
            }

            return text.ToString();
        }
    }
}
