using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Data
{
    public interface IStudyCardService
    {
        ValueTask<int> SaveStudyCardAsync(IStudyCard studyCard);
        ValueTask<IEnumerable<IStudyCard>> GetStudyCardsAsync(long subGroupId);
    }
}
