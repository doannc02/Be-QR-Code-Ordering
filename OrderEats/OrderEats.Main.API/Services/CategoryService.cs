using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.Entities;

namespace OrderEats.Main.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenercRepository<Category> _categoryRepository;
        public CategoryService(IGenercRepository<Category> categoryRepository) { _categoryRepository = categoryRepository; }
        public async Task<IEnumerable<Category>> GetList()
        {
           return await _categoryRepository.GetAll();
        }
    }
}
