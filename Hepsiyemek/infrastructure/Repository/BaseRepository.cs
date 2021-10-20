using Hepsiyemek.infrastructure.Entites;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hepsiyemek.infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EmptyBaseEntity
    {
        public BaseRepository()
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
        }

      
        
        public TEntity Add(TEntity entity)
        {
            try
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
                DbContext.ActiveInstance.Db.GetCollection<TEntity>(entity.GetType().Name).Insert(entity);
            }
            catch (Exception e)
            {
                
                throw e;
            }


            return entity;
        }



        public IEnumerable<TEntity> GetAll()
        {

            return DbContext.ActiveInstance.Db.GetCollection<TEntity>(typeof(TEntity).Name).FindAll();
        }

        public TEntity GetById(string Id)
        {

            var res = Query<TEntity>.EQ(x => x.ID, Id);
            return DbContext.ActiveInstance.Db.GetCollection<TEntity>(typeof(TEntity).Name).FindOne(res);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {

            var res = Query<TEntity>.Where(expression);


            return DbContext.ActiveInstance.Db.GetCollection<TEntity>(typeof(TEntity).Name).Find(res);
        }

        public void Update(TEntity entity)
        {

            var res = Query<TEntity>.EQ(x => x.ID, entity.ID);
            var operation = Update<TEntity>.Replace(entity);
            DbContext.ActiveInstance.Db.GetCollection<TEntity>(typeof(TEntity).Name).Update(res, operation);
        }

        public void Remove(TEntity entity)
        {
            var res = Query<TEntity>.EQ(x => x.ID, entity.ID);
            var operation = Update<TEntity>.Replace(entity);
            DbContext.ActiveInstance.Db.GetCollection<TEntity>(typeof(TEntity).Name).Remove(res);

        }
    }
}
