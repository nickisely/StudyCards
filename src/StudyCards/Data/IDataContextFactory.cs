using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Data
{
    public interface IDataContextFactory
    {
        IDataContext Create();
    }
}
