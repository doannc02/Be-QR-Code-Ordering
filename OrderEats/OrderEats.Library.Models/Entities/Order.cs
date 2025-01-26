using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }  // Khách hàng thực hiện đơn hàng
        public string? CustomerName { get; set; } 
        public int TableId { get; set; }     // Mã bàn đặt
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Table Table { get; set; } // Thông tin về bàn
    }


    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }

    public enum PaymentStatus
    {
        Unpaid,
        Paid
    }

}
