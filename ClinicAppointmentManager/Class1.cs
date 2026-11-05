using System;

namespace ClinicAppointmentManager
{
    public class Appointment
    {
        public string AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        public Appointment()
        {
            AppointmentId = "";
            PatientName = "";
            Phone = "";
            AppointmentDate = DateTime.Now;
            Doctor = "";
            Reason = "";
            Status = "Chờ khám";
        }
    }

    public class AppointmentManager
    {
        public bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            if (phone.Length < 10 || phone.Length > 11)
                return false;

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return phone[0] == '0';
        }

        public bool IsDuplicateId(
            System.ComponentModel.BindingList<Appointment> list,
            string id,
            string oldId = "")
        {
            foreach (Appointment a in list)
            {
                if (a.AppointmentId.Equals(
                    id, StringComparison.OrdinalIgnoreCase)
                    && a.AppointmentId != oldId)
                {
                    return true;
                }
            }

            return false;
        }

        public string[] Doctors =
        {
            "Nguyễn Văn An",
            "Trần Thị Bình",
            "Lê Minh Tuấn",
            "Phạm Thị Hương"
        };

        public string[] Statuses =
        {
            "Chờ khám",
            "Đang khám",
            "Hoàn tất",
            "Đã hủy"
        };
    }
}