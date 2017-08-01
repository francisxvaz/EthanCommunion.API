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
        [HttpGet()]
        public IActionResult GetStars()
        {
            return Ok(new JsonResult(new List<object>()
            {
                new { Id = 1, Name="Arun"}
            }));
            
        }

        [HttpGet("{id}")]
        public IActionResult GetStar(int id)
        {
            return NotFound();
        }
    }
}
