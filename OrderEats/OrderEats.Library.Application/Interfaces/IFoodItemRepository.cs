using OrderEats.Library.Models.Common;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Entities;
using OrderEats.Library.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Interfaces
{
    public interface IFoodItemRepository : IGenercRepository<FoodItem>
    {
        public Task<IEnumerable<FoodItem>> FindByCategory(ParamsFindByCategory query);
    }
}
