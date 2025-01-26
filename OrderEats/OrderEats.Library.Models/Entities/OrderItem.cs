using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }   // ID chi tiết đơn hàng
        public int OrderId { get; set; }        // ID đơn hàng
        public int FoodItemId { get; set; }     // ID món ăn
        public int Quantity { get; set; }       // Số lượng món ăn
        public decimal Price { get; set; }      // Giá món ăn
        public string Notes { get; set; }       // Ghi chú (cay, chua, thêm ớt, v.v.)
        public Order Order { get; set; }        // Đơn hàng
        public FoodItem FoodItem { get; set; }  // Món ăn
    }

}
