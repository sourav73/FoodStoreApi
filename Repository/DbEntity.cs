using Microsoft.EntityFrameworkCore;
using Model.EntityModel;

namespace Repository
{
    public class DbEntity : DbContext
    {
        public DbEntity(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
