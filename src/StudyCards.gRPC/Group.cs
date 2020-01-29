using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.GRPC
{
    public partial class Group : IGroup
    {
        IEnumerable<ISubGroup> IGroup.SubGroups => this.SubGroups.ToList().AsReadOnly();
    }
}
