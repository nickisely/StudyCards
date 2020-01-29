using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Data
{
    public interface ISubGroup : IEntity
    {
        string Name { get; set; }
        long GroupId { get; set; }

        IEnumerable<IStudyCard> StudyCards { get; }
    }
}
