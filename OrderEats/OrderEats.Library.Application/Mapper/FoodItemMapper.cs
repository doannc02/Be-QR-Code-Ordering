using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Mapper
{
    public class FoodItemMapper : IMapper<FoodItemDTO, FoodItem>
    {
        public FoodItem Map(FoodItemDTO source)
        {
            if (source == null) return null;
            var foodItem = new FoodItem()
            {
                CategoryId = source.CategoryId,
                Description = source.Description,   
                ImageUrl = source.ImageUrl,
                Id = source.Id,
                Name = source.Name,
                Price = source.Price,
            };
            return foodItem;
        }

        public FoodItemDTO Map(FoodItem destination)
        {
            if (destination == null) return null;
            var foodItem = new FoodItemDTO()
            {
                CategoryId = destination.CategoryId,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl,
                Id = destination.Id,
                Name = destination.Name,
                Price = destination.Price,
            };
            return foodItem;
        }

        public List<FoodItem> MapList(IEnumerable<FoodItemDTO> source)
        {
            if (source == null) return null;
            return source.Select(Map).ToList();
        }
    }
}
