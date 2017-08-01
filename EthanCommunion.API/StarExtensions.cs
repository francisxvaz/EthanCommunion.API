using EthanCommunion.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthanCommunion.API
{
    public  static class StarExtensions
    {
        public static void EnsureSeedDataForContext(this StarsContext context)
        {
            if (context.Star.Any())
            {
                return;
            }

            var stars = new List<Star>
            {
                new Star()
                {
                    FirstName = "Arun",
                    LastName = "Dsouza",
                    Email = "eyebrowman@gmail.com",
                    Mobile = "0403698088",
                    Adults = 4,
                    Children = 2,
                    Infant = 0,
                    Addresses = new List<Address>()
                    {
                       new Address()
                       {
                           AddressLine1 = "Line 1",
                           AddressLine2 = "Line 2",
                           State = "NSW",
                           Country = "Australia",
                           Postcode = "2145",
                       }
                    }
                }
            };

            context.Star.AddRange(stars);
            context.SaveChanges();

        }
    }
}
