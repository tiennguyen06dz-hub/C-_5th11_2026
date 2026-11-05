namespace RepairServiceTracker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuExit;

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel contentLayout;
        private System.Windows.Forms.TableLayoutPanel inputLayout;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDeviceType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblReceiveDate;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblImage;

        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtEstimatedCost;

        private System.Windows.Forms.ComboBox cboDeviceType;
        private System.Windows.Forms.ComboBox cboStatus;

        private System.Windows.Forms.DateTimePicker dtpReceiveDate;

        private System.Windows.Forms.PictureBox picDevice;

        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnRemoveImage;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnResetFilter;

        private System.Windows.Forms.DataGridView dgvOrders;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblOrderCount;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalCost;

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
            contentLayout = new System.Windows.Forms.TableLayoutPanel();
            inputLayout = new System.Windows.Forms.TableLayoutPanel();

            lblTitle = new System.Windows.Forms.Label();

            lblOrderId = new System.Windows.Forms.Label();
            lblCustomerName = new System.Windows.Forms.Label();
            lblPhone = new System.Windows.Forms.Label();
            lblDeviceType = new System.Windows.Forms.Label();
            lblDescription = new System.Windows.Forms.Label();
            lblReceiveDate = new System.Windows.Forms.Label();
            lblCost = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            lblImage = new System.Windows.Forms.Label();

            txtOrderId = new System.Windows.Forms.TextBox();
            txtCustomerName = new System.Windows.Forms.TextBox();
            txtPhone = new System.Windows.Forms.TextBox();
            txtDescription = new System.Windows.Forms.TextBox();
            txtEstimatedCost = new System.Windows.Forms.TextBox();

            cboDeviceType = new System.Windows.Forms.ComboBox();
            cboStatus = new System.Windows.Forms.ComboBox();

            dtpReceiveDate = new System.Windows.Forms.DateTimePicker();

            picDevice = new System.Windows.Forms.PictureBox();

            btnChooseImage = new System.Windows.Forms.Button();
            btnRemoveImage = new System.Windows.Forms.Button();

            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            txtSearch = new System.Windows.Forms.TextBox();
            cboFilterStatus = new System.Windows.Forms.ComboBox();
            btnResetFilter = new System.Windows.Forms.Button();

            dgvOrders = new System.Windows.Forms.DataGridView();

            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblOrderCount = new System.Windows.Forms.ToolStripStatusLabel();
            lblTotalCost = new System.Windows.Forms.ToolStripStatusLabel();

            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);

            menuStrip1.SuspendLayout();
            mainLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            inputLayout.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)picDevice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();

            statusStrip1.SuspendLayout();

            // FORM

            this.Text = "REPAIR SERVICE TRACKER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1250, 780);
            this.MinimumSize = new System.Drawing.Size(1000, 650);

            // MENU

            menuSystem.Text = "Hệ thống";
            menuExport.Text = "Xuất danh sách CSV";
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
            mainLayout.RowCount = 4;

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 55));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 280));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 55));

            mainLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100));

            // TITLE

            lblTitle.Text = "QUẢN LÝ ĐƠN ĐĂNG KÝ DỊCH VỤ SỬA CHỮA";
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            lblTitle.Font = new System.Drawing.Font(
                "Arial", 17, System.Drawing.FontStyle.Bold);

            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;

            // CONTENT LAYOUT

            contentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            contentLayout.ColumnCount = 2;
            contentLayout.RowCount = 1;
            contentLayout.Padding = new System.Windows.Forms.Padding(8);

            contentLayout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 75));

            contentLayout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 25));

            contentLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100));

            // INPUT LAYOUT

            inputLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            inputLayout.ColumnCount = 4;
            inputLayout.RowCount = 5;
            inputLayout.Padding = new System.Windows.Forms.Padding(5);

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

            lblOrderId.Text = "Mã đơn:";
            lblCustomerName.Text = "Tên khách hàng:";
            lblPhone.Text = "Số điện thoại:";
            lblDeviceType.Text = "Loại thiết bị:";
            lblDescription.Text = "Mô tả lỗi:";
            lblReceiveDate.Text = "Ngày tiếp nhận:";
            lblCost.Text = "Chi phí dự kiến:";
            lblStatus.Text = "Trạng thái:";

            System.Windows.Forms.Label[] labels =
            {
                lblOrderId,
                lblCustomerName,
                lblPhone,
                lblDeviceType,
                lblDescription,
                lblReceiveDate,
                lblCost,
                lblStatus
            };

            foreach (var lbl in labels)
            {
                lbl.Dock = System.Windows.Forms.DockStyle.Fill;
                lbl.TextAlign =
                    System.Drawing.ContentAlignment.MiddleLeft;
            }

            System.Windows.Forms.Control[] controls =
            {
                txtOrderId,
                txtCustomerName,
                txtPhone,
                cboDeviceType,
                txtDescription,
                dtpReceiveDate,
                txtEstimatedCost,
                cboStatus
            };

            foreach (var control in controls)
            {
                control.Dock = System.Windows.Forms.DockStyle.Fill;
                control.Margin = new System.Windows.Forms.Padding(5);
            }

            cboDeviceType.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            cboStatus.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            txtDescription.Multiline = true;

            dtpReceiveDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;

            dtpReceiveDate.CustomFormat = "dd/MM/yyyy";

            inputLayout.Controls.Add(lblOrderId, 0, 0);
            inputLayout.Controls.Add(txtOrderId, 1, 0);

            inputLayout.Controls.Add(lblCustomerName, 2, 0);
            inputLayout.Controls.Add(txtCustomerName, 3, 0);

            inputLayout.Controls.Add(lblPhone, 0, 1);
            inputLayout.Controls.Add(txtPhone, 1, 1);

            inputLayout.Controls.Add(lblDeviceType, 2, 1);
            inputLayout.Controls.Add(cboDeviceType, 3, 1);

            inputLayout.Controls.Add(lblDescription, 0, 2);
            inputLayout.Controls.Add(txtDescription, 1, 2);
            inputLayout.SetColumnSpan(txtDescription, 3);

            inputLayout.Controls.Add(lblReceiveDate, 0, 3);
            inputLayout.Controls.Add(dtpReceiveDate, 1, 3);

            inputLayout.Controls.Add(lblCost, 2, 3);
            inputLayout.Controls.Add(txtEstimatedCost, 3, 3);

            inputLayout.Controls.Add(lblStatus, 0, 4);
            inputLayout.Controls.Add(cboStatus, 1, 4);

            // PICTURE PANEL

            System.Windows.Forms.TableLayoutPanel imageLayout =
                new System.Windows.Forms.TableLayoutPanel();

            imageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            imageLayout.ColumnCount = 1;
            imageLayout.RowCount = 4;
            imageLayout.Padding = new System.Windows.Forms.Padding(5);

            imageLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 30));

            imageLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100));

            imageLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 38));

            imageLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 38));

            lblImage.Text = "ẢNH THIẾT BỊ";
            lblImage.Dock = System.Windows.Forms.DockStyle.Fill;
            lblImage.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            picDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            picDevice.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            picDevice.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.Dock = System.Windows.Forms.DockStyle.Fill;
            btnChooseImage.Margin = new System.Windows.Forms.Padding(3);
            btnChooseImage.Click += btnChooseImage_Click;

            btnRemoveImage.Text = "Xóa ảnh";
            btnRemoveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            btnRemoveImage.Margin = new System.Windows.Forms.Padding(3);
            btnRemoveImage.Click += btnRemoveImage_Click;

            imageLayout.Controls.Add(lblImage, 0, 0);
            imageLayout.Controls.Add(picDevice, 0, 1);
            imageLayout.Controls.Add(btnChooseImage, 0, 2);
            imageLayout.Controls.Add(btnRemoveImage, 0, 3);

            contentLayout.Controls.Add(inputLayout, 0, 0);
            contentLayout.Controls.Add(imageLayout, 1, 0);

            // BUTTON PANEL

            System.Windows.Forms.FlowLayoutPanel buttonPanel =
                new System.Windows.Forms.FlowLayoutPanel();

            buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonPanel.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            buttonPanel.WrapContents = false;

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
                btn.Size = new System.Drawing.Size(120, 32);
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

            txtSearch.Width = 300;
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

            dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvOrders.AutoGenerateColumns = false;

            dgvOrders.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvOrders.MultiSelect = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.RowHeadersVisible = false;

            dgvOrders.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrders.BackgroundColor = System.Drawing.Color.White;
            dgvOrders.RowTemplate.Height = 30;
            dgvOrders.ColumnHeadersHeight = 35;

            AddColumn("OrderId", "Mã đơn");
            AddColumn("CustomerName", "Khách hàng");
            AddColumn("Phone", "Số điện thoại");
            AddColumn("DeviceType", "Thiết bị");
            AddColumn("ProblemDescription", "Mô tả lỗi");
            AddColumn("ReceiveDate", "Ngày tiếp nhận");
            AddColumn("EstimatedCost", "Chi phí dự kiến");
            AddColumn("Status", "Trạng thái");

            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;

            // STATUS STRIP

            lblOrderCount.Text = "Số đơn đang hiển thị: 0";
            lblTotalCost.Text = "Tổng chi phí chưa hoàn tất: 0";

            statusStrip1.Items.Add(lblOrderCount);

            System.Windows.Forms.ToolStripStatusLabel separator =
                new System.Windows.Forms.ToolStripStatusLabel();

            separator.Text = " | ";

            statusStrip1.Items.Add(separator);
            statusStrip1.Items.Add(lblTotalCost);

            statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;

            // ADD TO MAIN LAYOUT

            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(contentLayout, 0, 1);
            mainLayout.Controls.Add(buttonPanel, 0, 2);
            mainLayout.Controls.Add(dgvOrders, 0, 3);

            this.Controls.Add(mainLayout);
            this.Controls.Add(menuStrip1);
            this.Controls.Add(statusStrip1);

            statusStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;

            errorProvider1.ContainerControl = this;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();

            mainLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            inputLayout.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)picDevice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();

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

            if (property == "EstimatedCost")
            {
                column.DefaultCellStyle.Format = "N0";
            }

            if (property == "ReceiveDate")
            {
                column.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            dgvOrders.Columns.Add(column);
        }
    }
}