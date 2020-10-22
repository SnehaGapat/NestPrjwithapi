using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace NestSeeker.Persistence.Infrastructure
{
  public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
