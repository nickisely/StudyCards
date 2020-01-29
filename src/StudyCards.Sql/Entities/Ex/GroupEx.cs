using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.Sql.Entities
{
    public partial class Group : IGroup
    {
        public IEnumerable<ISubGroup> SubGroups => this.SubGroup.Select(x => (ISubGroup)x).ToList().AsReadOnly();
    }
}
