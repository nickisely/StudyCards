using StudyCards.Data;
using StudyCards.GRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Remote.Services
{
    public class StudyCardService : IStudyCardService
    {
        private readonly GRPC.StudyCardService.StudyCardServiceClient client;
        public StudyCardService(GRPC.StudyCardService.StudyCardServiceClient client)
        {
            this.client = client;
        }

        public async ValueTask<IEnumerable<IStudyCard>> GetStudyCardsAsync(long subGroupId)
        {
            var response = await this.client.GetStudyCardsAsync(new GetStudyCardsRequest() { SubGroupId = subGroupId });

            return response.Cards.ToList().AsReadOnly();
        }

        public async ValueTask<int> SaveStudyCardAsync(IStudyCard studyCard)
        {
            var response = await this.client.SaveStudyCardAsync(new SaveStudyCardRequest() { Card = studyCard.ToGRPCModel() });

            return response.Saved ? 1 : 0;
        }
    }
}
