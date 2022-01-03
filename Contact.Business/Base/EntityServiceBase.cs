using Contact.Data;
using Contact.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Contact.Business.Base
{
    public class EntityServiceBase<TEntity> : IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        public virtual async Task Add(TEntity entity)
        {
            using (var db = new ContactDbContext())
            {
                entity.CreateDate = DateTime.Now;
                db.Entry<TEntity>(entity).State = EntityState.Added;
                await db.SaveChangesAsync();
            }
        }

        public virtual async Task AddRange(List<TEntity> entities)
        {
            using (var db = new ContactDbContext())
            {
                entities.ForEach(e =>
                {
                    e.CreateDate = DateTime.Now;
                    db.Entry<TEntity>(e).State = EntityState.Added;
                });
                await db.SaveChangesAsync();
            }
        }

        public virtual async Task Update(TEntity entity)
        {
            using (var db = new ContactDbContext())
            {
                entity.UpdateDate = DateTime.Now;
                db.Entry<TEntity>(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public virtual async Task UpdateRange(List<TEntity> entities)
        {
            using (var db = new ContactDbContext())
            {
                entities.ForEach(e =>
                {
                    e.UpdateDate = DateTime.Now;
                    db.Entry<TEntity>(e).State = EntityState.Modified;
                });
                await db.SaveChangesAsync();
            }
        }

        public virtual async Task Delete(TEntity entity)
        {
            using (var db = new ContactDbContext())
            {
                entity.isDeleted = true;
                entity.DeleteDate = DateTime.Now;
                db.Entry<TEntity>(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            using (var db = new ContactDbContext())
            {
                return await db.Set<TEntity>()
                               .AsNoTracking()
                               .Where(w => !w.isDeleted)
                               .ToListAsync();
            }
        }

        public virtual async Task<TEntity> GetById(int Id)
        {
            using (var db = new ContactDbContext())
            {
                return await db.Set<TEntity>()
                               .AsNoTracking()
                               .FirstOrDefaultAsync(w => w.Id == Id);
            }
        }
    }
}
