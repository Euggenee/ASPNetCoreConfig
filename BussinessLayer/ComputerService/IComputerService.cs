using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.ComputerService
{
  public interface IComputerService
    {

        List<ComputerManufacturerDto> GetComputerManufacturers();
        string AddManufactuerer(ComputerManufacturerDto computerManufacturer);
        bool DeleteManufacturer(string id);
    }
}
