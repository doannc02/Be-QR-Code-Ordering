using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.DTO
{
    public class OrderDTO
    {
        public int? Id { get; set; }
        public string CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int TableId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public int? Id { get; set; }
        public int? OrderId { get; set; }   
        public int FoodItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }      
    }

}
