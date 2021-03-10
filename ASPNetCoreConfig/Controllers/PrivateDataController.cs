﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {

            return new string[] {"First secred data string", "Second secred data string"};
        }
    }
}
