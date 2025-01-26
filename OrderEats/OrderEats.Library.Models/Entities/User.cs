using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class User
    {
        public long Id { get; set; }
        public long? FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public UserRole Role { get; set; }
        public bool IsActived { get; set; }
        public string Phone { get; set; } // Số điện thoại
        public string PasswordHash { get; set; } // Mã hóa mật khẩu
        public List<Address> Addresses { get; set; } // Danh sách địa chỉ của người dùng
        public List<Order> Orders { get; set; } // Danh sách đơn hàng của người dùng
    }

    public enum UserRole
    {
        Customer,
        Employee,
        Admin
    }
}
