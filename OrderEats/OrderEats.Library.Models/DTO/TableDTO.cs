using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.DTO
{
    public class TableDTO
    {
        public int? Id { get; set; }       // ID bàn
        public string TableNumber { get; set; } // Số bàn
        public bool IsOccupied { get; set; }    // Trạng thái có người ngồi hay không
        public string? QRCode { get; set; } = "";   // Mã QR liên kết với bàn
    }
}
