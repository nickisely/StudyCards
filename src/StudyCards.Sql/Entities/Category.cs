using System;
using System.Collections.Generic;

namespace StudyCards.Sql.Entities
{
    public partial class Category
    {
        public Category()
        {
            Group = new HashSet<Group>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Group> Group { get; set; }
    }
}
