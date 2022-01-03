using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Base
{
    public interface IEntityService<TEntity>
    {
        public Task<TEntity> GetById(int Id);
        public Task<List<TEntity>> GetAll();
        public Task Add(TEntity entity);
        public Task AddRange(List<TEntity> entities);
        public Task Update(TEntity entity);
        public Task UpdateRange(List<TEntity> entities);
        public Task Delete(TEntity entity);
    }
}
