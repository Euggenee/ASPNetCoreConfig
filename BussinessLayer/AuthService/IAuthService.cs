using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.AuthService
{
    public interface IAuthService
    {
       public bool UserIdentification(Login login);
        public string GetToken();
    }
}
