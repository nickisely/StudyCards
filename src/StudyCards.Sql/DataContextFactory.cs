using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Sql
{
    public class DataContextFactory : IDataContextFactory
    {
        public IDataContext Create()
        {
            return new DataContext();
        }
    }
}
