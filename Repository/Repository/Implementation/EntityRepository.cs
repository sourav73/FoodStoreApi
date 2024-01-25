using Microsoft.EntityFrameworkCore;
using Repository.Repository.BaseRepository;
using System.Linq.Expressions;

namespace Repository.Repository.Implementation
{
    public class EntityRepository<T, TId> : IEntityRepository<T, TId> where T : class
    {
        public DbEntity Db { get; set; }
        public EntityRepository(DbEntity dbContext) 
        {
            Db = dbContext;
        }

        public IQueryable<T> FindAll()
        {
            return Db.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Db.Set<T>().Where(expression);
        }
        public void Create(T entity)
        {
            Db.Set<T>().Add(entity);
        }

        public void Create(IEnumerable<T> entities)
        {
            Db.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<T> entities)
        {
            entities.ToList().ForEach(entity =>
            {
                Db.Entry(entity).State = EntityState.Modified;
            });
        }

        public void Delete(T entity)
        {
            UpdateEntityModificationStatus(entity, 2);
            Db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(IEnumerable<T> entities)
        {
            entities.ToList().ForEach(entity => 
            {
                UpdateEntityModificationStatus(entity, 2);
                Db.Entry(entity).State = EntityState.Modified;
            });
        }

        public void Delete(TId id)
        {
            var entity = Db.Set<T>().Find(id) ?? throw new Exception("Entity Not Found");
            UpdateEntityModificationStatus(entity, 2);
            Db.Entry(entity).State = EntityState.Modified;
        }

        public void HardDelete(T entity)
        {
            Db.Set<T>().Remove(entity);
        }

        public void HardDelete(IEnumerable<T> entities)
        {
            entities.ToList().ForEach(entity =>
            {
                Db.Set<T>().Remove(entity);
            });
        }

        public void DeleteByCondition(Expression<Func<T, bool>> expression)
        {
            var entities = Db.Set<T>().Where(expression).AsNoTracking().ToList();
            entities.ForEach(entity =>
            {
                UpdateEntityModificationStatus(entity, 2);
                Db.Entry(entity).State = EntityState.Modified;
            });
        }

        public void HardDeleteByCondition(Expression<Func<T, bool>> expression)
        {
            var entities = Db.Set<T>().Where(expression).AsNoTracking();
            Db.Set<T>().RemoveRange(entities);
        }

        public bool Save()
        {
            return Db.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await Db.SaveChangesAsync() > 0;
        }

        private void UpdateEntityModificationStatus(T entity, int operationType)
        {
            if(operationType == 1)
            {
                // Creating operation
                entity.GetType().GetProperty("RStatus")?.SetValue(entity, 1);
            }
            else if(operationType == 2)
            {
                // deleting operation
                entity.GetType().GetProperty("RStatus")?.SetValue(entity, 2);
            }
        }
    }
}
