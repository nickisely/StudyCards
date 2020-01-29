using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.GRPC
{
    public partial class SubGroup : ISubGroup
    {
        IEnumerable<IStudyCard> ISubGroup.StudyCards => this.StudyCards.ToList().AsReadOnly();
    }
}
