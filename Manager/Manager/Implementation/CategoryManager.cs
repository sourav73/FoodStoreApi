using Manager.Manager.BaseManager;
using Microsoft.EntityFrameworkCore;
using Model.EntityModel;
using Repository.Repository.BaseRepository;

namespace Manager.Manager.Implementation
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            List<CategoryModel> categories = await _categoryRepository.FindByCondition(c => c.RStatus == 1).ToListAsync();
            return categories;
        }
    }
}
