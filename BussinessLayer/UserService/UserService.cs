using BussinessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer.UserService
{
   public class UserService : IUserService
    {

        private readonly IApplicationDbContext _dbContext;
        public UserService(IApplicationDbContext dbContext) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
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
    }
}
