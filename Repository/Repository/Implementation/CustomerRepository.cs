using Model.EntityModel;
using Repository.Repository.BaseRepository;
namespace Repository.Repository.Implementation
{
    public class CustomerRepository : EntityRepository<CustomerModel, int>, ICustomerRepository
    {
        private readonly DbEntity _db;
        public CustomerRepository(DbEntity db) : base(db)
        {
            _db = db;
        }
    }
}
