using Microsoft.EntityFrameworkCore;
using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Repositories
{
    public class GroupRepository : RepositoryBase, IGroupRepository
    {
        public GroupRepository(IDataContextFactory dataContextFactory) : base(dataContextFactory) { }

        public async ValueTask<IGroup> GetGroupAsync(long id, IncludeLevel includeLevel)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), $"{nameof(id)} must be greater than 0");

            await using (var context = this.dataContextFactory.Create())
            {
                return await context
                    .GetGroupQuery(includeLevel)
                    .FirstOrDefaultAsync(x => x.Id == id)
                    .ConfigureAwait(false);
            }
        }

        public async ValueTask<IEnumerable<IGroup>> GetGroupsAsync(IncludeLevel includeLevel)
        {
            await using (var context = this.dataContextFactory.Create())
            {
                return (await context
                    .GetGroupQuery(includeLevel)
                    .ToListAsync()
                    .ConfigureAwait(false))
                    .AsReadOnly();
            }
        }
    }
}
