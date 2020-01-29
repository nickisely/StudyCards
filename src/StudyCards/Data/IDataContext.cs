using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyCards.Data
{
    public interface IDataContext: IDisposable, IAsyncDisposable
    {
        IQueryable<ICategory> GetCategoryQuery(IncludeLevel includeLevel);
        IQueryable<IGroup> GetGroupQuery(IncludeLevel includeLevel);
        IQueryable<ISubGroup> GetSubGroupQuery(IncludeLevel includeLevel);
        IQueryable<IStudyCard> GetStudyCardQuery();

        ValueTask<EntityEntry<TEntity>> AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;


        //EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        //EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
