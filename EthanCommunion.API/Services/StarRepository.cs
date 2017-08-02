using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthanCommunion.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EthanCommunion.API.Services
{
    public class StarRepository : IStarRepository
    {
        private StarsContext _starContext;

        public StarRepository(StarsContext starsContext)
        {
            _starContext = starsContext;
        }

        public void Create(Star star)
        {
            _starContext.Add(star);
            //_starContext.SaveChanges();
        }

        public void Edit(Star star)
        {
            _starContext.Update<Star>(star);
        }

        public void Delete(Star star)
        {
            _starContext.Remove<Star>(star);
        }

        public Star GetStar(int starId, bool includeAddresses)
        {
            if (includeAddresses)
            {
                return _starContext.Star.Include(c => c.Addresses)
                        .Where(c => c.Id == starId).FirstOrDefault();
            }

            return _starContext.Star.Where(c => c.Id == starId).FirstOrDefault();
        }

        public IEnumerable<Star> GetStars()
        {
            return _starContext.Star.OrderBy(c => c.FirstName).ToList();
        }

        public bool Save()
        {
            return _starContext.SaveChanges() >= 0;
            //return true;

        }
    }
}
