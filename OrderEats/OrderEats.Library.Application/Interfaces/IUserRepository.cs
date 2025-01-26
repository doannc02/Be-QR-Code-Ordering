using OrderEats.Library.Models.Common;
using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Interfaces
{
    public interface IUserRepository : IGenercRepository<User>
    {
        Task<IEnumerable<User>> Filter();
        // Task<DataPaging<User>> FilterPaging();
        Task<long> Count();
    }
}
