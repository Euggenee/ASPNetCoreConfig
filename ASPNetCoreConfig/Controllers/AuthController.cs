using ASPNetCoreConfig.Models;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModels user) 
        {
            if (user == null) 
            {
                return BadRequest("Invalid data");

            }
            if (user.UserName == "jon" && user.Password == "123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "thhp://localhost:44382",
                    audience: "thhp://localhost:44382",
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
