using Manager.Manager.BaseManager;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Category;
using Model.EntityModel;
using Model.Enum;
using Repository.Repository.BaseRepository;
using Utilities.Exceptions;

namespace Manager.Manager.Implementation
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryOutputDto>> GetCategories()
        {
            List<CategoryModel> existingCategories = await _categoryRepository.FindByCondition(c => c.RStatus == (int)EnumRStatus.Active).ToListAsync();
            List<CategoryOutputDto> categories = [];

            foreach (var category in existingCategories)
            {
                if(category.ParentId == 0)
                {
                    categories.Add(new CategoryOutputDto
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName,
                        SubCategories = GetSubCategories(existingCategories, category.Id)
                    });
                }
            }
            return categories;
        }

        public async Task<bool> AddCategory(CategoryInputDto category)
        {
            CategoryModel? existingCategory = _categoryRepository.FindByCondition(c =>
                c.CategoryName.ToLower() == category.CategoryName.ToLower() &&
                c.ParentId == category.ParentId &&
                c.RStatus == (int)EnumRStatus.Active
                ).FirstOrDefault();
            if(existingCategory != null)
            {
                throw new BadRequestException("Already exist");
            }

            CategoryModel newCategory = new CategoryModel
            {
                CategoryName = category.CategoryName,
                ParentId = category.ParentId
            };

            _categoryRepository.Create(newCategory);
            return await _categoryRepository.SaveAsync();
        }

        public async Task<bool> UpdateCategory(int id, CategoryInputDto category)
        {
            CategoryModel? existingCategory = _categoryRepository.FindByCondition(c => c.Id == id && c.RStatus == (int)EnumRStatus.Active).FirstOrDefault();
            if(existingCategory == null)
            {
                throw new BadRequestException("Category not found!");
            }
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.ParentId = category.ParentId;
            _categoryRepository.Update(existingCategory);
            return await _categoryRepository.SaveAsync();
        }

        public async Task<bool> DeleteCategory(int id)
        {
            CategoryModel? existingCategory = _categoryRepository.FindByCondition(c => c.Id == id && c.RStatus == (int)EnumRStatus.Active).FirstOrDefault();
            if(existingCategory == null)
            {
                throw new BadRequestException("Category not found!");
            }
            _categoryRepository.Delete(existingCategory);
            return await _categoryRepository.SaveAsync();
        }

        private List<SubCategoriesOutputDto> GetSubCategories(List<CategoryModel> categories, int currentCategoryId)
        {
            List<SubCategoriesOutputDto> subCategoriesOutputDto = categories.Where(c =>
                    c.ParentId == currentCategoryId &&
                    c.RStatus == (int)EnumRStatus.Active
                ).Select(c => new SubCategoriesOutputDto
                {
                    Id = c.Id,
                    ParentId = currentCategoryId,
                    CategoryName = c.CategoryName,
                    SubCategories = GetSubCategories(categories, c.Id)
                }).ToList();
            return subCategoriesOutputDto;
        }
    }
}
