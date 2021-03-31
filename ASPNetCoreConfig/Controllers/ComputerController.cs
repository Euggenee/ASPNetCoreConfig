using BussinessLayer.ComputerService;
using BussinessLayer.Models;
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
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;
        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

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
