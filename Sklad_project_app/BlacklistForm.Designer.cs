namespace Sklad_project_app
{
    partial class BlacklistForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvBlacklist = new DataGridView();
            lblInn = new Label();
            txtInn = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblReason = new Label();
            cmbReason = new ComboBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBlacklist).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(760, 25);
            lblTitle.Text = "Чёрный список контрагентов";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // dgvBlacklist
            dgvBlacklist.AllowUserToAddRows = false;
            dgvBlacklist.AllowUserToDeleteRows = false;
            dgvBlacklist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBlacklist.BackgroundColor = Color.White;
            dgvBlacklist.Location = new Point(10, 45);
            dgvBlacklist.MultiSelect = false;
            dgvBlacklist.Name = "dgvBlacklist";
            dgvBlacklist.ReadOnly = true;
            dgvBlacklist.RowHeadersVisible = false;
            dgvBlacklist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBlacklist.Size = new Size(760, 200);

            // lblInn
            lblInn.AutoSize = true;
            lblInn.Font = new Font("Arial", 9F);
            lblInn.Location = new Point(10, 260);
            lblInn.Name = "lblInn";
            lblInn.Text = "ИНН:";

            // txtInn
            txtInn.Location = new Point(10, 278);
            txtInn.Name = "txtInn";
            txtInn.Size = new Size(150, 27);

            // lblName
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial", 9F);
            lblName.Location = new Point(170, 260);
            lblName.Name = "lblName";
            lblName.Text = "Наименование:";

            // txtName
            txtName.Location = new Point(170, 278);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);

            // lblReason
            lblReason.AutoSize = true;
            lblReason.Font = new Font("Arial", 9F);
            lblReason.Location = new Point(430, 260);
            lblReason.Name = "lblReason";
            lblReason.Text = "Причина блокировки:";

            // cmbReason
            cmbReason.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReason.Location = new Point(430, 278);
            cmbReason.Name = "cmbReason";
            cmbReason.Size = new Size(220, 28);
            cmbReason.Items.Add("Налоговый должник");
            cmbReason.Items.Add("Банкрот");
            cmbReason.Items.Add("Дисквалифицированный директор");
            cmbReason.SelectedIndex = 0;

            // btnAdd
            btnAdd.BackColor = Color.FromArgb(30, 100, 200);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(10, 320);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 30);
            btnAdd.Text = "Добавить в список";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;

            // btnDelete
            btnDelete.BackColor = Color.FromArgb(200, 50, 50);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(170, 320);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 30);
            btnDelete.Text = "Удалить из списка";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // btnClose
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(640, 320);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 30);
            btnClose.Text = "Закрыть";
            btnClose.Click += btnClose_Click;

            // BlacklistForm
            BackColor = Color.White;
            ClientSize = new Size(780, 370);
            Controls.Add(lblTitle);
            Controls.Add(dgvBlacklist);
            Controls.Add(lblInn);
            Controls.Add(txtInn);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblReason);
            Controls.Add(cmbReason);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnClose);
            MaximizeBox = false;
            Name = "BlacklistForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Чёрный список контрагентов";
            Load += BlacklistForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBlacklist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvBlacklist;
        private System.Windows.Forms.Label lblInn;
        private System.Windows.Forms.TextBox txtInn;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}