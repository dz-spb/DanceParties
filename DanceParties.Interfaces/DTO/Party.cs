using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.DTO
{
    public class Party
    {
        public int Id { get; set; }

        public string Dance { get; set; }

        public string Name { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}
