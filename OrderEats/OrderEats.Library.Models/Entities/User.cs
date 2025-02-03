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
        public long FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public bool IsActived { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; } 
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; } 
    }

    public enum UserRole
    {
        Customer,
        Employee,
        Admin
    }
}
