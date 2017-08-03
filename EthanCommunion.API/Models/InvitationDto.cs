using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthanCommunion.API.Models
{
    public class InvitationDto
    {
        public int Id { get; set; }
        public int StarId { get; set; }
        public bool Accepted { get; set; }
        public string Token { get; set; }
    }
}
