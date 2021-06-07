using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mink.Domain.Interfaces;

namespace Mink.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MinkDbContext DbContext;
        protected readonly DbSet<T> Data;

        public Repository(MinkDbContext dbContext)
        {
            DbContext = dbContext;
            Data = dbContext.Set<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return Data.AsQueryable().Where(expression).ToArray();
        }

        public T Add(T item)
        {
            Data.Add(item);

            return item;
        }

        public T Delete(T item)
        {
            Data.Remove(item);

            return item;
        }

        public T Update(T item)
        {
            DbContext.Entry(item).State = EntityState.Modified;

            return item;
        }

        public IEnumerable<T> Add(IEnumerable<T> items)
        {
            var array = items as T[] ?? items.ToArray();

            Data.AddRange(array);

            return array;
        }

        public IEnumerable<T> Delete(IEnumerable<T> items)
        {
            var array = items as T[] ?? items.ToArray();

            Data.RemoveRange(array);

            return array;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}