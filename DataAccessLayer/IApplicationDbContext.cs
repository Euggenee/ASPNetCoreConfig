
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
    }
}
