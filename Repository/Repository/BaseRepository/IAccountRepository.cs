using Model.EntityModel;

namespace Repository.Repository.BaseRepository
{
    public interface IAccountRepository : IEntityRepository<UserModel, int>
    {
    }
}
