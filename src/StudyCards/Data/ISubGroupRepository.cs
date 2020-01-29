using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Data
{
    public interface ISubGroupRepository
    {
        ValueTask<ISubGroup> GetSubGroupAsync(long id, IncludeLevel includeLevel);
    }
}
