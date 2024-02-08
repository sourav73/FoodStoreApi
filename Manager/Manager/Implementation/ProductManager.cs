using Manager.Manager.BaseManager;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Product;
using Model.EntityModel;
using Model.Enum;
using Repository.Repository.BaseRepository;
using Utilities.Exceptions;

namespace Manager.Manager.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProduct(ProductInputOutputDto product)
        {
            ProductModel newProduct = new ProductModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                FkCategoryId = product.FkCategoryId,
                Discount = product.Discount,
                Weight = product.Weight,
                ImagePath = product.ImagePath,
            };
            _productRepository.Create(newProduct);
            return await _productRepository.SaveAsync();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            return await _productRepository.SaveAsync();
        }

        public async Task<List<ProductInputOutputDto>> GetProducts()
        {
            List<ProductInputOutputDto> products = await _productRepository.FindByCondition(p =>
                    p.RStatus == (int)EnumRStatus.Active
                ).Select(p => new ProductInputOutputDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    FkCategoryId = p.FkCategoryId,
                    ImagePath = p.ImagePath,
                    Discount = p.Discount,
                    Weight = p.Weight
                }).ToListAsync();
            return products;
        }
        public async Task<ProductInputOutputDto> GetProductById(int id)
        {
            ProductInputOutputDto product = await _productRepository.FindByCondition(p =>
                    p.Id == id &&
                    p.RStatus == (int)EnumRStatus.Active
                ).Select(p => new ProductInputOutputDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    FkCategoryId = p.FkCategoryId,
                    ImagePath = p.ImagePath,
                    Discount = p.Discount,
                    Weight = p.Weight
                }).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new BadRequestException("Product not found");
            }
            return product;
        }

        public async Task<bool> UpdateProduct(int id, ProductInputOutputDto product)
        {
            ProductModel existingProduct = _productRepository.FindByCondition(p =>
                    p.Id == id && p.RStatus == (int)EnumRStatus.Active
                ).FirstOrDefault() ?? throw new BadRequestException("Product not found!");

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.FkCategoryId = product.FkCategoryId;
            existingProduct.Weight = product.Weight;
            existingProduct.Discount = product.Discount;
            existingProduct.ImagePath = product.ImagePath;
            _productRepository.Update(existingProduct);
            return await _productRepository.SaveAsync();
        }

        public async Task<List<ProductCommonOutputDto>> GetProductsByCategory(int categoryId)
        {
            List<ProductModel> products = await _productRepository.FindByCondition(p =>
                p.FkCategoryId == categoryId && p.RStatus == (int)EnumRStatus.Active).AsNoTracking().ToListAsync();

            return products.Select(p => new ProductCommonOutputDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Discount = p.Discount,
                Weight = p.Weight
            }).ToList();
        }
    }
}
