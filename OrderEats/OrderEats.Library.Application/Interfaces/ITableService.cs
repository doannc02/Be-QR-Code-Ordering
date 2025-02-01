using OrderEats.Library.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Interfaces
{
    public interface ITableService : IGenercRepository<TableDTO>
    {
        public string GenQrCode(int idTable);
        public Task<bool> AddMultiTable(List<TableDTO> tableDTOs);
    }
}
