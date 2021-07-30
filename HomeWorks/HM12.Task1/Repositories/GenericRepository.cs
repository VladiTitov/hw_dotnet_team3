using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HM12.Task1.Repositories
{
    class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void CreateItem(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public TEntity GetItemByID(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).FirstOrDefault();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties.Aggregate(query,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<TEntity> GetItems() => _dbSet.AsNoTracking().ToList();

        public void UpdateItem(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
