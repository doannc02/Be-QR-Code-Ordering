using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class Counter
    {
        public int Id { get; set; }  // Mã quầy
        public string Name { get; set; }    // Tên quầy (vd: Quầy 1, Quầy 2...)
        public int? StaffId { get; set; }   // ID nhân viên phụ trách
    }
}
