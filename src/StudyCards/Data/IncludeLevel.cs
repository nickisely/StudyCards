using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Data
{
    public enum IncludeLevel
    {
        None = 0,
        Category = 2,
        Group = 4,
        SubGroup = 8,
        StudyCard = 16,
        All = 32768,
    }
}
