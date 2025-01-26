using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class Notification
    {
        public int Id { get; set; }     // ID thông báo
        public int UserId { get; set; }             // ID người nhận thông báo
        public string Message { get; set; }         // Nội dung thông báo
        public DateTime NotificationDate { get; set; } // Thời gian gửi thông báo
        public NotificationType Type { get; set; }  // Loại thông báo (OrderConfirmed, OrderReady...)
        public bool IsDeleted { get; set; } = false;
        public bool IsRead { get; set; } = false;
    }

    public enum NotificationType
    {
        OrderConfirmed,  // Đơn hàng đã xác nhận
        OrderInProgress, // Đơn hàng đang xử lý
        OrderCompleted,  // Đơn hàng hoàn thành
        PaymentReceived  // Thanh toán đã nhận
    }

}
