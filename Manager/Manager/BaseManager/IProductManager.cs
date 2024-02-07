using Model.DTOs.Product;
using Model.EntityModel;

namespace Manager.Manager.BaseManager
{
    public interface IProductManager
    {
        Task<List<ProductInputOutputDto>> GetProducts();
        Task<bool> AddProduct(ProductInputOutputDto product);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int id, ProductInputOutputDto product);
    }
}
