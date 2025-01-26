using OrderEats.Library.Models.Common;
using OrderEats.Library.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Interfaces
{
    public interface IOrderRepository
    {
        public Task<DataPaging<OrderDTO>> GetAll();
        public Task<OrderDTO> GetDetail(int id);
        public Task<OrderDTO> Create(OrderDTO dto);

    }
}
