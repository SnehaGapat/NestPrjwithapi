using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Data.Model
{
   public class MyFavourites
    {
        public int ID { get; set; }
        public int UserRoleId { get; set; }  //foreign key
        public UserRole UserRole { get; set; }
        public int PropertyId { get; set; }   //foreign key
        public Property Property { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public IList<Property> Properties { get; set; }
    }
}
