namespace FreelanceTaskManager
{
    partial class AddProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtOrderNumber = new TextBox();
            label2 = new Label();
            txtProjectTitle = new TextBox();
            label3 = new Label();
            cmbProjectType = new ComboBox();
            txtSubject = new TextBox();
            txtSpecialty = new TextBox();
            numPrice = new NumericUpDown();
            cmbCurrency = new ComboBox();
            cmbPriority = new ComboBox();
            cmbStatus = new ComboBox();
            dtpDeadline = new DateTimePicker();
            label4 = new Label();
            chkRevisionDeadline = new CheckBox();
            dtpRevisionDeadline = new DateTimePicker();
            rtbDescription = new RichTextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 36);
            label1.Name = "label1";
            label1.Size = new Size(146, 20);
            label1.TabIndex = 0;
            label1.Text = "Номер замовлення";
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.Location = new Point(40, 59);
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.Size = new Size(257, 27);
            txtOrderNumber.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 121);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 2;
            label2.Text = "Тема проєкту";
            // 
            // txtProjectTitle
            // 
            txtProjectTitle.Location = new Point(40, 144);
            txtProjectTitle.Name = "txtProjectTitle";
            txtProjectTitle.Size = new Size(439, 27);
            txtProjectTitle.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 194);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 4;
            label3.Text = "Тип роботи";
            // 
            // cmbProjectType
            // 
            cmbProjectType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProjectType.FormattingEnabled = true;
            cmbProjectType.Location = new Point(40, 217);
            cmbProjectType.Name = "cmbProjectType";
            cmbProjectType.Size = new Size(257, 28);
            cmbProjectType.TabIndex = 5;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(152, 264);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(145, 27);
            txtSubject.TabIndex = 6;
            txtSubject.Text = "Програмування ";
            // 
            // txtSpecialty
            // 
            txtSpecialty.Location = new Point(152, 297);
            txtSpecialty.Name = "txtSpecialty";
            txtSpecialty.Size = new Size(145, 27);
            txtSpecialty.TabIndex = 7;
            txtSpecialty.Text = "Програмування ";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(40, 349);
            numPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(150, 27);
            numPrice.TabIndex = 8;
            // 
            // cmbCurrency
            // 
            cmbCurrency.FormattingEnabled = true;
            cmbCurrency.Location = new Point(40, 382);
            cmbCurrency.Name = "cmbCurrency";
            cmbCurrency.Size = new Size(150, 28);
            cmbCurrency.TabIndex = 9;
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(40, 416);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(151, 28);
            cmbPriority.TabIndex = 10;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(40, 450);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 28);
            cmbStatus.TabIndex = 11;
            // 
            // dtpDeadline
            // 
            dtpDeadline.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpDeadline.Format = DateTimePickerFormat.Custom;
            dtpDeadline.Location = new Point(40, 484);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.ShowUpDown = true;
            dtpDeadline.Size = new Size(170, 27);
            dtpDeadline.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(380, 351);
            label4.Name = "label4";
            label4.Size = new Size(188, 20);
            label4.TabIndex = 13;
            label4.Text = "Дедлайн доопрацювання";
            // 
            // chkRevisionDeadline
            // 
            chkRevisionDeadline.AutoSize = true;
            chkRevisionDeadline.Location = new Point(380, 386);
            chkRevisionDeadline.Name = "chkRevisionDeadline";
            chkRevisionDeadline.Size = new Size(263, 24);
            chkRevisionDeadline.TabIndex = 14;
            chkRevisionDeadline.Text = "Встановити дату доопрацювання";
            chkRevisionDeadline.UseVisualStyleBackColor = true;
            chkRevisionDeadline.CheckedChanged += chkRevisionDeadline_CheckedChanged;
            // 
            // dtpRevisionDeadline
            // 
            dtpRevisionDeadline.Enabled = false;
            dtpRevisionDeadline.Location = new Point(380, 417);
            dtpRevisionDeadline.Name = "dtpRevisionDeadline";
            dtpRevisionDeadline.Size = new Size(250, 27);
            dtpRevisionDeadline.TabIndex = 15;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(380, 450);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(263, 61);
            rtbDescription.TabIndex = 16;
            rtbDescription.Text = "";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(40, 564);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(151, 29);
            btnSave.TabIndex = 17;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(197, 564);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 29);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 266);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 19;
            label5.Text = "Предмет";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 300);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 20;
            label6.Text = "Спеціальність";
            // 
            // AddProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 614);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(rtbDescription);
            Controls.Add(dtpRevisionDeadline);
            Controls.Add(chkRevisionDeadline);
            Controls.Add(label4);
            Controls.Add(dtpDeadline);
            Controls.Add(cmbStatus);
            Controls.Add(cmbPriority);
            Controls.Add(cmbCurrency);
            Controls.Add(numPrice);
            Controls.Add(txtSpecialty);
            Controls.Add(txtSubject);
            Controls.Add(cmbProjectType);
            Controls.Add(label3);
            Controls.Add(txtProjectTitle);
            Controls.Add(label2);
            Controls.Add(txtOrderNumber);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProjectForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Додати проєкт";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtOrderNumber;
        private Label label2;
        private TextBox txtProjectTitle;
        private Label label3;
        private ComboBox cmbProjectType;
        private TextBox txtSubject;
        private TextBox txtSpecialty;
        private NumericUpDown numPrice;
        private ComboBox cmbCurrency;
        private ComboBox cmbPriority;
        private ComboBox cmbStatus;
        private DateTimePicker dtpDeadline;
        private Label label4;
        private CheckBox chkRevisionDeadline;
        private DateTimePicker dtpRevisionDeadline;
        private RichTextBox rtbDescription;
        private Button btnSave;
        private Button btnCancel;
        private Label label5;
        private Label label6;
    }
}