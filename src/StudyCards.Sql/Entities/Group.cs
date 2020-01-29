using System;
using System.Collections.Generic;

namespace StudyCards.Sql.Entities
{
    public partial class Group
    {
        public Group()
        {
            SubGroup = new HashSet<SubGroup>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<SubGroup> SubGroup { get; set; }
    }
}
