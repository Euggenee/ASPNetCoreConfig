using BussinessLayer.ComputerService;
using BussinessLayer.Models;
using DataAccessLayer;
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
    public class ComputerController : ControllerBase
    {
        //Слабая завичимость через интерфейс депенденси инжектион
        private readonly IComputerService _computerService;
        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        //тестовое использование  ComputerService Заменили на AdvansedComputerService видим что все изм занимают много времени
      /*  private readonly AdvansedComputerService _advansedComputerService;
        public ComputerController(IApplicationDbContext applicationDbContext, ILogger logger)
        {
           _advansedComputerService = new AdvansedComputerService(applicationDbContext, logger);
        }*/

        [HttpPost]
        public ActionResult<string> AddManufacturer(ComputerManufacturerDto computerManufacturer)
        {
            if (computerManufacturer.ManufacturerName != null)
            {
                return _computerService.AddManufactuerer(computerManufacturer);
            }
            return BadRequest("You've tried to add an invalid data");
        }

        [HttpGet]
        public ActionResult<List<ComputerManufacturerDto>>GetManufacturers()
            {
            // return _advansedComputerService.GetComputerManufacturers();
            return _computerService.GetComputerManufacturers();
        }

        [HttpDelete]
        public ActionResult<bool>RemoveManufacturer(string id)
        {
             var isSuccsess = _computerService.DeleteManufacturer(id);
            if (isSuccsess)
            {
                return Ok();
            }
            return BadRequest($"A manufacturer with {id} id doesn't exsist!");
        }
    }
}
