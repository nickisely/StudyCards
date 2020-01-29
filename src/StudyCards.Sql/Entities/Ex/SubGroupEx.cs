using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.Sql.Entities
{
    public partial class SubGroup : ISubGroup
    {
        public IEnumerable<IStudyCard> StudyCards => this.StudyCard.Select(x => (IStudyCard)x).ToList().AsReadOnly();
    }
}
