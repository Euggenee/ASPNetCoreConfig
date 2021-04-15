using ASPNetCoreConfig.Models;
using BussinessLayer.ComputerService;
using DataAccessLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreConfig.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        //тестовое использование  ComputerService Заменили на AdvansedComputerService видим что все изм занимают много времени
        /* private readonly AdvansedComputerService _advansedComputerService;
         public AuthController(IApplicationDbContext applicationDbContext, ILogger logger)
         {
             _advansedComputerService = new AdvansedComputerService(applicationDbContext, logger);
         }*/

        private readonly IComputerService _computerService;
        public AuthController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModels user) 
        {
            //тестовое использование  ComputerService
            // var manufacturers = _advansedComputerService.GetComputerManufacturers();
             var manufacturers = _computerService.GetComputerManufacturers();

            if (user == null) 
            {
                return BadRequest("Invalid data");

            }
            if (user.UserName == "jon" && user.Password == "123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new{Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
