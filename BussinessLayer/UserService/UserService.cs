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

        public User GetById(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            else 
            {
                var foundUser = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return foundUser;
            }
            
        }

        public User AdddUser(User user)
        {
            var userToAdd = new DataAccessLayer.Entities.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            _dbContext.Users.Add(userToAdd);
            _dbContext.SaveChanges();
            return user;
        }

        public User EditUser(User user)
        {
            var userToEdit = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

            if (userToEdit != null)
            {
                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;
             
                _dbContext.Users.Update(userToEdit);
                _dbContext.SaveChanges();

                return user;
            }
            else
            {
                return null;
            }

        }

        public bool Delete(string id)
        {
           var user =  _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if ( user != null) 
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
          
        }
    }
}
