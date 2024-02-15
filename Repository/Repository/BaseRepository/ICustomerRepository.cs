using Model.EntityModel;

namespace Repository.Repository.BaseRepository
{
    public interface ICustomerRepository : IEntityRepository<CustomerModel, int>
    {
    }
}
