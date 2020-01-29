using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Data
{
    public interface ICategory : IEntity
    {
        string Name { get; set; }

        IEnumerable<IGroup> Groups { get; }
    }
}
