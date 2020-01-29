using System;
using System.Collections.Generic;

namespace StudyCards.Sql.Entities
{
    public partial class StudyCard
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public long SubGroupId { get; set; }

        public virtual SubGroup SubGroup { get; set; }
    }
}
