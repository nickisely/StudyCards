using Grpc.Core;
using StudyCards.Data;
using StudyCards.GRPC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Server.Services
{
    public class GroupService : StudyCards.GRPC.GroupService.GroupServiceBase
    {
        private readonly IGroupService groupService;
        public GroupService(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public override async Task<GetGroupResponse> GetGroup(GetGroupRequest request, ServerCallContext context)
        {
            var group = await this.groupService.GetGroupAsync(request.Id, (IncludeLevel)request.IncludeLevel).ConfigureAwait(false);

            return new GetGroupResponse()
            {
                Group = group.ToGRPCModel()
            };            
        }

        public override async Task<GetGroupsResponse> GetGroups(GetGroupsRequest request, ServerCallContext context)
        {
            var groups = await this.groupService.GetGroupsAsync((IncludeLevel)request.IncludeLevel).ConfigureAwait(false);

            var response = new GetGroupsResponse();
            response.Groups.AddRange(groups.ToGRPCModels());
            return response;
        }
    }
}
