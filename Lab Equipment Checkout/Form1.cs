using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabEquipmentCheckout
{
    public partial class Form1 : Form
    {
        private BindingList<BorrowRecord> borrowRecords;
        private BindingSource bindingSource;
        private BorrowManager manager;

        private BorrowRecord selectedRecord;

        public Form1()
        {
            InitializeComponent();

            borrowRecords = new BindingList<BorrowRecord>();
            bindingSource = new BindingSource();
            manager = new BorrowManager();

            LoadData();
            LoadComboBox();

            bindingSource.DataSource = borrowRecords;
            dgvBorrowRecords.DataSource = bindingSource;

            ClearInput();
            ApplyFilter();
        }

        // DỮ LIỆU MẪU

        private void LoadData()
        {
            borrowRecords.Add(new BorrowRecord
            {
                BorrowId = "PM001",
                StudentId = "SV001",
                StudentName = "Nguyễn Văn Nam",
                Equipment = "Laptop",
                Quantity = 1,
                BorrowDate = DateTime.Today.AddDays(-5),
                DueDate = DateTime.Today.AddDays(-2),
                ActualReturnDate = null
            });

            borrowRecords.Add(new BorrowRecord
            {
                BorrowId = "PM002",
                StudentId = "SV002",
                StudentName = "Trần Thị Hoa",
                Equipment = "Máy chiếu",
                Quantity = 1,
                BorrowDate = DateTime.Today,
                DueDate = DateTime.Today.AddDays(3),
                ActualReturnDate = null
            });

            borrowRecords.Add(new BorrowRecord
            {
                BorrowId = "PM003",
                StudentId = "SV003",
                StudentName = "Lê Minh Tuấn",
                Equipment = "Chuột",
                Quantity = 2,
                BorrowDate = DateTime.Today.AddDays(-4),
                DueDate = DateTime.Today.AddDays(2),
                ActualReturnDate = DateTime.Today.AddDays(-1)
            });

            borrowRecords.Add(new BorrowRecord
            {
                BorrowId = "PM004",
                StudentId = "SV004",
                StudentName = "Phạm Thị Lan",
                Equipment = "Arduino",
                Quantity = 1,
                BorrowDate = DateTime.Today.AddDays(-1),
                DueDate = DateTime.Today.AddDays(5),
                ActualReturnDate = null
            });

            borrowRecords.Add(new BorrowRecord
            {
                BorrowId = "PM005",
                StudentId = "SV005",
                StudentName = "Hoàng Văn Bình",
                Equipment = "Máy tính",
                Quantity = 1,
                BorrowDate = DateTime.Today.AddDays(-10),
                DueDate = DateTime.Today.AddDays(-3),
                ActualReturnDate = null
            });
        }

        // LOAD COMBOBOX

        private void LoadComboBox()
        {
            cboEquipment.Items.Clear();

            foreach (string equipment in manager.Equipments)
            {
                cboEquipment.Items.Add(equipment);
            }

            cboFilterStatus.Items.Clear();

            foreach (string status in manager.Statuses)
            {
                cboFilterStatus.Items.Add(status);
            }

            cboFilterStatus.SelectedIndex = 0;
            cboEquipment.SelectedIndex = 0;
        }

        // KIỂM TRA DỮ LIỆU

        private bool ValidateInput()
        {
            errorProvider1.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtBorrowId.Text))
            {
                errorProvider1.SetError(
                    txtBorrowId, "Vui lòng nhập mã phiếu!");

                valid = false;
            }
            else
            {
                string oldId = selectedRecord == null
                    ? ""
                    : selectedRecord.BorrowId;

                if (manager.IsDuplicateId(
                    borrowRecords,
                    txtBorrowId.Text.Trim(),
                    oldId))
                {
                    errorProvider1.SetError(
                        txtBorrowId, "Mã phiếu đã tồn tại!");

                    valid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(
                    txtStudentId, "Vui lòng nhập mã sinh viên!");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                errorProvider1.SetError(
                    txtStudentName, "Vui lòng nhập họ tên sinh viên!");

                valid = false;
            }

            if (cboEquipment.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cboEquipment, "Vui lòng chọn thiết bị!");

                valid = false;
            }

            if (numQuantity.Value <= 0)
            {
                errorProvider1.SetError(
                    numQuantity, "Số lượng phải lớn hơn 0!");

                valid = false;
            }

            if (dtpDueDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider1.SetError(
                    dtpDueDate, "Hạn trả không được trước ngày mượn!");

                valid = false;
            }

            if (dtpReturnDate.Checked &&
                dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider1.SetError(
                    dtpReturnDate,
                    "Ngày trả thực tế không được trước ngày mượn!");

                valid = false;
            }

            return valid;
        }

        // LẤY DỮ LIỆU TỪ FORM

        private BorrowRecord GetRecord()
        {
            return new BorrowRecord
            {
                BorrowId = txtBorrowId.Text.Trim(),
                StudentId = txtStudentId.Text.Trim(),
                StudentName = txtStudentName.Text.Trim(),
                Equipment = cboEquipment.Text,
                Quantity = (int)numQuantity.Value,
                BorrowDate = dtpBorrowDate.Value.Date,
                DueDate = dtpDueDate.Value.Date,
                ActualReturnDate = dtpReturnDate.Checked
                    ? dtpReturnDate.Value.Date
                    : (DateTime?)null
            };
        }

        // CẬP NHẬT TRẠNG THÁI

        private void UpdateStatus()
        {
            lblStatusValue.Text = dtpReturnDate.Checked
                ? "Đã trả"
                : dtpDueDate.Value.Date < DateTime.Today
                    ? "Quá hạn"
                    : "Đang mượn";
        }

        // LÀM MỚI FORM

        private void ClearInput()
        {
            selectedRecord = null;

            errorProvider1.Clear();

            txtBorrowId.Clear();
            txtStudentId.Clear();
            txtStudentName.Clear();

            cboEquipment.SelectedIndex = 0;

            numQuantity.Value = 1;

            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(7);

            dtpReturnDate.Value = DateTime.Today;
            dtpReturnDate.Checked = false;

            UpdateStatus();

            dgvBorrowRecords.ClearSelection();

            txtBorrowId.Focus();
        }

        // THÊM PHIẾU MƯỢN

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            BorrowRecord record = GetRecord();

            borrowRecords.Add(record);

            ApplyFilter();
            ClearInput();

            MessageBox.Show(
                "Thêm phiếu mượn thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // CẬP NHẬT PHIẾU MƯỢN

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRecord == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu cần cập nhật!");
                return;
            }

            if (!ValidateInput())
                return;

            BorrowRecord newRecord = GetRecord();

            selectedRecord.BorrowId = newRecord.BorrowId;
            selectedRecord.StudentId = newRecord.StudentId;
            selectedRecord.StudentName = newRecord.StudentName;
            selectedRecord.Equipment = newRecord.Equipment;
            selectedRecord.Quantity = newRecord.Quantity;
            selectedRecord.BorrowDate = newRecord.BorrowDate;
            selectedRecord.DueDate = newRecord.DueDate;
            selectedRecord.ActualReturnDate =
                newRecord.ActualReturnDate;

            bindingSource.ResetBindings(false);

            ApplyFilter();
            ClearInput();

            MessageBox.Show(
                "Cập nhật phiếu mượn thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // XÓA PHIẾU MƯỢN

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRecord == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phiếu mượn này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                borrowRecords.Remove(selectedRecord);

                ApplyFilter();
                ClearInput();

                MessageBox.Show("Xóa phiếu mượn thành công!");
            }
        }

        // ĐÁNH DẤU ĐÃ TRẢ

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedRecord == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần trả!");
                return;
            }

            if (selectedRecord.ActualReturnDate.HasValue)
            {
                MessageBox.Show("Thiết bị đã được trả trước đó!");
                return;
            }

            if (DateTime.Today < selectedRecord.BorrowDate.Date)
            {
                MessageBox.Show(
                    "Ngày trả thực tế không được trước ngày mượn!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Xác nhận sinh viên đã hoàn trả thiết bị?",
                "Xác nhận trả thiết bị",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                selectedRecord.ActualReturnDate = DateTime.Today;

                bindingSource.ResetBindings(false);

                ApplyFilter();
                ClearInput();

                MessageBox.Show(
                    "Đã cập nhật trạng thái và ngày trả thực tế!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // LÀM MỚI

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        // CHỌN DÒNG DATAGRIDVIEW

        private void dgvBorrowRecords_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvBorrowRecords.CurrentRow == null ||
                !dgvBorrowRecords.CurrentRow.Selected)
                return;

            if (dgvBorrowRecords.CurrentRow.DataBoundItem
                is BorrowRecord record)
            {
                selectedRecord = record;

                txtBorrowId.Text = record.BorrowId;
                txtStudentId.Text = record.StudentId;
                txtStudentName.Text = record.StudentName;

                cboEquipment.Text = record.Equipment;

                numQuantity.Value = record.Quantity;

                dtpBorrowDate.Value = record.BorrowDate;
                dtpDueDate.Value = record.DueDate;

                if (record.ActualReturnDate.HasValue)
                {
                    dtpReturnDate.Value =
                        record.ActualReturnDate.Value;

                    dtpReturnDate.Checked = true;
                }
                else
                {
                    dtpReturnDate.Value = DateTime.Today;
                    dtpReturnDate.Checked = false;
                }

                UpdateStatus();

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

        // ÁP DỤNG TÌM KIẾM VÀ LỌC

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var filtered = borrowRecords.Where(x =>
                x.StudentId.ToLower().Contains(keyword) ||
                x.Equipment.ToLower().Contains(keyword)
            ).ToList();

            if (cboFilterStatus.SelectedIndex > 0)
            {
                string status = cboFilterStatus.Text;

                filtered = filtered.Where(x =>
                    x.Status == status
                ).ToList();
            }

            BindingList<BorrowRecord> result =
                new BindingList<BorrowRecord>(filtered);

            bindingSource.DataSource = result;

            int total = filtered.Count;

            int overdue = filtered.Count(x =>
                x.Status == "Quá hạn");

            lblTotal.Text = "Tổng số phiếu: " + total;

            lblOverdue.Text = "Số phiếu quá hạn: " + overdue;
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
            saveFileDialog.Title = "Xuất danh sách phiếu mượn";
            saveFileDialog.FileName = "DanhSachPhieuMuon.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder csv = new StringBuilder();

                    csv.AppendLine(
                        "MaPhieu,MaSinhVien,HoTen,ThietBi,SoLuong,NgayMuon,HanTra,NgayTraThucTe,TinhTrang");

                    foreach (DataGridViewRow row in dgvBorrowRecords.Rows)
                    {
                        if (row.DataBoundItem is BorrowRecord record)
                        {
                            csv.AppendLine(string.Join(",",
                                CsvValue(record.BorrowId),
                                CsvValue(record.StudentId),
                                CsvValue(record.StudentName),
                                CsvValue(record.Equipment),
                                CsvValue(record.Quantity.ToString()),
                                CsvValue(record.BorrowDate.ToString("dd/MM/yyyy")),
                                CsvValue(record.DueDate.ToString("dd/MM/yyyy")),
                                CsvValue(record.ActualReturnDate.HasValue
                                    ? record.ActualReturnDate.Value.ToString("dd/MM/yyyy")
                                    : ""),
                                CsvValue(record.Status)
                            ));
                        }
                    }

                    File.WriteAllText(
                        saveFileDialog.FileName,
                        csv.ToString(),
                        new UTF8Encoding(true));

                    MessageBox.Show(
                        "Xuất file CSV thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất CSV: " + ex.Message);
                }
            }
        }

        // XỬ LÝ DỮ LIỆU CSV

        private string CsvValue(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        // THOÁT CHƯƠNG TRÌNH

        private void menuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}