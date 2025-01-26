using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class TableHistory
    {
        public int Id { get; set; }
        public int TableId { get; set; }  // Mã bàn
        public int UserId { get; set; }   // Người dùng đã sử dụng bàn
        public DateTime StartTime { get; set; } // Thời gian bắt đầu
        public DateTime EndTime { get; set; }   // Thời gian kết thúc (khi khách rời)
    }

}
