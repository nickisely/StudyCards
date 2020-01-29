using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IDataContextFactory dataContextFactory;

        public RepositoryBase(IDataContextFactory dataContextFactory)
        {
            this.dataContextFactory = dataContextFactory;
        }

        protected async ValueTask<int> SaveAsync<T>(T entity) where T : class, IEntity
        {
            await using (var context = this.dataContextFactory.Create())
            {
                await context.AddOrUpdateAsync(entity).ConfigureAwait(false);

                return await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }


    }
}
