using Google.Protobuf.Collections;
using Grpc.Core;
using StudyCards.Data;
using StudyCards.GRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Server.Services
{
    public class CategoryService : StudyCards.GRPC.CategoryService.CategoryServiceBase
    {
        private readonly ICategoryService categoryService;
        public CategoryService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public override async Task<GetCategoriesResponse> GetCategories(GetCategoriesRequest request, ServerCallContext context)
        {
            var categories = await this.categoryService.GetCategoriesAsync((IncludeLevel)request.IncludeLevel).ConfigureAwait(false);

            var response = new GetCategoriesResponse();
            response.Categories.AddRange(categories.ToGRPCModels());
            return response;
        }

        public override  async Task<GetCategoryResponse> GetCategory(GetCategoryRequest request, ServerCallContext context)
        {
            var category = await this.categoryService.GetCategoryAsync(request.Id, (IncludeLevel)request.IncludeLevel).ConfigureAwait(false);

            return new GetCategoryResponse()
            {
                Category = category.ToGRPCModel()
            };
        }

        public override async Task<SaveCategoryResponse> SaveCategory(SaveCategoryRequest request, ServerCallContext context)
        {
            var result = await this.categoryService.SaveCategoryAsync(request.Category).ConfigureAwait(false);

            return new SaveCategoryResponse()
            {
                Saved = result > 0
            };
        }
    }
}
