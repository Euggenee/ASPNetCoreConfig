using BussinessLayer.Models;
using DataAccessLayer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BussinessLayer.AuthService
{
    public class AuthService: IAuthService
    {

        private readonly ApplicationDbContext _dbContext;
        public AuthService(ApplicationDbContext dbContext) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _dbContext = dbContext;
        }

        public bool UserIdentification(Login user)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(u => u.NickName == user.NickName && u.Password == user.Password);

            if (dbUser.NickName == user.NickName && dbUser.Password == user.Password)
            {
                return true;
            }
            return false;
        }

        public string GetToken()
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
            return tokenString;
        }
    }
}

