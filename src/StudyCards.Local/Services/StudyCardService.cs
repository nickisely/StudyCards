using StudyCards.Data;
using StudyCards.Local.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Services
{
    public class StudyCardService : IStudyCardService
    {
        private readonly IStudyCardRepository studyCardRepository;
        public StudyCardService(IStudyCardRepository studyCardRepository)
        {
            this.studyCardRepository = studyCardRepository;
        }

        public ValueTask<IEnumerable<IStudyCard>> GetStudyCardsAsync(long subGroupId) =>
            this.studyCardRepository.GetStudyCardsAsync(subGroupId);

        public ValueTask<int> SaveStudyCardAsync(IStudyCard studyCard) => this.studyCardRepository.SaveStudyCardAsync(studyCard);
    }
}
