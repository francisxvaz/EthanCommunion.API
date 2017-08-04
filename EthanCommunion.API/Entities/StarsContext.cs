using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthanCommunion.API.Entities
{
    public class StarsContext : DbContext, IStarsContext
    {
        public StarsContext(DbContextOptions<StarsContext> options) : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Star> Star { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Invitation> Invitation { get; set; }

        public void SetContext()
        {
            
        }
    }
}
