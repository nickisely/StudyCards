using Microsoft.EntityFrameworkCore;
using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Repositories
{
    public class StudyCardRepository : RepositoryBase, IStudyCardRepository
    {
        public StudyCardRepository(IDataContextFactory dataContextFactory) : base(dataContextFactory) { }

        public async ValueTask<IEnumerable<IStudyCard>> GetStudyCardsAsync(long subGroupId)
        {
            if(subGroupId <= 0)
                throw new ArgumentOutOfRangeException(nameof(subGroupId), $"{nameof(subGroupId)} must be greater than 0");

            await using (var context = this.dataContextFactory.Create())
            {
                return (await context
                    .GetStudyCardQuery()
                    .Where(x => x.SubGroupId == subGroupId)
                    .ToListAsync()
                    .ConfigureAwait(false))
                    .AsReadOnly();
            }
        }

        public ValueTask<int> SaveStudyCardAsync(IStudyCard studyCard) => this.SaveAsync(studyCard);
    }
}
