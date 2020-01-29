using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Data
{
    public interface IGroup : IEntity
    {
        string Name { get; set; }
        long CategoryId { get; set; }

        IEnumerable<ISubGroup> SubGroups { get; }
    }
}
