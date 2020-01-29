using StudyCards.Data;
using StudyCards.Local.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Local.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public ValueTask<IEnumerable<ICategory>> GetCategoriesAsync(IncludeLevel includeLevel) =>
            this.categoryRepository.GetCategoriesAsync(includeLevel);

        public ValueTask<ICategory> GetCategoryAsync(long id, IncludeLevel includeLevel) =>
            this.categoryRepository.GetCategoryAsync(id, includeLevel);

        public ValueTask<int> SaveCategoryAsync(ICategory category) =>
            this.categoryRepository.SaveCategoryAsync(category);
    }
}
