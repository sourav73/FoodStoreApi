using Model.EntityModel;
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
    }
}
