using EthanCommunion.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EthanCommunion.API.Controllers
{
    [Route("api/invitaion")]
    public class InvitationController : Controller
    {
        [HttpPost("accept")]
        public void Post([FromBody]InvitationDto model)
        {

        }
    }
}
