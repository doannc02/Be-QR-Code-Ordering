using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Interfaces
{
    public interface IFoodItemService
    {
        Task<FoodItemDTO> CreateFoodItemAsync(FoodItemDTO foodItemDto);
        Task<FoodItemDTO> GetFoodItemAsync(long foodItemId);
        Task<IEnumerable<FoodItemDTO>> GetAllFoodItemsAsync();
        Task<IEnumerable<FoodItemDTO>> FindFoodItemAsyncByCategory(ParamsFindByCategory query);
        Task<bool> UpdateFoodItemAsync(long orderId, FoodItemDTO foodItemDto);
        Task<bool> DeleteFoodItemAsync(long foodItemId);
    }
}
