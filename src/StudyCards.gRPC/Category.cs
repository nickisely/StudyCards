using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.GRPC
{
    public partial class Category : ICategory
    {
        IEnumerable<IGroup> ICategory.Groups => this.Groups.ToList().AsReadOnly();
    }
}
