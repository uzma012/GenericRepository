using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace GenericRepoExample.Models

{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal SchoolContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(SchoolContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public bool Delete(int id)
        {
            T entity = dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
                return true;

            }
            else return false;
            
        }

        public bool Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
                return true;
            }
            else return false;
        }

        public IEnumerable<T> Get(
        
            Expression<Func<T, bool>> filter = null,
             Func< IQueryable<T>, IOrderedQueryable < T >> orderBy = null, string includeProperties = "")
        {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }

        public T GetByID(int id)
        {
            return dbSet.Find(id);

        }

        public void insert(T entity)
        {
            dbSet.Add(entity);
        }

        public string Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return "updated";
        }
    }
}