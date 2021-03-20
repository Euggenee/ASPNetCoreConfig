using BussinessLayer.Models;
using BussinessLayer.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ASPNetCoreConfig.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login user) 
        {
           bool userIdentification = _authService.UserIdentification(user);

            if (userIdentification == false) 
            {
                return BadRequest("Invalid data");
            }
            if (userIdentification)
            {
                return Ok(new{Token =  _authService.GetToken()});
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
