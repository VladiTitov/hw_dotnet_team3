using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HM12.Task1.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public TEntity GetItemByID(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        public IEnumerable<TEntity> GetItems();
        public void CreateItem(TEntity item);
        public void UpdateItem(TEntity item);
        public void DeleteItem(TEntity item);
    }
}
