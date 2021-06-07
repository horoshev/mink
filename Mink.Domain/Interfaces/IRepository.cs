using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mink.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        T Add(T item);
        T Delete(T item);
        T Update(T item);
        IEnumerable<T> Add(IEnumerable<T> items);
        IEnumerable<T> Delete(IEnumerable<T> items);
        void Save();
    }
}