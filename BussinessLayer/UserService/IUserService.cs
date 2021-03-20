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
    }
}
