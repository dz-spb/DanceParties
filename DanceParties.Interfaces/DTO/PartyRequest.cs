using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DanceParties.Interfaces.DTO
{
    public class PartyRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int DanceId { get; set; }

        public string Name { get; set; }

        [Required]
        public DateTimeOffset Start { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}
