using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace NestSeeker.Persistence.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly NestSeekerContext _context;
        public Repository(NestSeekerContext context)
        {
            this._context = context;
        }
        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().Where(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }


    }
}

