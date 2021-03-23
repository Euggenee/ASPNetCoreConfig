using BussinessLayer.Models;
using BussinessLayer.UserService;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userServise;
        public UsersController(IUserService userServise)
        {
            _userServise = userServise;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return _userServise.GetAll();
        }


        [HttpGet("user/(id)")]
        public ActionResult<User> GetUser(string id)
        {
            var userFound = _userServise.GetById(id);
            if (userFound != null)
            {
                return userFound;
            }
            else 
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public ActionResult<User> AdddUser(User user)
        {
            return _userServise.AdddUser(user);
        }


        [HttpPut]
        public ActionResult<User> EditUser(User user)
        {
            var userEdited = _userServise.EditUser(user);
            if (userEdited != null)
            {
                return userEdited;
            }
            else 
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        public ActionResult DeleteUser(string id)
        {
            var isSucsess = _userServise.Delete(id);

            if (isSucsess)
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }
    }
}
