using StudyCards.Data;
using StudyCards.GRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Remote.Services
{
    public class GroupService : IGroupService
    {
        private readonly GRPC.GroupService.GroupServiceClient client;
        public GroupService(GRPC.GroupService.GroupServiceClient client)
        {
            this.client = client;
        }

        public async ValueTask<IGroup> GetGroupAsync(long id, IncludeLevel includeLevel)
        {
            var response = await this.client.GetGroupAsync(new GetGroupRequest() { Id = id, IncludeLevel = (int)includeLevel });

            return response.Group;
        }

        public async ValueTask<IEnumerable<IGroup>> GetGroupsAsync(IncludeLevel includeLevel)
        {
            var response = await this.client.GetGroupsAsync(new GetGroupsRequest() { IncludeLevel = (int)includeLevel });

            return response.Groups.ToList().AsReadOnly();
        }
    }
}
