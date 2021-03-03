using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreConfig.Models
{
    public class Settings
    {
        public EnviromentSettings EnviromentSettings { get; set; }
    }

    public class EnviromentSettings
    { 
        public string Name { get; set; } 
    }
}
