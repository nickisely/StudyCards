using Grpc.Core;
using StudyCards.Data;
using StudyCards.Remote.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Remote
{
    public class ServicesManager : IAsyncDisposable
    {
        private readonly Lazy<ICategoryService> lazyCategoryService;
        private readonly Lazy<IGroupService> lazyGroupService;
        private readonly Lazy<IStudyCardService> lazyStudyCardService;

        private readonly Channel channel;
        public ServicesManager(string host, int port)
        {
            this.channel = new Channel($"{host}:{port}", ChannelCredentials.Insecure);
            this.lazyCategoryService = new Lazy<ICategoryService>(() => 
                new CategoryService(new GRPC.CategoryService.CategoryServiceClient(this.channel)));

            this.lazyGroupService = new Lazy<IGroupService>(() =>
                new GroupService(new GRPC.GroupService.GroupServiceClient(this.channel)));

            this.lazyStudyCardService = new Lazy<IStudyCardService>(() =>
                new StudyCardService(new GRPC.StudyCardService.StudyCardServiceClient(this.channel)));
        }

        public ICategoryService CategoryService => this.lazyCategoryService.Value;
        public IGroupService GroupService => this.lazyGroupService.Value;
        public IStudyCardService StudyCardService => this.lazyStudyCardService.Value;

        public async ValueTask DisposeAsync()
        {
            await this.channel.ShutdownAsync().ConfigureAwait(false);
        }
    }
}
