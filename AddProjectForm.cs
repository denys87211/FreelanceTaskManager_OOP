using System;
using System.Windows.Forms;
using FreelanceTaskManager.Helpers;
using FreelanceTaskManager.Models;
using FreelanceTaskManager.Repositories;
using FreelanceTaskManager.Services;

namespace FreelanceTaskManager
{
    public partial class AddProjectForm : Form
    {
        private readonly ProjectRepository _projectRepository;
        private readonly FolderService _folderService;

        private readonly bool _isEditMode;
        private readonly Project _project;

        private bool _isLoading = false;

        public AddProjectForm()
        {
            InitializeComponent();

            ConnectEvents();

            _projectRepository = new ProjectRepository();
            _folderService = new FolderService();

            _isEditMode = false;

            InitializeForm();
        }

        public AddProjectForm(Project project)
        {
            InitializeComponent();

            ConnectEvents();

            _projectRepository = new ProjectRepository();
            _folderService = new FolderService();

            _isEditMode = true;
            _project = project;

            InitializeForm();
            FillForm();
        }

        private void ConnectEvents()
        {
            chkRevisionDeadline.CheckedChanged -= chkRevisionDeadline_CheckedChanged;
            cmbStatus.SelectedIndexChanged -= cmbStatus_SelectedIndexChanged;
            dtpRevisionDeadline.ValueChanged -= dtpRevisionDeadline_ValueChanged;

            chkRevisionDeadline.CheckedChanged += chkRevisionDeadline_CheckedChanged;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            dtpRevisionDeadline.ValueChanged += dtpRevisionDeadline_ValueChanged;
        }

        private void InitializeForm()
        {
            _isLoading = true;

            cmbProjectType.Items.Clear();
            cmbProjectType.Items.Add("Веб-сайт");
            cmbProjectType.Items.Add("Інтернет-магазин");
            cmbProjectType.Items.Add("Лендінг");
            cmbProjectType.Items.Add("Веб-додаток");
            cmbProjectType.Items.Add("Мобільний додаток");
            cmbProjectType.Items.Add("Десктопний додаток");
            cmbProjectType.Items.Add("Telegram-бот");
            cmbProjectType.Items.Add("Чат-бот");
            cmbProjectType.Items.Add("Парсер даних");
            cmbProjectType.Items.Add("База даних");
            cmbProjectType.Items.Add("API та інтеграції");
            cmbProjectType.Items.Add("Автоматизація процесів");
            cmbProjectType.Items.Add("Тестування ПЗ");
            cmbProjectType.Items.Add("UI/UX дизайн");
            cmbProjectType.Items.Add("Графічний дизайн");
            cmbProjectType.Items.Add("Логотип");
            cmbProjectType.Items.Add("Брендинг");
            cmbProjectType.Items.Add("SEO оптимізація");
            cmbProjectType.Items.Add("Копірайтинг");
            cmbProjectType.Items.Add("Переклад");
            cmbProjectType.Items.Add("Технічна підтримка");
            cmbProjectType.Items.Add("Доопрацювання проекту");
            cmbProjectType.Items.Add("Консультація");
            cmbProjectType.Items.Add("Інше");

            cmbCurrency.Items.Clear();
            cmbCurrency.Items.Add("UAH");
            cmbCurrency.Items.Add("USD");
            cmbCurrency.Items.Add("EUR");

            cmbPriority.Items.Clear();
            cmbPriority.Items.Add("Низький");
            cmbPriority.Items.Add("Середній");
            cmbPriority.Items.Add("Високий");

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Нове");
            cmbStatus.Items.Add("В роботі");
            cmbStatus.Items.Add("Виконане");
            cmbStatus.Items.Add("Архів");
            cmbStatus.Items.Add("Доопрацювання");

            cmbProjectType.SelectedIndex = 0;
            cmbCurrency.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 1;
            cmbStatus.SelectedIndex = 0;

            dtpDeadline.Format = DateTimePickerFormat.Custom;
            dtpDeadline.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpDeadline.ShowUpDown = true;

            dtpRevisionDeadline.Format = DateTimePickerFormat.Custom;
            dtpRevisionDeadline.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpRevisionDeadline.ShowUpDown = true;
            dtpRevisionDeadline.Enabled = false;

            chkRevisionDeadline.Checked = false;

            if (_isEditMode)
            {
                Text = "Редагувати проєкт";
                btnSave.Text = "Зберегти зміни";
            }
            else
            {
                Text = "Додати проєкт";
                btnSave.Text = "Зберегти";
            }

            _isLoading = false;
        }

        private void FillForm()
        {
            if (_project == null)
                return;

            _isLoading = true;

            txtOrderNumber.Text = _project.OrderNumber;
            txtProjectTitle.Text = _project.ProjectTitle;
            txtSubject.Text = _project.Subject;
            txtSpecialty.Text = _project.Specialty;
            numPrice.Value = _project.CustomerPrice;
            rtbDescription.Text = _project.Description;

            cmbProjectType.Text = _project.ProjectType;
            cmbCurrency.Text = _project.Currency;

            cmbStatus.SelectedIndex = _project.StatusId - 1;
            cmbPriority.SelectedIndex = _project.PriorityId - 1;

            dtpDeadline.Value = _project.Deadline;

            if (_project.RevisionDeadline.HasValue)
            {
                chkRevisionDeadline.Checked = true;
                dtpRevisionDeadline.Enabled = true;
                dtpRevisionDeadline.Value = _project.RevisionDeadline.Value;
                dtpDeadline.Value = _project.RevisionDeadline.Value;
            }
            else
            {
                chkRevisionDeadline.Checked = false;
                dtpRevisionDeadline.Enabled = false;
            }

            _isLoading = false;
        }

        private void chkRevisionDeadline_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            dtpRevisionDeadline.Enabled = chkRevisionDeadline.Checked;

            if (chkRevisionDeadline.Checked)
            {
                if (cmbStatus.SelectedIndex != 4)
                    cmbStatus.SelectedIndex = 4;

                dtpDeadline.Value = dtpRevisionDeadline.Value;
            }
            else
            {
                dtpRevisionDeadline.Enabled = false;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            if (cmbStatus.SelectedIndex == 4)
            {
                chkRevisionDeadline.Checked = true;
                dtpRevisionDeadline.Enabled = true;
                dtpDeadline.Value = dtpRevisionDeadline.Value;
            }
            else
            {
                chkRevisionDeadline.Checked = false;
                dtpRevisionDeadline.Enabled = false;
            }
        }

        private void dtpRevisionDeadline_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            if (chkRevisionDeadline.Checked && cmbStatus.SelectedIndex == 4)
            {
                dtpDeadline.Value = dtpRevisionDeadline.Value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
                {
                    MessageBox.Show("Введіть номер замовлення.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtProjectTitle.Text))
                {
                    MessageBox.Show("Введіть тему проєкту.");
                    return;
                }

                string folderPath;

                if (_isEditMode)
                {
                    folderPath = _project.FolderPath;
                }
                else
                {
                    string projectsDirectory = AppSettings.GetSetting("ProjectsDirectory");

                    if (string.IsNullOrWhiteSpace(projectsDirectory))
                    {
                        MessageBox.Show(
                            "Спочатку виберіть папку для проєктів.",
                            "Помилка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    folderPath = _folderService.CreateProjectFolder(
                        projectsDirectory,
                        txtOrderNumber.Text,
                        txtProjectTitle.Text
                    );
                }

                if (chkRevisionDeadline.Checked)
                {
                    cmbStatus.SelectedIndex = 4;
                    dtpDeadline.Value = dtpRevisionDeadline.Value;
                }

                DateTime? revisionDeadline = chkRevisionDeadline.Checked
                    ? dtpRevisionDeadline.Value
                    : (DateTime?)null;

                Project project = ProjectFactory.Create(revisionDeadline);
                project.ProjectId = _isEditMode ? _project.ProjectId : 0;
                project.OrderNumber = txtOrderNumber.Text;
                project.ProjectTitle = txtProjectTitle.Text;
                project.ProjectType = cmbProjectType.Text;
                project.Subject = txtSubject.Text;
                project.Specialty = txtSpecialty.Text;
                project.CustomerPrice = numPrice.Value;
                project.Currency = cmbCurrency.Text;
                project.Description = rtbDescription.Text;
                project.Deadline = dtpDeadline.Value;
                project.RevisionDeadline = revisionDeadline;
                project.StatusId = cmbStatus.SelectedIndex + 1;
                project.PriorityId = cmbPriority.SelectedIndex + 1;
                project.FolderPath = folderPath;

                if (_isEditMode)
                {
                    _projectRepository.UpdateProject(project);

                    MessageBox.Show(
                        "Проєкт успішно оновлено.",
                        "Успіх",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    _projectRepository.AddProject(project);

                    MessageBox.Show(
                        "Проєкт успішно додано.",
                        "Успіх",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
