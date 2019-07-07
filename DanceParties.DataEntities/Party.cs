using System;
using System.Collections.Generic;

namespace DanceParties.DataEntities
{
    public partial class Party : IEntity
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int DanceId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Start { get; set; }

        public virtual Dance Dance { get; set; }
        public virtual Location Location { get; set; }
    }
}
