using NestSeeker.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Persistence.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NestSeekerContext _context;
        public Repository<UserRole> UserRoleRepository { get; private set; }
        public Repository<User> UserRepository { get; }
        public Repository<Role> RoleRepository { get; }
        public Repository<Status> StatusRepository { get; }
        public Repository<TransactionType> TransactionTypeRepository { get; }
        public Repository<Requests> RequestsRepository { get; }
        public Repository<PropertyType> ProprtyTypeRepository { get; }
        public Repository<Property> PropertyRepository { get; }
        public Repository<MyFavourites> MyFavouritesRepository { get; }
        public Repository<Direction> DirectionRepository { get; }
        public Repository<BHKType> BHKTypeRepository { get; }
        public Repository<Document> DocumentRepository { get; }
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

