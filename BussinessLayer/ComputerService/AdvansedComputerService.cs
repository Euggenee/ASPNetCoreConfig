using AutoMapper;
using BussinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer.ComputerService
{
    //тестовйй клон Computer servise 

  public  class AdvansedComputerService:IComputerService                   // наследуем для того что бы реализовать депенденси инж (и подменять сервисы легко без кододротства)
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;                                  //startap Logger
        private readonly Mapper _autoMapper;                               //конфигурация автомапер
        public AdvansedComputerService(IApplicationDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _dbContext = dbContext;
            var mapperConfig = new MapperConfiguration(cfg =>               //конфигурация автомапер
            {
                // cfg.CreateMap<ComputerManufacturer, ComputerManufacturerDto>();
                // cfg.CreateMap<ComputerModel, ComputerModelDto>();               //первй вариант мап влож обектов
                cfg.CreateMap<ComputerManufacturer, ComputerManufacturerDto>()     //2 вариант мап влож обектов
                .ForMember(dest=>dest.ComputerModels, opt => opt.MapFrom(src=> src.ComputerModels.Select(m=>new ComputerModelDto
                { 
                ModelName=m.ModelName
                })));
            });
            _autoMapper = new Mapper(mapperConfig);
        }

        public string AddManufactuerer(ComputerManufacturerDto computerManufacturer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteManufacturer(string id)
        {
            throw new NotImplementedException();
        }

        public List<ComputerManufacturerDto> GetComputerManufacturers()
        {
            _logger.LogInformation("AdvansedComputerService: GetComputerManufacturers");
            var manufacturers = _dbContext.ComputerManufacturers.Include(c => c.ComputerModels).ToList();
            //Include() Add in to manufacturers related records "using Microsoft.EntityFrameworkCore"

            //после применения aвтомап
            var resultList = _autoMapper.Map<List<ComputerManufacturer>, List<ComputerManufacturerDto>>(manufacturers);  //конфигурация автомапер

            // до автомап
           /* var resultList = new List<ComputerManufacturerDto>();
            foreach (var manfacturer in manufacturers)
            {
                resultList.Add(new ComputerManufacturerDto
                {
                    ManufacturerName = manfacturer.ManufacturerName,
                    ComputerModels = manfacturer?.ComputerModels?.Select(model => new ComputerModelDto
                    {
                        ModelName = model.ModelName
                    }).ToList()
                });
            }*/
            return resultList;
        }
    }
}
