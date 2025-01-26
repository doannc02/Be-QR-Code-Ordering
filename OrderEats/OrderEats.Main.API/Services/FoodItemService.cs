using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Application.Mapper;
using OrderEats.Library.Application.Mappers;
using OrderEats.Library.Infrastructure.Repository;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Entities;
using OrderEats.Library.Models.Filter;

namespace OrderEats.Main.API.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly FoodItemMapper _foodItemMapper;
        public FoodItemService(IFoodItemRepository foodItemRepository, FoodItemMapper foodItemMapper)
        {
            _foodItemRepository = foodItemRepository;
            _foodItemMapper = foodItemMapper;
        }

        public Task<FoodItemDTO> CreateFoodItemAsync(FoodItemDTO foodItemDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFoodItemAsync(long foodItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FoodItemDTO>> GetAllFoodItemsAsync()
        {
            var orders = await _foodItemRepository.GetAll();
            return orders.Select(order => _foodItemMapper.Map(order));
        }


        public async Task<IEnumerable<FoodItemDTO>> FindFoodItemAsyncByCategory(ParamsFindByCategory query)
        {
            var orders = await _foodItemRepository.FindByCategory(query);
            return orders.Select(order => _foodItemMapper.Map(order));
        }

        public Task<FoodItemDTO> GetFoodItemAsync(long foodItemId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFoodItemAsync(long orderId, FoodItemDTO foodItemDto)
        {
            throw new NotImplementedException();
        }
    }
}
