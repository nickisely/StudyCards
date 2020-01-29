using Grpc.Core;
using StudyCards.Data;
using StudyCards.GRPC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Server.Services
{
    public class StudyCardService : GRPC.StudyCardService.StudyCardServiceBase
    {
        private readonly IStudyCardService studyCardService;
        public StudyCardService(IStudyCardService studyCardService)
        {
            this.studyCardService = studyCardService;
        }

        public override async Task<GetStudyCardsResponse> GetStudyCards(GetStudyCardsRequest request, ServerCallContext context)
        {
            var cards = await this.studyCardService.GetStudyCardsAsync(request.SubGroupId).ConfigureAwait(false);  
            
            var response = new GetStudyCardsResponse();
            response.Cards.AddRange(cards.ToGRPCModels());
            return response;
        }

        public override async Task<SaveStudyCardResponse> SaveStudyCard(SaveStudyCardRequest request, ServerCallContext context)
        {
            var result = await this.studyCardService.SaveStudyCardAsync(request.Card).ConfigureAwait(false);

            return new SaveStudyCardResponse()
            {
                Saved = result > 0
            };
        }
    }
}
