using NestSeeker.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Persistence.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NestSeekerContext _context;
        public Repository<User> UserRepository { get; }

        public UnitOfWork(NestSeekerContext context)
        {
            this._context = context;
            this.UserRepository = new Repository<User>(this._context);
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public int Save()
        {
            return this._context.SaveChanges();
        }
    }
}

