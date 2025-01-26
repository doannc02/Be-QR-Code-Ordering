using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Entities
{
    public class NotificationLog
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }  // Mã thông báo
        public DateTime SentDate { get; set; }   // Thời gian gửi thông báo
        public bool IsRead { get; set; }         // Trạng thái đã đọc chưa
        public Notification Notification { get; set; }
    }

}
