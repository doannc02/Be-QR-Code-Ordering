using Microsoft.EntityFrameworkCore;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.Common;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Entities;
using OrderEats.Library.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Infrastructure.Repository
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly OrderEatsDbContext _context;
        public FoodItemRepository(OrderEatsDbContext context)
        {
            _context = context;
        }

        public Task<int> Add(FoodItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FoodItem>> FindByCategory(ParamsFindByCategory query)
        {
            var foodItemsQuery = _context.FoodItems.AsNoTracking();

            if (query.CategoryId != null)
            {
                foodItemsQuery = foodItemsQuery.Where(f => f.CategoryId == query.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                foodItemsQuery = foodItemsQuery.Where(f =>
                    f.Name.Contains(query.Search, StringComparison.OrdinalIgnoreCase) ||
                    f.Id.ToString().Contains(query.Search));
            }

            return await foodItemsQuery.ToListAsync();
        }

        public Task<FoodItem> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FoodItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, FoodItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
