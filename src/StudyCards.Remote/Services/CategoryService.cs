using StudyCards.Data;
using StudyCards.GRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Remote.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly GRPC.CategoryService.CategoryServiceClient client;
        public CategoryService(GRPC.CategoryService.CategoryServiceClient client)
        {
            this.client = client;
        }

        public async ValueTask<IEnumerable<ICategory>> GetCategoriesAsync(IncludeLevel includeLevel)
        {
            var response = await this.client.GetCategoriesAsync(new GetCategoriesRequest() { IncludeLevel = (int)includeLevel });

            return response.Categories.ToList().AsReadOnly();            
        }

        public async ValueTask<ICategory> GetCategoryAsync(long id, IncludeLevel includeLevel)
        {
           var response = await this.client.GetCategoryAsync(new GetCategoryRequest() { Id = id, IncludeLevel = (int)includeLevel });

            return response.Category;            
        }

        public async ValueTask<int> SaveCategoryAsync(ICategory category)
        {
            var response = await this.client.SaveCategoryAsync(new SaveCategoryRequest() { Category = category.ToGRPCModel() });

            return response.Saved ? 1 : 0;               
        }
    }
}
