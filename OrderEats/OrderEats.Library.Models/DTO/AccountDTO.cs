using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.DTO
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public long? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public int UserRole { get; set; }
        public UserRole Role { get; set; }
        public bool? IsActived { get; set; }
        public string Phone { get; set; } // Số điện thoại
        public string PasswordHash { get; set; } // Mã hóa mật khẩu
        
    }
}
