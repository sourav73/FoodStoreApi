using System.Linq.Expressions;

namespace Repository.Repository.BaseRepository
{
    public interface IEntityRepository<T, TId> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Create(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Delete(TId id);
        void HardDelete(T entity);
        void HardDelete(IEnumerable<T> entities);
        void DeleteByCondition(Expression<Func<T, bool>> expression);
        void HardDeleteByCondition(Expression<Func<T, bool>> expression);
        bool Save();
        Task<bool> SaveAsync();
    }
}
