﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthanCommunion.API.Entities
{
    public class StarsContext : DbContext
    {
        public StarsContext(DbContextOptions<StarsContext> options) : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Star> Star { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}