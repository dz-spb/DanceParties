using System;
using System.Collections.Generic;

namespace DanceParties.Data.Models
{
    public partial class Dance
    {
        public Dance()
        {
            Party = new HashSet<Party>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Party> Party { get; set; }
    }
}
