using Hepsiyemek.infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hepsiyemek.infrastructure.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : EmptyBaseEntity
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string Id);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
