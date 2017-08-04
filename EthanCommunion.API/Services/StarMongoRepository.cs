using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthanCommunion.API.Entities;
using EthanCommunion.API.Models;
using AutoMapper;
using MongoDB.Driver;

namespace EthanCommunion.API.Services
{
    public class StarMongoRepository : IStarRepository
    {
        public readonly StarsMongoContext Context = new StarsMongoContext();

        public void Accept(InvitationDto invitation)
        {
            
        }

        public void Create(Star star)
        {
            //FOR MONGO WE JUST WANT THE DTO OBJECTS AND NOT THE SQL MODELS



            star.Addresses = new List<Address>
            {
                new Address
                {
                    AddressLine1 = "Line 1",
                    AddressLine2 = "Line 2",
                    State = "NSW",
                    Postcode = "2145",
                    Country = "Australia"
                }
            };


            var result = Mapper.Map<StarDto>(star);

            Context.Stars.InsertOne(result);
        }

        public void Delete(Star star)
        {
            
        }

        public void Edit(Star star)
        {
            
        }

        public Star GetStar(int starId, bool includeAddresses)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Star> GetStars()
        {
            List<StarDto> stars =  Context.Stars.AsQueryable().AsEnumerable().ToList();
            return stars.Select(X => Mapper.Map<Star>(X));
        }

        public bool Save()
        {
            return true;
        }
    }
}
