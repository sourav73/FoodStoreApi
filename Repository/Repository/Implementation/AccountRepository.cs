using Model.EntityModel;
using Repository.Repository.BaseRepository;

namespace Repository.Repository.Implementation
{
    public class AccountRepository : EntityRepository<UserModel, int>, IAccountRepository
    {
        private readonly DbEntity _db;
        public AccountRepository(DbEntity db) : base(db)
        {
            _db = db;
        }
    }
}
