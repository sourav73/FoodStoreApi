using Model.EntityModel;

namespace Manager.Manager.BaseManager
{
    public interface ICategoryManager
    {
        Task<List<CategoryModel>> GetCategories();
    }
}
