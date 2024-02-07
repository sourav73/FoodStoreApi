using Model.DTOs.Product;

namespace Manager.Manager.BaseManager
{
    public interface IProductManager
    {
        Task<List<ProductInputOutputDto>> GetProducts();
        Task<ProductInputOutputDto> GetProductById(int id);
        Task<bool> AddProduct(ProductInputOutputDto product);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int id, ProductInputOutputDto product);
    }
}
