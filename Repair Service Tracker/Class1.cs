using System;

namespace RepairServiceTracker
{
    public class RepairOrder
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string DeviceType { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime ReceiveDate { get; set; }
        public decimal EstimatedCost { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }

        public RepairOrder()
        {
            OrderId = "";
            CustomerName = "";
            Phone = "";
            DeviceType = "";
            ProblemDescription = "";
            ReceiveDate = DateTime.Today;
            EstimatedCost = 0;
            Status = "Mới tiếp nhận";
            ImagePath = "";
        }
    }

    public class RepairManager
    {
        public string[] DeviceTypes =
        {
            "Laptop",
            "Máy tính bàn",
            "Điện thoại",
            "Máy tính bảng",
            "Máy in",
            "Màn hình",
            "Thiết bị khác"
        };

        public string[] Statuses =
        {
            "Mới tiếp nhận",
            "Đang sửa",
            "Chờ linh kiện",
            "Hoàn tất",
            "Đã hủy"
        };

        public bool IsDuplicateId(
            System.ComponentModel.BindingList<RepairOrder> list,
            string id,
            string oldId = "")
        {
            foreach (RepairOrder order in list)
            {
                if (order.OrderId.Equals(
                    id, StringComparison.OrdinalIgnoreCase)
                    && order.OrderId != oldId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}