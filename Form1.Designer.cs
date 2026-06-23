namespace FreelanceTaskManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabMain = new TabControl();
            tabProjects = new TabPage();
            panel1 = new Panel();
            dgvProjects = new DataGridView();
            panelButtons = new Panel();
            btnShowStatusHistory = new Button();
            btnChooseDirectory = new Button();
            btnRefresh = new Button();
            tnArchiveProject = new Button();
            btnOpenFolder = new Button();
            btnEditProject = new Button();
            btnAddProject = new Button();
            panelFilters = new Panel();
            chkUseDeadlineFilter = new CheckBox();
            dtpDeadlineFilter = new DateTimePicker();
            lblDeadlineFilter = new Label();
            cmbPriorityFilter = new ComboBox();
            lblPriorityFilter = new Label();
            cmbStatusFilter = new ComboBox();
            lblStatusFilter = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            tabCalendar = new TabPage();
            dgvCalendarProjects = new DataGridView();
            panel2 = new Panel();
            btnEditCalendarProject = new Button();
            btnOpenCalendarProjectFolder = new Button();
            monthCalendarProjects = new MonthCalendar();
            tabStatistics = new TabPage();
            lblProgressCompleted = new Label();
            progressCompleted = new ProgressBar();
            groupBoxDeadlineStats = new GroupBox();
            lblOverdueProjects = new Label();
            lblThreeDaysDeadlines = new Label();
            lblTodayDeadlines = new Label();
            groupBoxFinanceStats = new GroupBox();
            lblCompletedIncome = new Label();
            lblTotalIncome = new Label();
            groupBoxGeneralStats = new GroupBox();
            lblArchivedProjects = new Label();
            lblCompletedProjects = new Label();
            lblActiveProjects = new Label();
            lblTotalProjects = new Label();
            folderBrowserProjects = new FolderBrowserDialog();
            notifyIconReminder = new NotifyIcon(components);
            timerReminder = new System.Windows.Forms.Timer(components);
            tabMain.SuspendLayout();
            tabProjects.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            panelButtons.SuspendLayout();
            panelFilters.SuspendLayout();
            tabCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCalendarProjects).BeginInit();
            panel2.SuspendLayout();
            tabStatistics.SuspendLayout();
            groupBoxDeadlineStats.SuspendLayout();
            groupBoxFinanceStats.SuspendLayout();
            groupBoxGeneralStats.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabProjects);
            tabMain.Controls.Add(tabCalendar);
            tabMain.Controls.Add(tabStatistics);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1182, 653);
            tabMain.TabIndex = 0;
            // 
            // tabProjects
            // 
            tabProjects.Controls.Add(panel1);
            tabProjects.Controls.Add(panelButtons);
            tabProjects.Controls.Add(panelFilters);
            tabProjects.Location = new Point(4, 29);
            tabProjects.Name = "tabProjects";
            tabProjects.Padding = new Padding(3);
            tabProjects.Size = new Size(1174, 620);
            tabProjects.TabIndex = 0;
            tabProjects.Text = "Проєкти";
            tabProjects.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvProjects);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(1168, 464);
            panel1.TabIndex = 3;
            // 
            // dgvProjects
            // 
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.AllowUserToDeleteRows = false;
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Dock = DockStyle.Fill;
            dgvProjects.Location = new Point(0, 0);
            dgvProjects.MultiSelect = false;
            dgvProjects.Name = "dgvProjects";
            dgvProjects.ReadOnly = true;
            dgvProjects.RowHeadersWidth = 51;
            dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjects.Size = new Size(1168, 464);
            dgvProjects.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnShowStatusHistory);
            panelButtons.Controls.Add(btnChooseDirectory);
            panelButtons.Controls.Add(btnRefresh);
            panelButtons.Controls.Add(tnArchiveProject);
            panelButtons.Controls.Add(btnOpenFolder);
            panelButtons.Controls.Add(btnEditProject);
            panelButtons.Controls.Add(btnAddProject);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(3, 547);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1168, 70);
            panelButtons.TabIndex = 4;
            // 
            // btnShowStatusHistory
            // 
            btnShowStatusHistory.Location = new Point(983, 24);
            btnShowStatusHistory.Name = "btnShowStatusHistory";
            btnShowStatusHistory.Size = new Size(143, 29);
            btnShowStatusHistory.TabIndex = 6;
            btnShowStatusHistory.Text = "Історія статусів";
            btnShowStatusHistory.UseVisualStyleBackColor = true;
            btnShowStatusHistory.Click += btnShowStatusHistory_Click;
            // 
            // btnChooseDirectory
            // 
            btnChooseDirectory.Location = new Point(834, 24);
            btnChooseDirectory.Name = "btnChooseDirectory";
            btnChooseDirectory.Size = new Size(143, 29);
            btnChooseDirectory.TabIndex = 5;
            btnChooseDirectory.Text = "Папка проєктів";
            btnChooseDirectory.UseVisualStyleBackColor = true;
            btnChooseDirectory.Click += btnChooseDirectory_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(685, 24);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(143, 29);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Оновити";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // tnArchiveProject
            // 
            tnArchiveProject.Location = new Point(536, 24);
            tnArchiveProject.Name = "tnArchiveProject";
            tnArchiveProject.Size = new Size(143, 29);
            tnArchiveProject.TabIndex = 3;
            tnArchiveProject.Text = "Архівувати";
            tnArchiveProject.UseVisualStyleBackColor = true;
            tnArchiveProject.Click += btnArchiveProject_Click;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new Point(387, 24);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(143, 29);
            btnOpenFolder.TabIndex = 2;
            btnOpenFolder.Text = "Відкрити папку";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // btnEditProject
            // 
            btnEditProject.Location = new Point(238, 24);
            btnEditProject.Name = "btnEditProject";
            btnEditProject.Size = new Size(143, 29);
            btnEditProject.TabIndex = 1;
            btnEditProject.Text = "Редагувати";
            btnEditProject.UseVisualStyleBackColor = true;
            btnEditProject.Click += btnEditProject_Click;
            // 
            // btnAddProject
            // 
            btnAddProject.Location = new Point(89, 24);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(143, 29);
            btnAddProject.TabIndex = 0;
            btnAddProject.Text = "Додати проєкт";
            btnAddProject.UseVisualStyleBackColor = true;
            btnAddProject.Click += btnAddProject_Click;
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(chkUseDeadlineFilter);
            panelFilters.Controls.Add(dtpDeadlineFilter);
            panelFilters.Controls.Add(lblDeadlineFilter);
            panelFilters.Controls.Add(cmbPriorityFilter);
            panelFilters.Controls.Add(lblPriorityFilter);
            panelFilters.Controls.Add(cmbStatusFilter);
            panelFilters.Controls.Add(lblStatusFilter);
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(lblSearch);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(3, 3);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(1168, 80);
            panelFilters.TabIndex = 1;
            // 
            // chkUseDeadlineFilter
            // 
            chkUseDeadlineFilter.AutoSize = true;
            chkUseDeadlineFilter.Location = new Point(932, 30);
            chkUseDeadlineFilter.Name = "chkUseDeadlineFilter";
            chkUseDeadlineFilter.Size = new Size(152, 24);
            chkUseDeadlineFilter.TabIndex = 8;
            chkUseDeadlineFilter.Text = "Враховувати дату";
            chkUseDeadlineFilter.UseVisualStyleBackColor = true;
            chkUseDeadlineFilter.CheckedChanged += chkUseDeadlineFilter_CheckedChanged;
            // 
            // dtpDeadlineFilter
            // 
            dtpDeadlineFilter.Format = DateTimePickerFormat.Short;
            dtpDeadlineFilter.Location = new Point(794, 24);
            dtpDeadlineFilter.Name = "dtpDeadlineFilter";
            dtpDeadlineFilter.Size = new Size(132, 27);
            dtpDeadlineFilter.TabIndex = 7;
            dtpDeadlineFilter.ValueChanged += dtpDeadlineFilter_ValueChanged;
            // 
            // lblDeadlineFilter
            // 
            lblDeadlineFilter.AutoSize = true;
            lblDeadlineFilter.Location = new Point(695, 31);
            lblDeadlineFilter.Name = "lblDeadlineFilter";
            lblDeadlineFilter.Size = new Size(93, 20);
            lblDeadlineFilter.TabIndex = 6;
            lblDeadlineFilter.Text = "Дедлайн до:";
            // 
            // cmbPriorityFilter
            // 
            cmbPriorityFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriorityFilter.FormattingEnabled = true;
            cmbPriorityFilter.Location = new Point(441, 46);
            cmbPriorityFilter.Name = "cmbPriorityFilter";
            cmbPriorityFilter.Size = new Size(196, 28);
            cmbPriorityFilter.TabIndex = 5;
            cmbPriorityFilter.SelectedIndexChanged += cmbPriorityFilter_SelectedIndexChanged;
            // 
            // lblPriorityFilter
            // 
            lblPriorityFilter.AutoSize = true;
            lblPriorityFilter.Location = new Point(352, 49);
            lblPriorityFilter.Name = "lblPriorityFilter";
            lblPriorityFilter.Size = new Size(83, 20);
            lblPriorityFilter.TabIndex = 4;
            lblPriorityFilter.Text = "Пріоритет:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(441, 9);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(196, 28);
            cmbStatusFilter.TabIndex = 3;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Location = new Point(380, 12);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(55, 20);
            lblStatusFilter.TabIndex = 2;
            lblStatusFilter.Text = "Статус:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(69, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Введіть тему або номер замовлення";
            txtSearch.Size = new Size(270, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(5, 31);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(58, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Пошук:";
            // 
            // tabCalendar
            // 
            tabCalendar.Controls.Add(dgvCalendarProjects);
            tabCalendar.Controls.Add(panel2);
            tabCalendar.Controls.Add(monthCalendarProjects);
            tabCalendar.Location = new Point(4, 29);
            tabCalendar.Name = "tabCalendar";
            tabCalendar.Padding = new Padding(3);
            tabCalendar.Size = new Size(1174, 620);
            tabCalendar.TabIndex = 1;
            tabCalendar.Text = "Календар";
            tabCalendar.UseVisualStyleBackColor = true;
            // 
            // dgvCalendarProjects
            // 
            dgvCalendarProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCalendarProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalendarProjects.Dock = DockStyle.Fill;
            dgvCalendarProjects.Location = new Point(391, 3);
            dgvCalendarProjects.Name = "dgvCalendarProjects";
            dgvCalendarProjects.ReadOnly = true;
            dgvCalendarProjects.RowHeadersWidth = 51;
            dgvCalendarProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalendarProjects.Size = new Size(780, 558);
            dgvCalendarProjects.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnEditCalendarProject);
            panel2.Controls.Add(btnOpenCalendarProjectFolder);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(391, 561);
            panel2.Name = "panel2";
            panel2.Size = new Size(780, 56);
            panel2.TabIndex = 4;
            // 
            // btnEditCalendarProject
            // 
            btnEditCalendarProject.Location = new Point(269, 13);
            btnEditCalendarProject.Name = "btnEditCalendarProject";
            btnEditCalendarProject.Size = new Size(137, 29);
            btnEditCalendarProject.TabIndex = 2;
            btnEditCalendarProject.Text = "Редагувати";
            btnEditCalendarProject.UseVisualStyleBackColor = true;
            btnEditCalendarProject.Click += btnEditCalendarProject_Click;
            // 
            // btnOpenCalendarProjectFolder
            // 
            btnOpenCalendarProjectFolder.Location = new Point(412, 13);
            btnOpenCalendarProjectFolder.Name = "btnOpenCalendarProjectFolder";
            btnOpenCalendarProjectFolder.Size = new Size(142, 29);
            btnOpenCalendarProjectFolder.TabIndex = 3;
            btnOpenCalendarProjectFolder.Text = "Відкрити папку";
            btnOpenCalendarProjectFolder.UseVisualStyleBackColor = true;
            btnOpenCalendarProjectFolder.Click += btnOpenCalendarProjectFolder_Click;
            // 
            // monthCalendarProjects
            // 
            monthCalendarProjects.CalendarDimensions = new Size(2, 3);
            monthCalendarProjects.Dock = DockStyle.Left;
            monthCalendarProjects.Location = new Point(3, 3);
            monthCalendarProjects.MaxSelectionCount = 1;
            monthCalendarProjects.Name = "monthCalendarProjects";
            monthCalendarProjects.TabIndex = 0;
            monthCalendarProjects.DateChanged += monthCalendarProjects_DateChanged;
            // 
            // tabStatistics
            // 
            tabStatistics.Controls.Add(lblProgressCompleted);
            tabStatistics.Controls.Add(progressCompleted);
            tabStatistics.Controls.Add(groupBoxDeadlineStats);
            tabStatistics.Controls.Add(groupBoxFinanceStats);
            tabStatistics.Controls.Add(groupBoxGeneralStats);
            tabStatistics.Location = new Point(4, 29);
            tabStatistics.Name = "tabStatistics";
            tabStatistics.Padding = new Padding(3);
            tabStatistics.Size = new Size(1174, 620);
            tabStatistics.TabIndex = 2;
            tabStatistics.Text = "Статистика";
            tabStatistics.UseVisualStyleBackColor = true;
            // 
            // lblProgressCompleted
            // 
            lblProgressCompleted.AutoSize = true;
            lblProgressCompleted.Dock = DockStyle.Bottom;
            lblProgressCompleted.Location = new Point(3, 568);
            lblProgressCompleted.Name = "lblProgressCompleted";
            lblProgressCompleted.Size = new Size(147, 20);
            lblProgressCompleted.TabIndex = 5;
            lblProgressCompleted.Text = "Text: Виконання: 0%";
            // 
            // progressCompleted
            // 
            progressCompleted.Dock = DockStyle.Bottom;
            progressCompleted.Location = new Point(3, 588);
            progressCompleted.Name = "progressCompleted";
            progressCompleted.Size = new Size(1168, 29);
            progressCompleted.TabIndex = 4;
            // 
            // groupBoxDeadlineStats
            // 
            groupBoxDeadlineStats.Controls.Add(lblOverdueProjects);
            groupBoxDeadlineStats.Controls.Add(lblThreeDaysDeadlines);
            groupBoxDeadlineStats.Controls.Add(lblTodayDeadlines);
            groupBoxDeadlineStats.Dock = DockStyle.Top;
            groupBoxDeadlineStats.Location = new Point(3, 328);
            groupBoxDeadlineStats.Name = "groupBoxDeadlineStats";
            groupBoxDeadlineStats.Size = new Size(1168, 125);
            groupBoxDeadlineStats.TabIndex = 3;
            groupBoxDeadlineStats.TabStop = false;
            groupBoxDeadlineStats.Text = "Дедлайни";
            // 
            // lblOverdueProjects
            // 
            lblOverdueProjects.AutoSize = true;
            lblOverdueProjects.Location = new Point(524, 55);
            lblOverdueProjects.Name = "lblOverdueProjects";
            lblOverdueProjects.Size = new Size(152, 20);
            lblOverdueProjects.TabIndex = 2;
            lblOverdueProjects.Text = "Text: Прострочено: 0";
            // 
            // lblThreeDaysDeadlines
            // 
            lblThreeDaysDeadlines.AutoSize = true;
            lblThreeDaysDeadlines.Location = new Point(287, 55);
            lblThreeDaysDeadlines.Name = "lblThreeDaysDeadlines";
            lblThreeDaysDeadlines.Size = new Size(213, 20);
            lblThreeDaysDeadlines.TabIndex = 1;
            lblThreeDaysDeadlines.Text = "Text: Здати протягом 3 днів: 0";
            // 
            // lblTodayDeadlines
            // 
            lblTodayDeadlines.AutoSize = true;
            lblTodayDeadlines.Location = new Point(71, 55);
            lblTodayDeadlines.Name = "lblTodayDeadlines";
            lblTodayDeadlines.Size = new Size(161, 20);
            lblTodayDeadlines.TabIndex = 0;
            lblTodayDeadlines.Text = "Text: Здати сьогодні: 0";
            // 
            // groupBoxFinanceStats
            // 
            groupBoxFinanceStats.Controls.Add(lblCompletedIncome);
            groupBoxFinanceStats.Controls.Add(lblTotalIncome);
            groupBoxFinanceStats.Dock = DockStyle.Top;
            groupBoxFinanceStats.Location = new Point(3, 197);
            groupBoxFinanceStats.Name = "groupBoxFinanceStats";
            groupBoxFinanceStats.Size = new Size(1168, 131);
            groupBoxFinanceStats.TabIndex = 2;
            groupBoxFinanceStats.TabStop = false;
            groupBoxFinanceStats.Text = "Фінанси";
            // 
            // lblCompletedIncome
            // 
            lblCompletedIncome.AutoSize = true;
            lblCompletedIncome.Location = new Point(287, 53);
            lblCompletedIncome.Name = "lblCompletedIncome";
            lblCompletedIncome.Size = new Size(50, 20);
            lblCompletedIncome.TabIndex = 1;
            lblCompletedIncome.Text = "label1";
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.Location = new Point(71, 53);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new Size(193, 20);
            lblTotalIncome.TabIndex = 0;
            lblTotalIncome.Text = "Text: Загальна сума: 0 UAH";
            // 
            // groupBoxGeneralStats
            // 
            groupBoxGeneralStats.Controls.Add(lblArchivedProjects);
            groupBoxGeneralStats.Controls.Add(lblCompletedProjects);
            groupBoxGeneralStats.Controls.Add(lblActiveProjects);
            groupBoxGeneralStats.Controls.Add(lblTotalProjects);
            groupBoxGeneralStats.Dock = DockStyle.Top;
            groupBoxGeneralStats.Location = new Point(3, 3);
            groupBoxGeneralStats.Name = "groupBoxGeneralStats";
            groupBoxGeneralStats.Size = new Size(1168, 194);
            groupBoxGeneralStats.TabIndex = 0;
            groupBoxGeneralStats.TabStop = false;
            groupBoxGeneralStats.Text = "Загальна статистика";
            // 
            // lblArchivedProjects
            // 
            lblArchivedProjects.AutoSize = true;
            lblArchivedProjects.Location = new Point(386, 130);
            lblArchivedProjects.Name = "lblArchivedProjects";
            lblArchivedProjects.Size = new Size(111, 20);
            lblArchivedProjects.TabIndex = 3;
            lblArchivedProjects.Text = "Text: В архіві: 0";
            // 
            // lblCompletedProjects
            // 
            lblCompletedProjects.AutoSize = true;
            lblCompletedProjects.Location = new Point(386, 63);
            lblCompletedProjects.Name = "lblCompletedProjects";
            lblCompletedProjects.Size = new Size(127, 20);
            lblCompletedProjects.TabIndex = 2;
            lblCompletedProjects.Text = "Text: Виконано: 0";
            // 
            // lblActiveProjects
            // 
            lblActiveProjects.AutoSize = true;
            lblActiveProjects.Location = new Point(71, 130);
            lblActiveProjects.Name = "lblActiveProjects";
            lblActiveProjects.Size = new Size(186, 20);
            lblActiveProjects.TabIndex = 1;
            lblActiveProjects.Text = "Text: Активних проєктів: 0";
            // 
            // lblTotalProjects
            // 
            lblTotalProjects.AutoSize = true;
            lblTotalProjects.Location = new Point(71, 63);
            lblTotalProjects.Name = "lblTotalProjects";
            lblTotalProjects.Size = new Size(169, 20);
            lblTotalProjects.TabIndex = 0;
            lblTotalProjects.Text = "Text: Усього проєктів: 0";
            // 
            // notifyIconReminder
            // 
            notifyIconReminder.Text = "Менеджер завдань";
            // 
            // timerReminder
            // 
            timerReminder.Enabled = true;
            timerReminder.Interval = 60000;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(tabMain);
            MinimumSize = new Size(1200, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Менеджер завдань для фрілансерів";
            WindowState = FormWindowState.Maximized;
            tabMain.ResumeLayout(false);
            tabProjects.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            panelButtons.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            tabCalendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCalendarProjects).EndInit();
            panel2.ResumeLayout(false);
            tabStatistics.ResumeLayout(false);
            tabStatistics.PerformLayout();
            groupBoxDeadlineStats.ResumeLayout(false);
            groupBoxDeadlineStats.PerformLayout();
            groupBoxFinanceStats.ResumeLayout(false);
            groupBoxFinanceStats.PerformLayout();
            groupBoxGeneralStats.ResumeLayout(false);
            groupBoxGeneralStats.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabProjects;
        private TabPage tabCalendar;
        private TabPage tabStatistics;
        private Panel panelFilters;
        private TextBox txtSearch;
        private Label lblSearch;
        private ComboBox cmbStatusFilter;
        private Label lblStatusFilter;
        private ComboBox cmbPriorityFilter;
        private Label lblPriorityFilter;
        private DateTimePicker dtpDeadlineFilter;
        private Label lblDeadlineFilter;
        private CheckBox chkUseDeadlineFilter;
        private Panel panelButtons;
        private Panel panel1;
        private DataGridView dgvProjects;
        private Button btnEditProject;
        private Button btnAddProject;
        private Button btnOpenFolder;
        private Button tnArchiveProject;
        private Button btnRefresh;
        private Button btnChooseDirectory;
        private MonthCalendar monthCalendarProjects;
        private DataGridView dgvCalendarProjects;
        private GroupBox groupBoxGeneralStats;
        private Label lblTotalProjects;
        private Label lblActiveProjects;
        private Label lblArchivedProjects;
        private Label lblCompletedProjects;
        private GroupBox groupBoxDeadlineStats;
        private GroupBox groupBoxFinanceStats;
        private Label lblTotalIncome;
        private Label lblThreeDaysDeadlines;
        private Label lblTodayDeadlines;
        private Label lblOverdueProjects;
        private ProgressBar progressCompleted;
        private Label lblProgressCompleted;
        private FolderBrowserDialog folderBrowserProjects;
        private NotifyIcon notifyIconReminder;
        private System.Windows.Forms.Timer timerReminder;
        private Button btnOpenCalendarProjectFolder;
        private Button btnEditCalendarProject;
        private Label lblCompletedIncome;
        private Panel panel2;
        private Button btnShowStatusHistory;
    }
}
