using EMP.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EMP.DataAccess.GenericRepository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal EmployeeDataContext _context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository()
        {
        }
        
        public GenericRepository(EmployeeDataContext context)
        {
            this._context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public TEntity GetFirstOrDefault(Func<TEntity, bool> predicate)
        {
            return DbSet.FirstOrDefault<TEntity>(predicate);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if(_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }
    }
}
