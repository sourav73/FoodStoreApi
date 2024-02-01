using Model.DTOs.Category;
using Model.EntityModel;

namespace Manager.Manager.BaseManager
{
    public interface ICategoryManager
    {
        Task<List<CategoryOutputDto>> GetCategories();
        Task<List<CategoryDDLOutputDto>> GetDropdownCategories();
        Task<bool> AddCategory(CategoryInputDto category);
        Task<bool> DeleteCategory(int id);
        Task<bool> UpdateCategory(int id, CategoryInputDto category);
    }
}
