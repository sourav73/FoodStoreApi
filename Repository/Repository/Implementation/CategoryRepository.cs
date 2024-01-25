using Model.EntityModel;
using Repository.Repository.BaseRepository;

namespace Repository.Repository.Implementation
{
    public class CategoryRepository : EntityRepository<CategoryModel, int>, ICategoryRepository
    {
        DbEntity _db;
        public CategoryRepository(DbEntity db) : base(db)
        {
            _db = db;
        }
    }
}
