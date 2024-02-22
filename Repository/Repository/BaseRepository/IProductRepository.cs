using Model.DTOs.Product;
using Model.EntityModel;

namespace Repository.Repository.BaseRepository
{
    public interface IProductRepository : IEntityRepository<ProductModel, int>
    {
        Task<List<CategoryWiseProductOutputDto>> GetCategoryWiseProducts();
    }
}
