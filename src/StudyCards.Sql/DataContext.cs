using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudyCards.Data;
using StudyCards.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCards.Sql
{
    public class DataContext : StudyCardsContext, IDataContext
    {
        public IQueryable<ICategory> GetCategoryQuery(IncludeLevel includeLevel)
        {
            if (includeLevel <= IncludeLevel.Category)
                return this.Set<Category>();

            if (includeLevel == IncludeLevel.Group)
                return this.GetCategoryIncludeGroupQuery();

            if (includeLevel == IncludeLevel.SubGroup)            
                return this.GetCategoryIncludeSubGroupQuery();
 
            return this.GetCategoryAllQuery();
        }

        public IQueryable<IGroup> GetGroupQuery(IncludeLevel includeLevel)
        {
            if (includeLevel <= IncludeLevel.Group)
                return this.Set<Group>();

            if (includeLevel == IncludeLevel.SubGroup)
                return this.GetGroupIncludeSubGroupQuery();

            return this.GetGroupAllQuery();
        }

        public IQueryable<ISubGroup> GetSubGroupQuery(IncludeLevel includeLevel)
        {
            if (includeLevel <= IncludeLevel.SubGroup)
                return this.Set<SubGroup>();
            
            return this.GetSubGroupAllQuery();
        }

        public IQueryable<IStudyCard> GetStudyCardQuery() => this.Set<StudyCard>();

        public async ValueTask<EntityEntry<TEntity>> AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var dataEntity = (TEntity)GetEntity(entity);
            
            if (dataEntity.Id <= 0)
                return await this.AddAsync(dataEntity).ConfigureAwait(false);

            return this.Update(dataEntity);
        }

        private IEntity GetEntity(IEntity entity)
        {
            if (entity is ICategory category)
                return GetCategoryEntity(category);

            if (entity is IGroup group)
                return GetGroupEntity(group);

            if (entity is ISubGroup subGroup)
                return GetSubGroupEntity(subGroup);

            if (entity is IStudyCard studyCard)
                return GetStudyCardEntity(studyCard);

            throw new Exception("Uknown entity type");
        }

        private ICategory GetCategoryEntity(ICategory category)
        {
            if (category is Category)
                return category;

            return new Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        private IGroup GetGroupEntity(IGroup group)
        {
            if (group is Group)
                return group;

            return new Group()
            {
                Id = group.Id,
                Name = group.Name,
                CategoryId = group.CategoryId
            };
        }

        private ISubGroup GetSubGroupEntity(ISubGroup subGroup)
        {
            if (subGroup is SubGroup)
                return subGroup;

            return new SubGroup()
            {
                Id = subGroup.Id,
                Name = subGroup.Name,
                GroupId = subGroup.GroupId
            };
        }

        private IStudyCard GetStudyCardEntity(IStudyCard studyCard)
        {
            if (studyCard is StudyCard)
                return studyCard;

            return new StudyCard()
            {
                Id = studyCard.Id,
                Question = studyCard.Question,
                Answer = studyCard.Answer,
                SubGroupId = studyCard.SubGroupId
            };
        }

        private IQueryable<Category> GetCategoryAllQuery() => this.Set<Category>().Include(x => x.Group).ThenInclude(x => x.SubGroup).ThenInclude(x => x.StudyCard);

        private IQueryable<Category> GetCategoryIncludeGroupQuery() => this.Set<Category>().Include(x => x.Group);

        private IQueryable<Category> GetCategoryIncludeSubGroupQuery() => this.Set<Category>().Include(x => x.Group).ThenInclude(x => x.SubGroup);

        private IQueryable<Group> GetGroupAllQuery() => this.Set<Group>().Include(x => x.SubGroup).ThenInclude(x => x.StudyCard);

        private IQueryable<Group> GetGroupIncludeSubGroupQuery() => this.Set<Group>().Include(x => x.SubGroup);

        private IQueryable<SubGroup> GetSubGroupAllQuery() => this.Set<SubGroup>().Include(x => x.StudyCard);
    }
}
