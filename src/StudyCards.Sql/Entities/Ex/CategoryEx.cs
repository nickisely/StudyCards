using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.Sql.Entities
{
    public partial class Category : ICategory
    {
        public IEnumerable<IGroup> Groups => this.Group.Select(x => (IGroup)x).ToList().AsReadOnly();
    }
}
