using NestSeeker.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Persistence.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<User> UserRepository { get; }
        int Save();
    }
}
