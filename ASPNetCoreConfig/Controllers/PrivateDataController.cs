using BussinessLayer.ComputerService;
using BussinessLayer.Models;
using BussinessLayer.UserService;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreConfig.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PrivateDataController : ControllerBase
    {

        //тестовое использование  ComputerService
        private readonly IComputerService _computerService;
        private readonly IUserService _userService;

        public PrivateDataController(IUserService userService, IComputerService computerService)
        {
            _userService = userService;
            _computerService = computerService;   
        }

        //тестовое использование  ComputerService Заменили на AdvansedComputerService видим что все изм занимают много времени
        /* private readonly IUserService _userService;
         private readonly AdvansedComputerService _advansedComputerService;
         public PrivateDataController(IUserService userService, IApplicationDbContext applicationDbContext, ILogger logger)
         {
             _userService = userService;
             _advansedComputerService = new AdvansedComputerService(applicationDbContext, logger);
         }*/

        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {

            return new string[] { "First secred data string", "Second secred data string" };
        }

        [HttpGet]
        //[Authorize]
        [Route("get-users")]
        public List<User> GetAllUsers()
        {
            //тестовое использование  ComputerService
            //  var manufacturers = _advansedComputerService.GetComputerManufacturers();
              var manufacturers = _computerService.GetComputerManufacturers();
            return _userService.GetAll();
        }


        [HttpPost]
        [Route("post-user")]
        public void AddNewUser(User user)
        {
            _userService.AddUser(user);

        }
    }
}
