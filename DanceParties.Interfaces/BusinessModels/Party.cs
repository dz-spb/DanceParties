using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.BusinessModels
{
    public class Party
    {
        public int Id { get; set; }

        public int DanceId { get; set; }

        public string Name { get; set; }      

        public DateTimeOffset Start { get; set; }

        public int LocationId { get; set; }
    }
}
