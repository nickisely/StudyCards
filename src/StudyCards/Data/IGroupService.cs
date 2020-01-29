using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Data
{
    public interface IGroupService
    {
        ValueTask<IGroup> GetGroupAsync(long id, IncludeLevel includeLevel);
        ValueTask<IEnumerable<IGroup>> GetGroupsAsync(IncludeLevel includeLevel);
    }
}
