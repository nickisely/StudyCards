using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Data
{
    public interface IStudyCardRepository
    {
        ValueTask<IEnumerable<IStudyCard>> GetStudyCardsAsync(long subGroupId);
        ValueTask<int> SaveStudyCardAsync(IStudyCard studyCard);
    }
}
