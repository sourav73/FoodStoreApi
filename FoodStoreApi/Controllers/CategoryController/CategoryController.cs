using Manager.Manager.BaseManager;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Response;
using Model.EntityModel;
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
        public async Task<ListResponse<CategoryModel>> GetCategories()
        {
            var categories = await _categoryManager.GetCategories();

            return new ListResponse<CategoryModel>() { Data = categories, Message = "Data found" };
        }
    }
}
