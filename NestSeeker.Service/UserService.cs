using NestSeeker.Data.Model;
using NestSeeker.Persistence;
using NestSeeker.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NestSeeker.Service
{
   public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork; //DI
        public UserService(IUnitOfWork unitOfWork) // Constructor Injection
        {
            this._unitOfWork = unitOfWork;
        }

      
        public IEnumerable<User> GetAllUser()
        {
            //NestSeekerContext context = new NestSeekerContext();
           // return context.Users.ToList();
            return this._unitOfWork.UserRepository.GetAll();
        }
        public User GetById(int id)
        {
            //NestSeekerContext context = new NestSeekerContext();
           // return context.Users.FirstOrDefault(x => x.Id == id);

            return this._unitOfWork.UserRepository.GetById(id);
        }
        public User GetByEmail(string email)
        {
           // NestSeekerContext context = new NestSeekerContext();
            //return context.Users.FirstOrDefault(X => X.Email == email);
           return this._unitOfWork.UserRepository.FirstOrDefault(X => X.Email == email);

        }

        public int AddUser(User user)
        {
           /* NestSeekerContext context = new NestSeekerContext();
            context.Users.Add(user);
            context.SaveChanges();
            return user.Id;*/


             this._unitOfWork.UserRepository.Add(user);
             this._unitOfWork.Save();
             return user.Id;
        }
    }
}

