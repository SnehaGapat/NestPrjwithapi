using NestSeeker.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Persistence.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<User> UserRepository { get; }
        Repository<UserRole> UserRoleRepository { get; }
        Repository<Role> RoleRepository { get; }
        Repository<Status> StatusRepository { get; }
        Repository<TransactionType> TransactionTypeRepository { get; }
        Repository<Requests> RequestsRepository { get; }
        Repository<PropertyType> ProprtyTypeRepository { get; }
        Repository<Property> PropertyRepository { get; }
        Repository<MyFavourites> MyFavouritesRepository { get; }
        Repository<Direction> DirectionRepository { get; }
        Repository<BHKType> BHKTypeRepository { get; }
        Repository<Document> DocumentRepository { get; }
        int Save();
    }
}
