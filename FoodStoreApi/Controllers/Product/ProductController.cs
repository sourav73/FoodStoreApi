using Manager.Manager.BaseManager;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Category;
using Model.DTOs.Product;
using Model.DTOs.Response;
using Model.EntityModel;
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

        [HttpGet("/products")]
        [SwaggerOperation(Summary = "Get all products")]
        public async Task<ListResponse<ProductInputOutputDto>> GetProducts()
        {
            var products = await _productManager.GetProducts();

            return new ListResponse<ProductInputOutputDto>() { Data = products, Message = "Data found" };
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
