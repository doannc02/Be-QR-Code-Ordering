using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }     // ID thanh toán
        public int OrderId { get; set; }       // ID đơn hàng
        public decimal Amount { get; set; }    // Số tiền thanh toán
        public PaymentMethod Method { get; set; } // Phương thức thanh toán (Cash, CreditCard...)
        public DateTime PaymentDate { get; set; } // Thời gian thanh toán
    }

    public enum PaymentMethod
    {
        Cash,           // Tiền mặt
        CreditCard,     // Thẻ tín dụng
        EWallet         // Ví điện tử
    }

}
