using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class OrderItemNote
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }   // Mã món ăn trong đơn
        public string Note { get; set; }        // Ghi chú về món ăn
        public OrderItem OrderItem { get; set; } // Món ăn
    }

}
