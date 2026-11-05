namespace LabEquipmentCheckout
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuExit;

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel inputLayout;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBorrowId;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblEquipment;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.TextBox txtBorrowId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtStudentName;

        private System.Windows.Forms.ComboBox cboEquipment;
        private System.Windows.Forms.NumericUpDown numQuantity;

        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;

        private System.Windows.Forms.Label lblStatusValue;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnResetFilter;

        private System.Windows.Forms.DataGridView dgvBorrowRecords;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblOverdue;

        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            menuExport = new System.Windows.Forms.ToolStripMenuItem();
            menuExit = new System.Windows.Forms.ToolStripMenuItem();

            mainLayout = new System.Windows.Forms.TableLayoutPanel();
            inputLayout = new System.Windows.Forms.TableLayoutPanel();

            lblTitle = new System.Windows.Forms.Label();

            lblBorrowId = new System.Windows.Forms.Label();
            lblStudentId = new System.Windows.Forms.Label();
            lblStudentName = new System.Windows.Forms.Label();
            lblEquipment = new System.Windows.Forms.Label();
            lblQuantity = new System.Windows.Forms.Label();
            lblBorrowDate = new System.Windows.Forms.Label();
            lblDueDate = new System.Windows.Forms.Label();
            lblReturnDate = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();

            txtBorrowId = new System.Windows.Forms.TextBox();
            txtStudentId = new System.Windows.Forms.TextBox();
            txtStudentName = new System.Windows.Forms.TextBox();

            cboEquipment = new System.Windows.Forms.ComboBox();
            numQuantity = new System.Windows.Forms.NumericUpDown();

            dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            dtpDueDate = new System.Windows.Forms.DateTimePicker();
            dtpReturnDate = new System.Windows.Forms.DateTimePicker();

            lblStatusValue = new System.Windows.Forms.Label();

            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnReturn = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            txtSearch = new System.Windows.Forms.TextBox();
            cboFilterStatus = new System.Windows.Forms.ComboBox();
            btnResetFilter = new System.Windows.Forms.Button();

            dgvBorrowRecords = new System.Windows.Forms.DataGridView();

            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            lblOverdue = new System.Windows.Forms.ToolStripStatusLabel();

            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);

            menuStrip1.SuspendLayout();
            mainLayout.SuspendLayout();
            inputLayout.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dgvBorrowRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();

            statusStrip1.SuspendLayout();

            // FORM

            this.Text = "LAB EQUIPMENT CHECKOUT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1250, 760);
            this.MinimumSize = new System.Drawing.Size(1000, 650);

            // MENU

            menuSystem.Text = "Hệ thống";
            menuExport.Text = "Xuất CSV";
            menuExit.Text = "Thoát";

            menuExport.Click += menuExport_Click;
            menuExit.Click += menuExit_Click;

            menuSystem.DropDownItems.Add(menuExport);
            menuSystem.DropDownItems.Add(menuExit);

            menuStrip1.Items.Add(menuSystem);
            menuStrip1.Dock = System.Windows.Forms.DockStyle.Top;

            // MAIN LAYOUT

            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 5;

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 55));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 235));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 50));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 25));

            // TITLE

            lblTitle.Text = "QUẢN LÝ MƯỢN TRẢ THIẾT BỊ PHÒNG THỰC HÀNH";
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Font = new System.Drawing.Font(
                "Arial", 17, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;

            // INPUT LAYOUT

            inputLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            inputLayout.ColumnCount = 4;
            inputLayout.RowCount = 5;
            inputLayout.Padding = new System.Windows.Forms.Padding(10);

            for (int i = 0; i < 4; i++)
            {
                inputLayout.ColumnStyles.Add(
                    new System.Windows.Forms.ColumnStyle(
                        System.Windows.Forms.SizeType.Percent, 25));
            }

            for (int i = 0; i < 5; i++)
            {
                inputLayout.RowStyles.Add(
                    new System.Windows.Forms.RowStyle(
                        System.Windows.Forms.SizeType.Percent, 20));
            }

            lblBorrowId.Text = "Mã phiếu:";
            lblStudentId.Text = "Mã sinh viên:";
            lblStudentName.Text = "Họ tên sinh viên:";
            lblEquipment.Text = "Thiết bị:";
            lblQuantity.Text = "Số lượng:";
            lblBorrowDate.Text = "Ngày mượn:";
            lblDueDate.Text = "Hạn trả:";
            lblReturnDate.Text = "Ngày trả thực tế:";
            lblStatus.Text = "Tình trạng:";

            System.Windows.Forms.Label[] labels =
            {
                lblBorrowId, lblStudentId,
                lblStudentName, lblEquipment,
                lblQuantity, lblBorrowDate,
                lblDueDate, lblReturnDate,
                lblStatus
            };

            foreach (var lbl in labels)
            {
                lbl.Dock = System.Windows.Forms.DockStyle.Fill;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            }

            System.Windows.Forms.Control[] controls =
            {
                txtBorrowId, txtStudentId,
                txtStudentName, cboEquipment,
                numQuantity, dtpBorrowDate,
                dtpDueDate, dtpReturnDate,
                lblStatusValue
            };

            foreach (var control in controls)
            {
                control.Dock = System.Windows.Forms.DockStyle.Fill;
                control.Margin = new System.Windows.Forms.Padding(5);
            }

            cboEquipment.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            numQuantity.Minimum = 1;
            numQuantity.Maximum = 10000;
            numQuantity.Value = 1;

            dtpBorrowDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpBorrowDate.CustomFormat = "dd/MM/yyyy";

            dtpDueDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDueDate.CustomFormat = "dd/MM/yyyy";

            dtpReturnDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpReturnDate.CustomFormat = "dd/MM/yyyy";
            dtpReturnDate.ShowCheckBox = true;
            dtpReturnDate.Checked = false;

            lblStatusValue.Text = "Đang mượn";
            lblStatusValue.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;
            lblStatusValue.Font = new System.Drawing.Font(
                "Arial", 10, System.Drawing.FontStyle.Bold);

            inputLayout.Controls.Add(lblBorrowId, 0, 0);
            inputLayout.Controls.Add(txtBorrowId, 1, 0);

            inputLayout.Controls.Add(lblStudentId, 2, 0);
            inputLayout.Controls.Add(txtStudentId, 3, 0);

            inputLayout.Controls.Add(lblStudentName, 0, 1);
            inputLayout.Controls.Add(txtStudentName, 1, 1);

            inputLayout.Controls.Add(lblEquipment, 2, 1);
            inputLayout.Controls.Add(cboEquipment, 3, 1);

            inputLayout.Controls.Add(lblQuantity, 0, 2);
            inputLayout.Controls.Add(numQuantity, 1, 2);

            inputLayout.Controls.Add(lblBorrowDate, 2, 2);
            inputLayout.Controls.Add(dtpBorrowDate, 3, 2);

            inputLayout.Controls.Add(lblDueDate, 0, 3);
            inputLayout.Controls.Add(dtpDueDate, 1, 3);

            inputLayout.Controls.Add(lblReturnDate, 2, 3);
            inputLayout.Controls.Add(dtpReturnDate, 3, 3);

            inputLayout.Controls.Add(lblStatus, 0, 4);
            inputLayout.Controls.Add(lblStatusValue, 1, 4);

            // BUTTON PANEL

            System.Windows.Forms.FlowLayoutPanel buttonPanel =
                new System.Windows.Forms.FlowLayoutPanel();

            buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonPanel.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            buttonPanel.WrapContents = false;

            btnAdd.Text = "Thêm";
            btnUpdate.Text = "Cập nhật";
            btnDelete.Text = "Xóa";
            btnReturn.Text = "Đánh dấu đã trả";
            btnClear.Text = "Làm mới";

            System.Windows.Forms.Button[] buttons =
            {
                btnAdd, btnUpdate, btnDelete, btnReturn, btnClear
            };

            foreach (var btn in buttons)
            {
                btn.Size = new System.Drawing.Size(120, 32);
                btn.Margin = new System.Windows.Forms.Padding(5);
            }

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnReturn.Click += btnReturn_Click;
            btnClear.Click += btnClear_Click;

            buttonPanel.Controls.AddRange(buttons);

            // FILTER PANEL

            System.Windows.Forms.FlowLayoutPanel filterPanel =
                new System.Windows.Forms.FlowLayoutPanel();

            filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            filterPanel.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            filterPanel.WrapContents = false;

            txtSearch.Width = 280;
            txtSearch.Margin = new System.Windows.Forms.Padding(5);
            txtSearch.TextChanged += txtSearch_TextChanged;

            cboFilterStatus.Width = 180;
            cboFilterStatus.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Margin = new System.Windows.Forms.Padding(5);
            cboFilterStatus.SelectedIndexChanged += FilterChanged;

            btnResetFilter.Text = "Bỏ lọc";
            btnResetFilter.Size = new System.Drawing.Size(90, 30);
            btnResetFilter.Margin = new System.Windows.Forms.Padding(5);
            btnResetFilter.Click += btnResetFilter_Click;

            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(cboFilterStatus);
            filterPanel.Controls.Add(btnResetFilter);

            // DATAGRIDVIEW

            dgvBorrowRecords.Dock = System.Windows.Forms.DockStyle.Fill;

            dgvBorrowRecords.AutoGenerateColumns = false;
            dgvBorrowRecords.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvBorrowRecords.MultiSelect = false;
            dgvBorrowRecords.ReadOnly = true;
            dgvBorrowRecords.AllowUserToAddRows = false;
            dgvBorrowRecords.AllowUserToDeleteRows = false;
            dgvBorrowRecords.RowHeadersVisible = false;

            dgvBorrowRecords.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvBorrowRecords.BackgroundColor =
                System.Drawing.Color.White;

            dgvBorrowRecords.RowTemplate.Height = 30;
            dgvBorrowRecords.ColumnHeadersHeight = 35;

            AddColumn("BorrowId", "Mã phiếu");
            AddColumn("StudentId", "Mã sinh viên");
            AddColumn("StudentName", "Họ tên");
            AddColumn("Equipment", "Thiết bị");
            AddColumn("Quantity", "Số lượng");
            AddColumn("BorrowDate", "Ngày mượn");
            AddColumn("DueDate", "Hạn trả");
            AddColumn("ActualReturnDate", "Ngày trả thực tế");
            AddColumn("Status", "Tình trạng");

            dgvBorrowRecords.SelectionChanged +=
                dgvBorrowRecords_SelectionChanged;

            // STATUS STRIP

            lblTotal.Text = "Tổng số phiếu: 0";
            lblOverdue.Text = "Số phiếu quá hạn: 0";

            statusStrip1.Items.Add(lblTotal);

            System.Windows.Forms.ToolStripStatusLabel separator =
                new System.Windows.Forms.ToolStripStatusLabel();

            separator.Text = " | ";

            statusStrip1.Items.Add(separator);
            statusStrip1.Items.Add(lblOverdue);

            statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;

            // ADD CONTROLS

            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(inputLayout, 0, 1);
            mainLayout.Controls.Add(buttonPanel, 0, 2);
            mainLayout.Controls.Add(dgvBorrowRecords, 0, 3);
            mainLayout.Controls.Add(statusStrip1, 0, 4);

            this.Controls.Add(mainLayout);
            this.Controls.Add(menuStrip1);

            errorProvider1.ContainerControl = this;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();

            mainLayout.ResumeLayout(false);
            inputLayout.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvBorrowRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();

            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AddColumn(string property, string header)
        {
            System.Windows.Forms.DataGridViewTextBoxColumn column =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            column.Name = property;
            column.DataPropertyName = property;
            column.HeaderText = header;
            column.SortMode =
                System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

            if (property == "BorrowDate" ||
                property == "DueDate" ||
                property == "ActualReturnDate")
            {
                column.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            dgvBorrowRecords.Columns.Add(column);
        }
    }
}