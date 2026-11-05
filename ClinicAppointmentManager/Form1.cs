using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicAppointmentManager
{
    public partial class Form1 : Form
    {
        private BindingList<Appointment> appointments;
        private BindingSource bindingSource;
        private AppointmentManager manager;

        private Appointment selectedAppointment;

        public Form1()
        {
            InitializeComponent();

            appointments = new BindingList<Appointment>();
            bindingSource = new BindingSource();
            manager = new AppointmentManager();

            LoadData();
            LoadComboBox();

            bindingSource.DataSource = appointments;
            dgvAppointments.DataSource = bindingSource;

            ApplyFilter();
            ClearInput();
        }

        // DỮ LIỆU MẪU

        private void LoadData()
        {
            appointments.Add(new Appointment
            {
                AppointmentId = "LH001",
                PatientName = "Nguyễn Văn Nam",
                Phone = "0912345678",
                AppointmentDate = DateTime.Now.AddHours(2),
                Doctor = "Nguyễn Văn An",
                Reason = "Khám tổng quát",
                Status = "Chờ khám"
            });

            appointments.Add(new Appointment
            {
                AppointmentId = "LH002",
                PatientName = "Trần Thị Hoa",
                Phone = "0987654321",
                AppointmentDate = DateTime.Now.AddHours(3),
                Doctor = "Trần Thị Bình",
                Reason = "Đau đầu",
                Status = "Đang khám"
            });

            appointments.Add(new Appointment
            {
                AppointmentId = "LH003",
                PatientName = "Lê Minh Tuấn",
                Phone = "0901234567",
                AppointmentDate = DateTime.Now.AddDays(1),
                Doctor = "Lê Minh Tuấn",
                Reason = "Khám tim mạch",
                Status = "Chờ khám"
            });

            appointments.Add(new Appointment
            {
                AppointmentId = "LH004",
                PatientName = "Phạm Thị Lan",
                Phone = "0971234567",
                AppointmentDate = DateTime.Now.AddDays(1).AddHours(2),
                Doctor = "Phạm Thị Hương",
                Reason = "Khám sức khỏe",
                Status = "Hoàn tất"
            });

            appointments.Add(new Appointment
            {
                AppointmentId = "LH005",
                PatientName = "Hoàng Văn Bình",
                Phone = "0961234567",
                AppointmentDate = DateTime.Now.AddDays(2),
                Doctor = "Nguyễn Văn An",
                Reason = "Đau bụng",
                Status = "Đã hủy"
            });
        }

        // LOAD COMBOBOX

        private void LoadComboBox()
        {
            cboDoctor.Items.Clear();

            foreach (string doctor in manager.Doctors)
            {
                cboDoctor.Items.Add(doctor);
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

            cboFilterStatus.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
        }

        // KIỂM TRA DỮ LIỆU

        private bool ValidateInput()
        {
            errorProvider1.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtAppointmentId.Text))
            {
                errorProvider1.SetError(
                    txtAppointmentId, "Vui lòng nhập mã lịch hẹn!");

                valid = false;
            }
            else
            {
                string oldId = selectedAppointment == null
                    ? ""
                    : selectedAppointment.AppointmentId;

                if (manager.IsDuplicateId(
                    appointments,
                    txtAppointmentId.Text.Trim(),
                    oldId))
                {
                    errorProvider1.SetError(
                        txtAppointmentId, "Mã lịch hẹn đã tồn tại!");

                    valid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                errorProvider1.SetError(
                    txtPatientName, "Vui lòng nhập họ tên bệnh nhân!");

                valid = false;
            }

            if (!manager.IsValidPhone(txtPhone.Text.Trim()))
            {
                errorProvider1.SetError(
                    txtPhone,
                    "Số điện thoại phải có 10-11 chữ số và bắt đầu bằng 0!");

                valid = false;
            }

            if (dtpAppointmentDate.Value < DateTime.Now)
            {
                errorProvider1.SetError(
                    dtpAppointmentDate,
                    "Ngày giờ hẹn không được nằm trong quá khứ!");

                valid = false;
            }

            if (cboDoctor.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cboDoctor, "Vui lòng chọn bác sĩ!");

                valid = false;
            }

            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cboStatus, "Vui lòng chọn trạng thái!");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                errorProvider1.SetError(
                    txtReason, "Vui lòng nhập lý do khám!");

                valid = false;
            }

            return valid;
        }

        // LẤY DỮ LIỆU TỪ FORM

        private Appointment GetAppointment()
        {
            return new Appointment
            {
                AppointmentId = txtAppointmentId.Text.Trim(),
                PatientName = txtPatientName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                AppointmentDate = dtpAppointmentDate.Value,
                Doctor = cboDoctor.Text,
                Reason = txtReason.Text.Trim(),
                Status = cboStatus.Text
            };
        }

        // XÓA TRẮNG FORM

        private void ClearInput()
        {
            selectedAppointment = null;

            errorProvider1.Clear();

            txtAppointmentId.Clear();
            txtPatientName.Clear();
            txtPhone.Clear();
            txtReason.Clear();

            dtpAppointmentDate.Value = DateTime.Now;

            cboDoctor.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            dgvAppointments.ClearSelection();

            txtAppointmentId.Focus();
        }

        // THÊM LỊCH HẸN

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            Appointment appointment = GetAppointment();

            appointments.Add(appointment);

            ApplyFilter();
            ClearInput();

            MessageBox.Show(
                "Thêm lịch hẹn thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // CẬP NHẬT LỊCH HẸN

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn cần cập nhật!");
                return;
            }

            if (!ValidateInput())
                return;

            Appointment newAppointment = GetAppointment();

            selectedAppointment.AppointmentId =
                newAppointment.AppointmentId;

            selectedAppointment.PatientName =
                newAppointment.PatientName;

            selectedAppointment.Phone =
                newAppointment.Phone;

            selectedAppointment.AppointmentDate =
                newAppointment.AppointmentDate;

            selectedAppointment.Doctor =
                newAppointment.Doctor;

            selectedAppointment.Reason =
                newAppointment.Reason;

            selectedAppointment.Status =
                newAppointment.Status;

            bindingSource.ResetBindings(false);

            ApplyFilter();
            ClearInput();

            MessageBox.Show(
                "Cập nhật lịch hẹn thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // XÓA LỊCH HẸN

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lịch hẹn này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                appointments.Remove(selectedAppointment);

                ApplyFilter();
                ClearInput();

                MessageBox.Show("Xóa lịch hẹn thành công!");
            }
        }

        // LÀM MỚI

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        // CHỌN DÒNG DATAGRIDVIEW

        private void dgvAppointments_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
                return;

            if (dgvAppointments.CurrentRow.DataBoundItem
                is Appointment appointment)
            {
                selectedAppointment = appointment;

                txtAppointmentId.Text = appointment.AppointmentId;
                txtPatientName.Text = appointment.PatientName;
                txtPhone.Text = appointment.Phone;

                dtpAppointmentDate.Value =
                    appointment.AppointmentDate;

                cboDoctor.Text = appointment.Doctor;
                txtReason.Text = appointment.Reason;
                cboStatus.Text = appointment.Status;

                errorProvider1.Clear();
            }
        }

        // TÌM KIẾM

        private void txtSearch_TextChanged(
            object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // LỌC THEO NGÀY VÀ TRẠNG THÁI

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // ÁP DỤNG TÌM KIẾM VÀ LỌC

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var filtered = appointments.Where(a =>
                a.PatientName.ToLower().Contains(keyword) ||
                a.Phone.Contains(keyword)
            ).ToList();

            if (dtpFilterDate.Checked)
            {
                filtered = filtered.Where(a =>
                    a.AppointmentDate.Date ==
                    dtpFilterDate.Value.Date
                ).ToList();
            }

            if (cboFilterStatus.SelectedIndex > 0)
            {
                string status = cboFilterStatus.Text;

                filtered = filtered.Where(a =>
                    a.Status == status
                ).ToList();
            }

            BindingList<Appointment> result =
                new BindingList<Appointment>(filtered);

            bindingSource.DataSource = result;

            lblCount.Text =
                "Tổng số lịch hẹn đang hiển thị: " + filtered.Count;
        }

        // BỎ LỌC

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            dtpFilterDate.Checked = false;

            cboFilterStatus.SelectedIndex = 0;

            ApplyFilter();
        }

        // XUẤT CSV

        private void menuExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
            saveFileDialog.Title = "Xuất danh sách lịch hẹn";
            saveFileDialog.FileName = "DanhSachLichHen.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder csv = new StringBuilder();

                    csv.AppendLine(
                        "MaLichHen,HoTen,SoDienThoai,NgayGioHen,BacSi,LyDoKham,TrangThai");

                    foreach (DataGridViewRow row in dgvAppointments.Rows)
                    {
                        if (row.DataBoundItem is Appointment a)
                        {
                            csv.AppendLine(string.Join(",",
                                CsvValue(a.AppointmentId),
                                CsvValue(a.PatientName),
                                CsvValue(a.Phone),
                                CsvValue(a.AppointmentDate.ToString("dd/MM/yyyy HH:mm")),
                                CsvValue(a.Doctor),
                                CsvValue(a.Reason),
                                CsvValue(a.Status)
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
                    MessageBox.Show("Lỗi xuất file: " + ex.Message);
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