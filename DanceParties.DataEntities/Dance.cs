using System;
using System.Collections.Generic;

namespace DanceParties.DataEntities
{
    public partial class Dance : IEntity
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
