using Music.Data;
using Music.Repository.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Music.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : baseEntity
    {

        private Context _context;
        private DbSet<TEntity> _dbset;

        public Repository(Context context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }



        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> queryable = _dbset;
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }
            return queryable;
        }



        public TEntity GetById(int entityId)
        {
            return _dbset.SingleOrDefault(s => s.Id == entityId);
        }



        public void Insert(TEntity tEntity)
        {
            _dbset.Add(tEntity);
        }



        public void Update(TEntity tEntity)
        {
            _context.Entry(tEntity).State = EntityState.Modified;
        }



        public void Delete(TEntity tEntity)
        {
            _context.Entry(tEntity).State = EntityState.Deleted;
        }



        public bool IsExist(Expression<Func<TEntity, bool>> Where)
        {
           return _dbset.Any(Where);
        }



        public bool Any(Expression<Func<TEntity, bool>> condition )
        {
            return _dbset.Any(condition);
        }



        public void Dispose()
        {
            _context.SaveChanges();
        }

    }
}
