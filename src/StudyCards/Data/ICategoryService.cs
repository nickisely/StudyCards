using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Data
{
    public interface ICategoryService
    {
        ValueTask<ICategory> GetCategoryAsync(long id, IncludeLevel includeLevel);
        ValueTask<IEnumerable<ICategory>> GetCategoriesAsync(IncludeLevel includeLevel);
        ValueTask<int> SaveCategoryAsync(ICategory category);
    }
}
