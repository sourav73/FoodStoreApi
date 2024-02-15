using Model.DTOs.Product;

namespace Manager.Manager.BaseManager
{
    public interface IProductManager
    {
        Task<List<ProductInputOutputDto>> GetProducts();
        Task<ProductInputOutputDto> GetProductById(int productId);
        Task<List<ProductInputOutputDto>> GetProductsByCategory(int categoryId);
        Task<bool> AddProduct(ProductInputOutputDto product);
        Task<bool> DeleteProduct(int productId);
        Task<bool> UpdateProduct(int productId, ProductInputOutputDto product);
    }
}
