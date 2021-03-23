using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.UserService
{
   public interface IUserService
    {
        List<User> GetAll();
        void AddUser(User user);

        User GetById(string id);

        User AdddUser(User user);

        User EditUser(User user);

        bool Delete(string id);

    }
}
