using EthanCommunion.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthanCommunion.API.Models;

namespace EthanCommunion.API.Services
{
    public interface IStarRepository
    {
        IEnumerable<Star> GetStars();

        Star GetStar(int starId, bool includeAddresses);
        void Create(Star star);
        void Edit(Star star);
        void Delete(Star star);
        bool Save();

    }
}
