using NestSeeker.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUser();
        User GetById(int id);
        User GetByEmail(string email);
        int AddUser(User user);
    }
}
