using AzShip.Core.Interfaces.Repositories;
using AzShip.Infra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AzShip.Infra.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public AzShipContext DbContext;
        protected DbSet<T> DbSet;

        public Repository(AzShipContext context)
        {
            DbContext = context;

            DbSet = DbContext.Set<T>();
        }

        public virtual void Add(T obj)
        {
            DbSet.Add(obj);

        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsNoTracking()
                        .Where(predicate);
        }

        public virtual T QueryById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual T QueryById(int id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));

        }

        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));

        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            DbSet.Attach(obj);
            var entry = DbContext.Entry(obj);
            entry.State = EntityState.Modified;
        }
    }
}
