using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FreelanceTaskManager.Helpers;
using FreelanceTaskManager.Models;
using FreelanceTaskManager.Repositories;
using FreelanceTaskManager.Services;

namespace FreelanceTaskManager
{
    public partial class MainForm : Form
    {
        private readonly ProjectRepository _projectRepository;
        private readonly ReminderService _reminderService;
        private readonly StatisticsService _statisticsService;

        public MainForm()
        {
            InitializeComponent();

            _projectRepository = new ProjectRepository();
            _reminderService = new ReminderService();
            _statisticsService = new StatisticsService();

            InitializeFilters();
            LoadProjects();
            LoadCalendarProjects(DateTime.Today);
            LoadCalendarBoldedDates();
            LoadStatistics();

            this.Shown += MainForm_Shown;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ShowDeadlineReminders();
        }

        private void ShowDeadlineReminders()
        {
            string reminderText = _reminderService.GetDeadlineReminderText();

            if (!string.IsNullOrWhiteSpace(reminderText))
            {
                notifyIconReminder.Icon = SystemIcons.Information;
                notifyIconReminder.Visible = true;
                notifyIconReminder.Text = "Менеджер завдань";

                notifyIconReminder.BalloonTipTitle = "Нагадування про дедлайни";
                notifyIconReminder.BalloonTipText = reminderText;
                notifyIconReminder.BalloonTipIcon = ToolTipIcon.Info;

                notifyIconReminder.ShowBalloonTip(10000);
            }
        }

        private void InitializeFilters()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Усі");
            cmbStatusFilter.Items.Add("Нове");
            cmbStatusFilter.Items.Add("В роботі");
            cmbStatusFilter.Items.Add("Виконане");
            cmbStatusFilter.Items.Add("Архів");
            cmbStatusFilter.Items.Add("Доопрацювання");
            cmbStatusFilter.SelectedIndex = 0;

            cmbPriorityFilter.Items.Clear();
            cmbPriorityFilter.Items.Add("Усі");
            cmbPriorityFilter.Items.Add("Низький");
            cmbPriorityFilter.Items.Add("Середній");
            cmbPriorityFilter.Items.Add("Високий");
            cmbPriorityFilter.SelectedIndex = 0;

            chkUseDeadlineFilter.Checked = false;
            dtpDeadlineFilter.Enabled = false;
        }

        private void LoadProjects()
        {
            dgvProjects.DataSource = null;
            dgvProjects.DataSource = _projectRepository.GetAllProjects();
            ConfigureProjectsGrid();
        }

        private void LoadCalendarProjects(DateTime date)
        {
            dgvCalendarProjects.DataSource = null;
            dgvCalendarProjects.DataSource = _projectRepository.GetProjectsForCalendarDate(date);
            ConfigureCalendarGrid();
        }

        private void LoadCalendarBoldedDates()
        {
            List<Project> projects = _projectRepository.GetAllProjects();

            List<DateTime> dates = projects
                .Where(p => p.StatusName != "Архів")
                .Select(p => p.Deadline.Date)
                .Distinct()
                .ToList();

            monthCalendarProjects.BoldedDates = dates.ToArray();
            monthCalendarProjects.UpdateBoldedDates();
        }

        private void LoadStatistics()
        {
            int total = _statisticsService.GetTotalProjects();
            int active = _statisticsService.GetActiveProjects();
            int completed = _statisticsService.GetCompletedProjects();
            int archived = _statisticsService.GetArchivedProjects();

            decimal totalIncome = _statisticsService.GetTotalIncome();
            decimal completedIncome = _statisticsService.GetCompletedIncome();

            int todayDeadlines = _statisticsService.GetTodayDeadlines();
            int threeDaysDeadlines = _statisticsService.GetThreeDaysDeadlines();
            int overdue = _statisticsService.GetOverdueProjects();

            lblTotalProjects.Text = $"Усього проєктів: {total}";
            lblActiveProjects.Text = $"Активних проєктів: {active}";
            lblCompletedProjects.Text = $"Виконано: {completed}";
            lblArchivedProjects.Text = $"В архіві: {archived}";

            lblTotalIncome.Text = $"Загальна сума: {totalIncome} UAH";
            lblCompletedIncome.Text = $"Зароблено з виконаних: {completedIncome} UAH";

            lblTodayDeadlines.Text = $"Здати сьогодні: {todayDeadlines}";
            lblThreeDaysDeadlines.Text = $"Здати протягом 3 днів: {threeDaysDeadlines}";
            lblOverdueProjects.Text = $"Прострочено: {overdue}";

            int percent = 0;

            if (total > 0)
                percent = completed * 100 / total;

            progressCompleted.Value = percent;
            lblProgressCompleted.Text = $"Виконання: {percent}%";
        }

        private void ConfigureProjectsGrid()
        {
            dgvProjects.AutoGenerateColumns = true;
            dgvProjects.ReadOnly = true;
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.AllowUserToDeleteRows = false;
            dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjects.MultiSelect = false;
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HideAndRenameColumns(dgvProjects);
        }

        private void ConfigureCalendarGrid()
        {
            dgvCalendarProjects.AutoGenerateColumns = true;
            dgvCalendarProjects.ReadOnly = true;
            dgvCalendarProjects.AllowUserToAddRows = false;
            dgvCalendarProjects.AllowUserToDeleteRows = false;
            dgvCalendarProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalendarProjects.MultiSelect = false;
            dgvCalendarProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HideAndRenameColumns(dgvCalendarProjects);
        }

        private void HideAndRenameColumns(DataGridView grid)
        {
            if (grid.Columns["ProjectId"] != null)
                grid.Columns["ProjectId"].HeaderText = "ID";

            if (grid.Columns["OrderNumber"] != null)
                grid.Columns["OrderNumber"].HeaderText = "Номер замовлення";

            if (grid.Columns["ProjectTitle"] != null)
                grid.Columns["ProjectTitle"].HeaderText = "Тема";

            if (grid.Columns["ProjectType"] != null)
                grid.Columns["ProjectType"].HeaderText = "Тип";

            if (grid.Columns["Subject"] != null)
                grid.Columns["Subject"].HeaderText = "Предмет";

            if (grid.Columns["Specialty"] != null)
                grid.Columns["Specialty"].Visible = false;

            if (grid.Columns["CustomerPrice"] != null)
                grid.Columns["CustomerPrice"].HeaderText = "Ціна";

            if (grid.Columns["Currency"] != null)
                grid.Columns["Currency"].HeaderText = "Валюта";

            if (grid.Columns["Description"] != null)
                grid.Columns["Description"].Visible = false;

            if (grid.Columns["Deadline"] != null)
                grid.Columns["Deadline"].HeaderText = "Дедлайн";

            if (grid.Columns["RevisionDeadline"] != null)
                grid.Columns["RevisionDeadline"].Visible = false;

            if (grid.Columns["StatusId"] != null)
                grid.Columns["StatusId"].Visible = false;

            if (grid.Columns["StatusName"] != null)
                grid.Columns["StatusName"].HeaderText = "Статус";

            if (grid.Columns["PriorityId"] != null)
                grid.Columns["PriorityId"].Visible = false;

            if (grid.Columns["PriorityName"] != null)
                grid.Columns["PriorityName"].HeaderText = "Пріоритет";

            if (grid.Columns["FolderPath"] != null)
                grid.Columns["FolderPath"].Visible = false;

            if (grid.Columns["CreatedAt"] != null)
                grid.Columns["CreatedAt"].Visible = false;

            if (grid.Columns["CompletedAt"] != null)
                grid.Columns["CompletedAt"].Visible = false;

            if (grid.Columns["ArchivedAt"] != null)
                grid.Columns["ArchivedAt"].Visible = false;
        }

        private Project GetSelectedProject()
        {
            if (dgvProjects.CurrentRow == null)
            {
                MessageBox.Show("Оберіть проєкт у таблиці.");
                return null;
            }

            return dgvProjects.CurrentRow.DataBoundItem as Project;
        }

        private Project GetSelectedCalendarProject()
        {
            if (dgvCalendarProjects.CurrentRow == null)
            {
                MessageBox.Show("Оберіть проєкт у календарі.");
                return null;
            }

            return dgvCalendarProjects.CurrentRow.DataBoundItem as Project;
        }

        private void ApplyFilters()
        {
            string searchText = txtSearch.Text.Trim();
            int statusId = cmbStatusFilter.SelectedIndex;
            int priorityId = cmbPriorityFilter.SelectedIndex;

            DateTime? deadline = null;

            if (chkUseDeadlineFilter.Checked)
                deadline = dtpDeadlineFilter.Value.Date;

            dgvProjects.DataSource = null;
            dgvProjects.DataSource = _projectRepository.SearchProjects(
                searchText,
                statusId,
                priorityId,
                deadline
            );

            ConfigureProjectsGrid();
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserProjects.ShowDialog();

            if (result == DialogResult.OK)
            {
                AppSettings.SetSetting("ProjectsDirectory", folderBrowserProjects.SelectedPath);

                MessageBox.Show(
                    "Папка для проєктів успішно збережена.",
                    "Інформація",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            AddProjectForm form = new AddProjectForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProjects();
                LoadCalendarProjects(monthCalendarProjects.SelectionStart);
                LoadCalendarBoldedDates();
                LoadStatistics();
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();

            if (project == null)
                return;

            AddProjectForm form = new AddProjectForm(project);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProjects();
                LoadCalendarProjects(monthCalendarProjects.SelectionStart);
                LoadCalendarBoldedDates();
                LoadStatistics();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbStatusFilter.SelectedIndex = 0;
            cmbPriorityFilter.SelectedIndex = 0;
            chkUseDeadlineFilter.Checked = false;

            LoadProjects();
            LoadCalendarProjects(monthCalendarProjects.SelectionStart);
            LoadCalendarBoldedDates();
            LoadStatistics();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();

            if (project == null)
                return;

            OpenProjectFolder(project);
        }

        private void btnArchiveProject_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();

            if (project == null)
                return;

            DialogResult result = MessageBox.Show(
                "Ви дійсно хочете архівувати цей проєкт?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _projectRepository.ArchiveProject(project.ProjectId);

                MessageBox.Show(
                    "Проєкт переміщено в архів.",
                    "Успіх",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadProjects();
                LoadCalendarProjects(monthCalendarProjects.SelectionStart);
                LoadCalendarBoldedDates();
                LoadStatistics();
            }
        }

        private void OpenProjectFolder(Project project)
        {
            try
            {
                if (project == null)
                {
                    MessageBox.Show(
                        "Проєкт не вибрано.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (string.IsNullOrWhiteSpace(project.FolderPath))
                {
                    MessageBox.Show(
                        "Шлях до папки відсутній.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (!Directory.Exists(project.FolderPath))
                {
                    MessageBox.Show(
                        "Папку проєкту не знайдено.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = project.FolderPath,
                    UseShellExecute = true
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Помилка відкриття папки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbPriorityFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkUseDeadlineFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpDeadlineFilter.Enabled = chkUseDeadlineFilter.Checked;
            ApplyFilters();
        }

        private void dtpDeadlineFilter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void monthCalendarProjects_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadCalendarProjects(e.Start);
        }

        private void btnEditCalendarProject_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedCalendarProject();

            if (project == null)
                return;

            AddProjectForm form = new AddProjectForm(project);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProjects();
                LoadCalendarProjects(monthCalendarProjects.SelectionStart);
                LoadCalendarBoldedDates();
                LoadStatistics();
            }
        }

        private void btnOpenCalendarProjectFolder_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedCalendarProject();

            if (project == null)
                return;

            OpenProjectFolder(project);
        }

        private void btnShowStatusHistory_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();

            if (project == null)
                return;

            string historyText = _projectRepository.GetStatusHistoryText(project.ProjectId);

            MessageBox.Show(
                historyText,
                "Історія статусів проєкту",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}