namespace ClinicAppointmentManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuExit;

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel inputLayout;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.TextBox txtAppointmentId;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.ComboBox cboStatus;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnResetFilter;

        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuFile = new System.Windows.Forms.ToolStripMenuItem();
            menuExport = new System.Windows.Forms.ToolStripMenuItem();
            menuExit = new System.Windows.Forms.ToolStripMenuItem();

            mainLayout = new System.Windows.Forms.TableLayoutPanel();
            inputLayout = new System.Windows.Forms.TableLayoutPanel();

            lblTitle = new System.Windows.Forms.Label();

            lblId = new System.Windows.Forms.Label();
            lblName = new System.Windows.Forms.Label();
            lblPhone = new System.Windows.Forms.Label();
            lblDate = new System.Windows.Forms.Label();
            lblDoctor = new System.Windows.Forms.Label();
            lblReason = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();

            txtAppointmentId = new System.Windows.Forms.TextBox();
            txtPatientName = new System.Windows.Forms.TextBox();
            txtPhone = new System.Windows.Forms.TextBox();

            dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            cboDoctor = new System.Windows.Forms.ComboBox();
            txtReason = new System.Windows.Forms.TextBox();
            cboStatus = new System.Windows.Forms.ComboBox();

            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            txtSearch = new System.Windows.Forms.TextBox();
            dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            cboFilterStatus = new System.Windows.Forms.ComboBox();
            btnResetFilter = new System.Windows.Forms.Button();

            dgvAppointments = new System.Windows.Forms.DataGridView();

            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblCount = new System.Windows.Forms.ToolStripStatusLabel();

            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);

            menuStrip1.SuspendLayout();
            mainLayout.SuspendLayout();
            inputLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            statusStrip1.SuspendLayout();

            // MENU

            menuFile.Text = "Hệ thống";

            menuExport.Text = "Xuất danh sách CSV";
            menuExport.Click += menuExport_Click;

            menuExit.Text = "Thoát";
            menuExit.Click += menuExit_Click;

            menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                menuExport,
                menuExit
            });

            menuStrip1.Items.Add(menuFile);
            menuStrip1.Dock = System.Windows.Forms.DockStyle.Top;

            // FORM

            this.Text = "CLINIC APPOINTMENT MANAGER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1200, 750);
            this.MinimumSize = new System.Drawing.Size(950, 600);

            // MAIN LAYOUT

            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 5;

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 55));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 205));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 55));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 25));

            // TITLE

            lblTitle.Text = "QUẢN LÝ LỊCH HẸN PHÒNG KHÁM";
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Font = new System.Drawing.Font(
                "Arial", 18, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;

            // INPUT LAYOUT

            inputLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            inputLayout.ColumnCount = 4;
            inputLayout.RowCount = 4;
            inputLayout.Padding = new System.Windows.Forms.Padding(10);

            for (int i = 0; i < 4; i++)
            {
                inputLayout.ColumnStyles.Add(
                    new System.Windows.Forms.ColumnStyle(
                        System.Windows.Forms.SizeType.Percent, 25));
            }

            for (int i = 0; i < 4; i++)
            {
                inputLayout.RowStyles.Add(
                    new System.Windows.Forms.RowStyle(
                        System.Windows.Forms.SizeType.Percent, 25));
            }

            lblId.Text = "Mã lịch hẹn:";
            lblName.Text = "Họ tên bệnh nhân:";
            lblPhone.Text = "Số điện thoại:";
            lblDate.Text = "Ngày giờ hẹn:";
            lblDoctor.Text = "Bác sĩ:";
            lblReason.Text = "Lý do khám:";
            lblStatus.Text = "Trạng thái:";

            System.Windows.Forms.Label[] labels =
            {
                lblId, lblName, lblPhone, lblDate,
                lblDoctor, lblReason, lblStatus
            };

            foreach (var lbl in labels)
            {
                lbl.Dock = System.Windows.Forms.DockStyle.Fill;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lbl.Font = new System.Drawing.Font("Arial", 9);
            }

            System.Windows.Forms.Control[] controls =
            {
                txtAppointmentId,
                txtPatientName,
                txtPhone,
                dtpAppointmentDate,
                cboDoctor,
                txtReason,
                cboStatus
            };

            foreach (var control in controls)
            {
                control.Dock = System.Windows.Forms.DockStyle.Fill;
                control.Margin = new System.Windows.Forms.Padding(5);
            }

            dtpAppointmentDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;

            dtpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpAppointmentDate.ShowUpDown = true;

            cboDoctor.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            cboStatus.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            txtReason.Multiline = true;

            inputLayout.Controls.Add(lblId, 0, 0);
            inputLayout.Controls.Add(txtAppointmentId, 1, 0);

            inputLayout.Controls.Add(lblName, 2, 0);
            inputLayout.Controls.Add(txtPatientName, 3, 0);

            inputLayout.Controls.Add(lblPhone, 0, 1);
            inputLayout.Controls.Add(txtPhone, 1, 1);

            inputLayout.Controls.Add(lblDate, 2, 1);
            inputLayout.Controls.Add(dtpAppointmentDate, 3, 1);

            inputLayout.Controls.Add(lblDoctor, 0, 2);
            inputLayout.Controls.Add(cboDoctor, 1, 2);

            inputLayout.Controls.Add(lblStatus, 2, 2);
            inputLayout.Controls.Add(cboStatus, 3, 2);

            inputLayout.Controls.Add(lblReason, 0, 3);
            inputLayout.Controls.Add(txtReason, 1, 3);

            inputLayout.SetColumnSpan(txtReason, 3);

            // BUTTONS

            System.Windows.Forms.FlowLayoutPanel buttonPanel =
                new System.Windows.Forms.FlowLayoutPanel();

            buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonPanel.FlowDirection =
                System.Windows.Forms.FlowDirection.LeftToRight;
            buttonPanel.WrapContents = false;
            buttonPanel.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);

            btnAdd.Text = "Thêm";
            btnUpdate.Text = "Cập nhật";
            btnDelete.Text = "Xóa";
            btnClear.Text = "Làm mới";

            System.Windows.Forms.Button[] buttons =
            {
                btnAdd, btnUpdate, btnDelete, btnClear
            };

            foreach (var btn in buttons)
            {
                btn.Size = new System.Drawing.Size(110, 32);
                btn.Margin = new System.Windows.Forms.Padding(5);
            }

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            buttonPanel.Controls.AddRange(buttons);

            // FILTER PANEL

            System.Windows.Forms.FlowLayoutPanel filterPanel =
                new System.Windows.Forms.FlowLayoutPanel();

            filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            filterPanel.Padding = new System.Windows.Forms.Padding(10);
            filterPanel.WrapContents = false;

            txtSearch.Width = 220;
            txtSearch.Margin = new System.Windows.Forms.Padding(5);
            txtSearch.PlaceholderText = "Tìm tên hoặc số điện thoại...";
            txtSearch.TextChanged += txtSearch_TextChanged;

            dtpFilterDate.Width = 160;
            dtpFilterDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFilterDate.CustomFormat = "dd/MM/yyyy";
            dtpFilterDate.ShowCheckBox = true;
            dtpFilterDate.Checked = false;
            dtpFilterDate.Margin = new System.Windows.Forms.Padding(5);
            dtpFilterDate.ValueChanged += FilterChanged;

            cboFilterStatus.Width = 150;
            cboFilterStatus.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Margin = new System.Windows.Forms.Padding(5);
            cboFilterStatus.SelectedIndexChanged += FilterChanged;

            btnResetFilter.Text = "Bỏ lọc";
            btnResetFilter.Size = new System.Drawing.Size(90, 30);
            btnResetFilter.Margin = new System.Windows.Forms.Padding(5);
            btnResetFilter.Click += btnResetFilter_Click;

            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(dtpFilterDate);
            filterPanel.Controls.Add(cboFilterStatus);
            filterPanel.Controls.Add(btnResetFilter);

            // DATAGRIDVIEW

            dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvAppointments.MultiSelect = false;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            dgvAppointments.ColumnHeadersHeight = 35;
            dgvAppointments.RowTemplate.Height = 30;

            dgvAppointments.SelectionChanged +=
                dgvAppointments_SelectionChanged;

            AddColumn("AppointmentId", "Mã lịch hẹn");
            AddColumn("PatientName", "Bệnh nhân");
            AddColumn("Phone", "Số điện thoại");
            AddColumn("AppointmentDate", "Ngày giờ hẹn");
            AddColumn("Doctor", "Bác sĩ");
            AddColumn("Reason", "Lý do khám");
            AddColumn("Status", "Trạng thái");

            // STATUS STRIP

            lblCount.Text = "Tổng số lịch hẹn: 0";
            statusStrip1.Items.Add(lblCount);
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;

            // ADD TO MAIN LAYOUT

            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(inputLayout, 0, 1);
            mainLayout.Controls.Add(buttonPanel, 0, 2);
            mainLayout.Controls.Add(dgvAppointments, 0, 3);
            mainLayout.Controls.Add(statusStrip1, 0, 4);

            this.Controls.Add(mainLayout);
            this.Controls.Add(menuStrip1);

            errorProvider1.ContainerControl = this;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();

            mainLayout.ResumeLayout(false);
            inputLayout.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();

            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AddColumn(string property, string header)
        {
            var column = new System.Windows.Forms.DataGridViewTextBoxColumn();

            column.DataPropertyName = property;
            column.HeaderText = header;
            column.Name = property;
            column.SortMode =
                System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

            dgvAppointments.Columns.Add(column);
        }
    }
}