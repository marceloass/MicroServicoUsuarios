using JuntosSeguros.Controllers;
using JuntosSeguros.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuntosSeguros.Repository
{
    public class UserRepository
    {
        static UserController _user = new UserController();
        public static bool Create(User user)
        {
           return _user.Post(user);
        }
        
        public static User Read(int id)
        {
            return _user.Get(id);
        }
        public static bool Update(int id, User user)
        {
            return _user.Put(id, user);
        }
        public static bool Delete(int id)
        {
            return _user.Delete(id);
        }
    }
}
