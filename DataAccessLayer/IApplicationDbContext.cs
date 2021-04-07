
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ComputerManufacturer> ComputerManufacturers { get; set;}
        public DbSet<ComputerModel> ComputerModels { get; set; }
        public DbSet<ComputerModelTag> ComputerModelTags { get; set; }
        public int SaveChanges();
    }
}
