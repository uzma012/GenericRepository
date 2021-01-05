using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepoExample.Models
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        public TEntity GetByID(int id);
        public void insert(TEntity entity);
        public bool Delete(int id);
        public bool Delete(TEntity entity);

        public string Update(TEntity entity);
    }
}
