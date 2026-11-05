using System;
using System.ComponentModel;
using System.Linq;

namespace LabEquipmentCheckout
{
    public class BorrowRecord
    {
        public string BorrowId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Equipment { get; set; }
        public int Quantity { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        public string Status
        {
            get
            {
                if (ActualReturnDate.HasValue)
                    return "Đã trả";

                if (DueDate.Date < DateTime.Today)
                    return "Quá hạn";

                return "Đang mượn";
            }
        }
    }

    public class BorrowManager
    {
        public string[] Equipments =
        {
            "Máy tính",
            "Laptop",
            "Máy chiếu",
            "Bàn phím",
            "Chuột",
            "Màn hình",
            "Arduino",
            "Router",
            "Switch"
        };

        public string[] Statuses =
        {
            "Tất cả",
            "Đang mượn",
            "Quá hạn",
            "Đã trả"
        };

        public bool IsDuplicateId(
            BindingList<BorrowRecord> list,
            string id,
            string oldId = "")
        {
            return list.Any(x =>
                x.BorrowId.Equals(
                    id, StringComparison.OrdinalIgnoreCase)
                && x.BorrowId != oldId);
        }
    }
}