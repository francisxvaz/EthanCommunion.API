using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EthanCommunion.API.Entities
{
    public class Invitation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Accepted { get; set; }

        public int NumberOfAdultsAttending { get; set; }
        public int NumberOfChildrenAttending { get; set; }
        public int NumberOfInfantsAttending { get; set; }

        public DateTime AcceptedDate { get; set; }

        [ForeignKey("StarId")]
        public Star Star { get; set; }

        public int StarId { get; set; }

    }
}
