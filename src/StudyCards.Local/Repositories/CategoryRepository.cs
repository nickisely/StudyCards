using Microsoft.EntityFrameworkCore;
using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(IDataContextFactory dataContextFactory) : base(dataContextFactory) { }

        public async ValueTask<IEnumerable<ICategory>> GetCategoriesAsync(IncludeLevel includeLevel)
        {
            await using (var context = this.dataContextFactory.Create())
            {
                return (await context.GetCategoryQuery(includeLevel)
                     .ToListAsync()
                     .ConfigureAwait(false))
                     .AsReadOnly();
            }
        }

        public async ValueTask<ICategory> GetCategoryAsync(long id, IncludeLevel includeLevel)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), $"{nameof(id)} must be greater than 0");

            await using (var context = this.dataContextFactory.Create())
            {
                return await context.GetCategoryQuery(includeLevel)
                     .FirstOrDefaultAsync(x => x.Id == id)
                     .ConfigureAwait(false);
            }
        }

        public ValueTask<int> SaveCategoryAsync(ICategory category) => this.SaveAsync(category);
    }
}
