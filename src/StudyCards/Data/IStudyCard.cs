using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Data
{
    public interface IStudyCard : IEntity
    {
        string Question { get; set; }
        string Answer { get; set; }
        long SubGroupId { get; set; }
    }
}
