using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RepairServiceTracker
{
    public partial class Form1 : Form
    {
        private BindingList<RepairOrder> repairOrders;
        private BindingSource bindingSource;
        private RepairManager manager;

        private RepairOrder selectedOrder;
        private string selectedImagePath = "";

        public Form1()
        {
            InitializeComponent();

            repairOrders = new BindingList<RepairOrder>();
            bindingSource = new BindingSource();
            manager = new RepairManager();

            LoadData();
            LoadComboBox();

            bindingSource.DataSource = repairOrders;
            dgvOrders.DataSource = bindingSource;

            ClearInput();
            ApplyFilter();
        }

        // DỮ LIỆU MẪU

        private void LoadData()
        {
            repairOrders.Add(new RepairOrder
            {
                OrderId = "SC001",
                CustomerName = "Nguyễn Văn Nam",
                Phone = "0912345678",
                DeviceType = "Laptop",
                ProblemDescription = "Máy không khởi động",
                ReceiveDate = DateTime.Today.AddDays(-2),
                EstimatedCost = 1500000,
                Status = "Đang sửa",
                ImagePath = ""
            });

            repairOrders.Add(new RepairOrder
            {
                OrderId = "SC002",
                CustomerName = "Trần Thị Hoa",
                Phone = "0987654321",
                DeviceType = "Điện thoại",
                ProblemDescription = "Màn hình bị vỡ",
                ReceiveDate = DateTime.Today,
                EstimatedCost = 2500000,
                Status = "Mới tiếp nhận",
                ImagePath = ""
            });

            repairOrders.Add(new RepairOrder
            {
                OrderId = "SC003",
                CustomerName = "Lê Minh Tuấn",
                Phone = "0901234567",
                DeviceType = "Máy tính bàn",
                ProblemDescription = "Máy chạy chậm",
                ReceiveDate = DateTime.Today.AddDays(-3),
                EstimatedCost = 800000,
                Status = "Chờ linh kiện",
                ImagePath = ""
            });

            repairOrders.Add(new RepairOrder
            {
                OrderId = "SC004",
                CustomerName = "Phạm Thị Lan",
                Phone = "0971234567",
                DeviceType = "Máy tính bảng",
                ProblemDescription = "Không nhận sạc",
                ReceiveDate = DateTime.Today.AddDays(-5),
                EstimatedCost = 500000,
                Status = "Hoàn tất",
                ImagePath = ""
            });

            repairOrders.Add(new RepairOrder
            {
                OrderId = "SC005",
                CustomerName = "Hoàng Văn Bình",
                Phone = "0961234567",
                DeviceType = "Máy in",
                ProblemDescription = "Máy in không kéo giấy",
                ReceiveDate = DateTime.Today.AddDays(-1),
                EstimatedCost = 1200000,
                Status = "Đã hủy",
                ImagePath = ""
            });
        }

        // LOAD COMBOBOX

        private void LoadComboBox()
        {
            cboDeviceType.Items.Clear();

            foreach (string device in manager.DeviceTypes)
            {
                cboDeviceType.Items.Add(device);
            }

            cboStatus.Items.Clear();

            foreach (string status in manager.Statuses)
            {
                cboStatus.Items.Add(status);
            }

            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add("Tất cả");

            foreach (string status in manager.Statuses)
            {
                cboFilterStatus.Items.Add(status);
            }

            cboDeviceType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
        }

        // KIỂM TRA DỮ LIỆU

        private bool ValidateInput()
        {
            errorProvider1.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                errorProvider1.SetError(
                    txtOrderId, "Vui lòng nhập mã đơn!");

                valid = false;
            }
            else
            {
                string oldId = selectedOrder == null
                    ? ""
                    : selectedOrder.OrderId;

                if (manager.IsDuplicateId(
                    repairOrders,
                    txtOrderId.Text.Trim(),
                    oldId))
                {
                    errorProvider1.SetError(
                        txtOrderId, "Mã đơn đã tồn tại!");

                    valid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                errorProvider1.SetError(
                    txtCustomerName, "Vui lòng nhập tên khách hàng!");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(
                    txtPhone, "Vui lòng nhập số điện thoại!");

                valid = false;
            }

            if (cboDeviceType.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cboDeviceType, "Vui lòng chọn loại thiết bị!");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider1.SetError(
                    txtDescription, "Vui lòng nhập mô tả lỗi!");

                valid = false;
            }

            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cboStatus, "Vui lòng chọn trạng thái!");

                valid = false;
            }

            if (!decimal.TryParse(
                txtEstimatedCost.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal cost))
            {
                errorProvider1.SetError(
                    txtEstimatedCost,
                    "Chi phí phải là một số hợp lệ!");

                valid = false;
            }
            else if (cost < 0)
            {
                errorProvider1.SetError(
                    txtEstimatedCost,
                    "Chi phí không được là số âm!");

                valid = false;
            }

            return valid;
        }

        // LẤY DỮ LIỆU TỪ FORM

        private RepairOrder GetOrder()
        {
            decimal.TryParse(
                txtEstimatedCost.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal cost);

            return new RepairOrder
            {
                OrderId = txtOrderId.Text.Trim(),
                CustomerName = txtCustomerName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                DeviceType = cboDeviceType.Text,
                ProblemDescription = txtDescription.Text.Trim(),
                ReceiveDate = dtpReceiveDate.Value.Date,
                EstimatedCost = cost,
                Status = cboStatus.Text,
                ImagePath = selectedImagePath
            };
        }

        // HIỂN THỊ ẢNH

        private void DisplayImage(string path)
        {
            if (picDevice.Image != null)
            {
                Image oldImage = picDevice.Image;
                picDevice.Image = null;
                oldImage.Dispose();
            }

            if (string.IsNullOrWhiteSpace(path) ||
                !File.Exists(path))
            {
                return;
            }

            try
            {
                using (Image original = Image.FromFile(path))
                {
                    picDevice.Image = new Bitmap(original);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hiển thị ảnh: " + ex.Message);
            }
        }

        // CHỌN ẢNH THIẾT BỊ

        private void btnChooseImage_Click(
            object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Chọn ảnh thiết bị";
            openFileDialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;

                DisplayImage(selectedImagePath);
            }
        }

        // XÓA ẢNH

        private void btnRemoveImage_Click(
            object sender, EventArgs e)
        {
            selectedImagePath = "";

            if (picDevice.Image != null)
            {
                Image oldImage = picDevice.Image;
                picDevice.Image = null;
                oldImage.Dispose();
            }
        }

        // LÀM MỚI FORM

        private void ClearInput()
        {
            selectedOrder = null;
            selectedImagePath = "";

            errorProvider1.Clear();

            txtOrderId.Clear();
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtDescription.Clear();
            txtEstimatedCost.Text = "0";

            cboDeviceType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            dtpReceiveDate.Value = DateTime.Today;

            if (picDevice.Image != null)
            {
                Image oldImage = picDevice.Image;
                picDevice.Image = null;
                oldImage.Dispose();
            }

            dgvOrders.ClearSelection();

            txtOrderId.Focus();
        }

        // THÊM ĐƠN SỬA CHỮA

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            RepairOrder order = GetOrder();

            repairOrders.Add(order);

            ApplyFilter();
            ClearInput();

            MessageBox.Show(
                "Thêm đơn sửa chữa thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // CẬP NHẬT ĐƠN SỬA CHỮA

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedOrder == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn đơn sửa chữa cần cập nhật!");

                return;
            }

            if (!ValidateInput())
                return;

            RepairOrder newOrder = GetOrder();

            selectedOrder.OrderId = newOrder.OrderId;
            selectedOrder.CustomerName = newOrder.CustomerName;
            selectedOrder.Phone = newOrder.Phone;
            selectedOrder.DeviceType = newOrder.DeviceType;

            selectedOrder.ProblemDescription =
                newOrder.ProblemDescription;

            selectedOrder.ReceiveDate = newOrder.ReceiveDate;
            selectedOrder.EstimatedCost = newOrder.EstimatedCost;
            selectedOrder.Status = newOrder.Status;
            selectedOrder.ImagePath = newOrder.ImagePath;

            bindingSource.ResetBindings(false);

            ApplyFilter();
            ClearInput();

            MessageBox.Show(
                "Cập nhật đơn sửa chữa thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // XÓA ĐƠN

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedOrder == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn đơn sửa chữa cần xóa!");

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa đơn sửa chữa này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                repairOrders.Remove(selectedOrder);

                ApplyFilter();
                ClearInput();

                MessageBox.Show("Xóa đơn sửa chữa thành công!");
            }
        }

        // LÀM MỚI

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        // CHỌN DÒNG DATAGRIDVIEW

        private void dgvOrders_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null ||
                !dgvOrders.CurrentRow.Selected)
            {
                return;
            }

            if (dgvOrders.CurrentRow.DataBoundItem
                is RepairOrder order)
            {
                selectedOrder = order;

                txtOrderId.Text = order.OrderId;
                txtCustomerName.Text = order.CustomerName;
                txtPhone.Text = order.Phone;
                cboDeviceType.Text = order.DeviceType;

                txtDescription.Text =
                    order.ProblemDescription;

                dtpReceiveDate.Value = order.ReceiveDate;

                txtEstimatedCost.Text =
                    order.EstimatedCost.ToString(
                        "0.##", CultureInfo.CurrentCulture);

                cboStatus.Text = order.Status;

                selectedImagePath = order.ImagePath ?? "";

                DisplayImage(selectedImagePath);

                errorProvider1.Clear();
            }
        }

        // TÌM KIẾM

        private void txtSearch_TextChanged(
            object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // LỌC TRẠNG THÁI

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // TÌM KIẾM VÀ LỌC

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var filtered = repairOrders.Where(x =>
                x.OrderId.ToLower().Contains(keyword) ||
                x.CustomerName.ToLower().Contains(keyword) ||
                x.Phone.Contains(keyword)
            ).ToList();

            if (cboFilterStatus.SelectedIndex > 0)
            {
                string status = cboFilterStatus.Text;

                filtered = filtered.Where(x =>
                    x.Status == status
                ).ToList();
            }

            BindingList<RepairOrder> result =
                new BindingList<RepairOrder>(filtered);

            bindingSource.DataSource = result;

            lblOrderCount.Text =
                "Số đơn đang hiển thị: " + filtered.Count;

            decimal totalCost = filtered
                .Where(x => x.Status != "Hoàn tất")
                .Sum(x => x.EstimatedCost);

            lblTotalCost.Text =
                "Tổng chi phí chưa hoàn tất: " +
                totalCost.ToString("N0");
        }

        // BỎ LỌC

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            cboFilterStatus.SelectedIndex = 0;

            ApplyFilter();
        }

        // XUẤT CSV

        private void menuExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
            saveFileDialog.Title = "Xuất danh sách đơn sửa chữa";
            saveFileDialog.FileName = "DanhSachDonSuaChua.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder csv = new StringBuilder();

                    csv.AppendLine(
                        "MaDon,TenKhachHang,SoDienThoai,LoaiThietBi,MoTaLoi,NgayTiepNhan,ChiPhiDuKien,TrangThai,DuongDanAnh");

                    foreach (DataGridViewRow row in dgvOrders.Rows)
                    {
                        if (row.DataBoundItem is RepairOrder order)
                        {
                            csv.AppendLine(string.Join(",",
                                CsvValue(order.OrderId),
                                CsvValue(order.CustomerName),
                                CsvValue(order.Phone),
                                CsvValue(order.DeviceType),
                                CsvValue(order.ProblemDescription),
                                CsvValue(order.ReceiveDate.ToString("dd/MM/yyyy")),
                                CsvValue(order.EstimatedCost.ToString(
                                    CultureInfo.InvariantCulture)),
                                CsvValue(order.Status),
                                CsvValue(order.ImagePath ?? "")
                            ));
                        }
                    }

                    File.WriteAllText(
                        saveFileDialog.FileName,
                        csv.ToString(),
                        new UTF8Encoding(true));

                    MessageBox.Show(
                        "Xuất CSV thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi xuất CSV: " + ex.Message);
                }
            }
        }

        // XỬ LÝ GIÁ TRỊ CSV

        private string CsvValue(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        // THOÁT CHƯƠNG TRÌNH

        private void menuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // GIẢI PHÓNG ẢNH KHI ĐÓNG FORM

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picDevice.Image != null)
            {
                picDevice.Image.Dispose();
                picDevice.Image = null;
            }

            base.OnFormClosed(e);
        }
    }
}