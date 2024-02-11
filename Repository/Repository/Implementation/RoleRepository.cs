using Model.EntityModel;
using Repository.Repository.BaseRepository;

namespace Repository.Repository.Implementation
{
    public class RoleRepository : EntityRepository<RoleModel, int>, IRoleRepository
    {
        private readonly DbEntity _db;
        public RoleRepository(DbEntity db) : base(db)
        {
            _db = db;
        }
    }
}
