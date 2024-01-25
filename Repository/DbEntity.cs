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
    }
}
