using AutoMapper;
using EthanCommunion.API.Entities;
using EthanCommunion.API.Models;
using EthanCommunion.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthanCommunion.API.Controllers
{
    [Route("api/stars")]
    public class StarsController : Controller
    {
        private IStarRepository _starRepository;
        public StarsController(IStarRepository starRepository)
        {
            _starRepository = starRepository;
        }


        [HttpGet()]
        [DisableCors]
        public IActionResult GetStars()
        {
            var stars = _starRepository.GetStars();
            var result = Mapper.Map<IEnumerable<StarDto>>(stars);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetStar(int id)
        {
            var stars = _starRepository.GetStar(id, false);
            var result = Mapper.Map<StarDto>(stars);
            return Ok(result);
        }

        [HttpPut("edit")]
        public IActionResult Edit(StarDto star, int id)
        {
            var result = Mapper.Map<Star>(star);
            _starRepository.Edit(result, id);

            if (!_starRepository.Save())
            {
                return StatusCode(500, "A problem happened while saving the changes");
            }

            return Ok();
        }

        [HttpDelete()]
        public IActionResult Delete(StarDto star)
        {
            var result = Mapper.Map<Star>(star);
            _starRepository.Delete(result);

            if (!_starRepository.Save())
            {
                return StatusCode(500, "A problem happened while saving the changes");
            }

            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]StarDto star)
        {
            var result = Mapper.Map<Star>(star);

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(result.FirstName+' '+result.LastName);
            var password =  System.Convert.ToBase64String(plainTextBytes);
            result.Password = password;

            _starRepository.Create(result);

            if (!_starRepository.Save())
            {
                return StatusCode(500, "A problem happened while saving the changes");
            }

            return Ok();

        }
    }
}
