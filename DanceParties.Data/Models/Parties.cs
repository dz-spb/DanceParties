using System;
using System.Collections.Generic;

namespace DanceParties.Data.Models
{
    public partial class Parties
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int DanceId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }

        public virtual Dances Dance { get; set; }
        public virtual Locations Location { get; set; }
    }
}
