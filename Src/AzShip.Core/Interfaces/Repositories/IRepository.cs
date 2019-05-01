using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AzShip.Core.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T obj);
        void Remove(int id);
        void Remove(Guid id);
        void Update(T obj);
        int SaveChanges();
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
        T QueryFirst(Expression<Func<T, bool>> predicate);
        T QueryById(Guid id);
        T QueryById(int id);
    }
}
