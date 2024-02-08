using Manager.Manager.BaseManager;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Product;
using Model.DTOs.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodStoreApi.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("A collection of product APIs")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("/api/products")]
        [SwaggerOperation(Summary = "Get all products")]
        public async Task<ListResponse<ProductInputOutputDto>> GetProducts()
        {
            var products = await _productManager.GetProducts();

            return new ListResponse<ProductInputOutputDto>() { Data = products, Message = "Data found" };
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get specific product by its id")]
        public async Task<ObjectResponse<ProductInputOutputDto>> GetProduct(int id)
        {
            var product = await _productManager.GetProductById(id);

            return new ObjectResponse<ProductInputOutputDto>() { Data = product, Message = "Data found" };
        }

        [HttpGet("category/{categoryId}")]
        [SwaggerOperation(Summary = "Get all products for a category")]
        public async Task<ListResponse<ProductCommonOutputDto>> GetProductsByCategory(int categoryId)
        {
            var product = await _productManager.GetProductsByCategory(categoryId);

            return new ListResponse<ProductCommonOutputDto>() { Data = product, Message = "Data found" };
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new product")]
        public async Task<ObjectResponse<bool>> AddCategory(ProductInputOutputDto product)
        {
            bool isAdded = await _productManager.AddProduct(product);
            return new ObjectResponse<bool>() { Data = isAdded, Message = isAdded ? "Product added" : "Product adding failed!" };
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a product")]
        public async Task<ObjectResponse<bool>> UpdateCategory(int id, ProductInputOutputDto product)
        {
            bool isAdded = await _productManager.UpdateProduct(id, product);
            return new ObjectResponse<bool>() { Data = isAdded, Message = isAdded ? "Product updated" : "Product update failed!" };
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a product")]
        public async Task<ObjectResponse<bool>> DeleteProduct(int id)
        {
            bool isDeleted = await _productManager.DeleteProduct(id);
            return new ObjectResponse<bool>() { Data = isDeleted, Message = isDeleted ? "Product deleted" : "Product delete failed!" };
        }
    }
}
