using System;
using System.Collections.Generic;

namespace StudyCards.Sql.Entities
{
    public partial class SubGroup
    {
        public SubGroup()
        {
            StudyCard = new HashSet<StudyCard>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<StudyCard> StudyCard { get; set; }
    }
}
