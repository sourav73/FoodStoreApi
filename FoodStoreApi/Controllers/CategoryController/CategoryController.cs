using Manager.Manager.BaseManager;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Category;
using Model.DTOs.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodStoreApi.Controllers.CategoryController
{
    [Route("api/categories")]
    [ApiController]
    [SwaggerTag("A collection of category APIs")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all categories", Description = "Get all categories for Food")]
        public async Task<ListResponse<CategoryOutputDto>> GetCategories()
        {
            var categories = await _categoryManager.GetCategories();

            return new ListResponse<CategoryOutputDto>() { Data = categories, Message = "Data found" };
        }
        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all categories for dropdown")]
        public async Task<ListResponse<CategoryDDLOutputDto>> GetDropdownCategories()
        {
            var categories = await _categoryManager.GetDropdownCategories();

            return new ListResponse<CategoryDDLOutputDto>() { Data = categories, Message = "Data found" };
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Add new category", Description = "Add new category to the category list")]
        public async Task<ObjectResponse<bool>> AddCategory(CategoryInputDto category)
        {
            bool isAdded = await _categoryManager.AddCategory(category);
            return new ObjectResponse<bool>() { Data = isAdded, Message = isAdded ? "Category added" : "Category adding failed!" };
        }
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a category", Description = "Update an existing category of the category list")]
        public async Task<ObjectResponse<bool>> UpdateCategory(int id, CategoryInputDto category)
        {
            bool isAdded = await _categoryManager.UpdateCategory(id, category);
            return new ObjectResponse<bool>() { Data = isAdded, Message = isAdded ? "Category updated" : "Category update failed!" };
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a category", Description = "Delete an existing category of the category list")]
        public async Task<ObjectResponse<bool>> DeleteCategory(int id)
        {
            bool isAdded = await _categoryManager.DeleteCategory(id);
            return new ObjectResponse<bool>() { Data = isAdded, Message = isAdded ? "Category deleted" : "Category delete failed!" };
        }
    }
}
