using Microsoft.EntityFrameworkCore;
using Model.DTOs.Product;
using Model.EntityModel;
using Model.Enum;
using Repository.Repository.BaseRepository;

namespace Repository.Repository.Implementation
{
    public class ProductRepository : EntityRepository<ProductModel, int>, IProductRepository
    {
        private readonly DbEntity _db;
        public ProductRepository(DbEntity db) : base(db)
        {
            _db = db;
        }

        public async Task<List<CategoryWiseProductOutputDto>> GetCategoryWiseProducts()
        {
            var products = from product in _db.Products
                           join category in _db.Categories on product.FkCategoryId equals category.Id
                           group product by product.FkCategoryId into gp
                           select new CategoryWiseProductOutputDto
                           {
                               CategoryName = _db.Categories.FirstOrDefault(c => c.Id == gp.Key).CategoryName ?? "",
                               Products = gp.Select(p => new ProductInputOutputDto
                               {
                                   Id = p.Id,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Price = p.Price,
                                   ImagePath = p.ImagePath,
                                   Discount = p.Discount,
                                   FkCategoryId = gp.Key,
                                   Weight = p.Weight
                               }).ToList()
                           };
            return await products.ToListAsync();
        }
    }
}
