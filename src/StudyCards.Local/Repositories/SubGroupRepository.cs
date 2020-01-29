using Microsoft.EntityFrameworkCore;
using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Repositories
{
    public class SubGroupRepository : RepositoryBase, ISubGroupRepository
    {
        public SubGroupRepository(IDataContextFactory dataContextFactory) : base(dataContextFactory) { }

        public async ValueTask<ISubGroup> GetSubGroupAsync(long id, IncludeLevel includeLevel)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), $"{nameof(id)} must be greater than 0");

            await using (var context = this.dataContextFactory.Create())
            {
                return await context
                    .GetSubGroupQuery(includeLevel)
                    .FirstOrDefaultAsync(x => x.Id == id)
                    .ConfigureAwait(false);
            }
        }
    }
}
