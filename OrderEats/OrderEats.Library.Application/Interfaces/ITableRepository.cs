using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Interfaces
{
    public interface ITableRepository : IGenercRepository<Table>
    {
        public string GetListTableIsOccupied();

        public Task<bool> AddMultiTable(List<Table> tableList);
    }
}
