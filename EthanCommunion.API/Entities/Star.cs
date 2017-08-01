using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EthanCommunion.API.Entities
{
    public class Star
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infant { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
