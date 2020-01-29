using StudyCards.Data;
using StudyCards.Local.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public ValueTask<IGroup> GetGroupAsync(long id, IncludeLevel includeLevel) =>
            this.groupRepository.GetGroupAsync(id, includeLevel);

        public ValueTask<IEnumerable<IGroup>> GetGroupsAsync(IncludeLevel includeLevel) =>
            this.groupRepository.GetGroupsAsync(includeLevel);
    }
}
