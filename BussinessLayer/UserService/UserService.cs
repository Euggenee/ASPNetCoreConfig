using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.UserService
{
   public class UserService : IUserService
    {

        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            var users = _dbContext.Users.ToList();
            var userRsult = new List<User>();
            foreach (var user in users)
            {
                var mapedUser = new User { FirstName = user.FirstName, LastName = user.LastName };
                userRsult.Add(mapedUser);
            }
            return userRsult;
        }

        public void AddUser(User user) 
        {
            var tempUser = new DataAccessLayer.Entities.User { FirstName = user.FirstName, LastName = user.LastName };
            if (tempUser != null)
            {
                _dbContext.Users.Add(tempUser);
                _dbContext.SaveChanges();
            }
           
        }
    }
}
