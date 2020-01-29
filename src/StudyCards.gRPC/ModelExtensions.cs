using Google.Protobuf.Collections;
using StudyCards.Data;
using StudyCards.GRPC;
using StudyCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.GRPC
{
    public static class ModelExtensions
    {

        public static Category ToGRPCModel(this ICategory category)
        {
            var model = new Category()
            {
                Id = category.Id,
                Name = category.Name
            };

            model.Groups.AddRange(category.Groups.ToGRPCModels());

            return model;
        }

        public static IEnumerable<Category> ToGRPCModels(this IEnumerable<ICategory> category) =>
         category.Select(x => x.ToGRPCModel()).ToList().AsReadOnly();

        // Groups
        public static Group ToGRPCModel(this IGroup group)
        {
            var model = new Group()
            {
                Id = group.Id,
                Name = group.Name
            };

            model.SubGroups.AddRange(group.SubGroups.ToGRPCModels());

            return model;
        }

        public static IEnumerable<Group> ToGRPCModels(this IEnumerable<IGroup> group) =>
          group.Select(x => x.ToGRPCModel()).ToList().AsReadOnly();
        
        //SubGroup
        public static SubGroup ToGRPCModel(this ISubGroup subGroup)
        {
            var model = new SubGroup()
            {
                Id = subGroup.Id,
                Name = subGroup.Name
            };

            model.StudyCards.AddRange(subGroup.StudyCards.ToGRPCModels());

            return model;
        }

        public static IEnumerable<SubGroup> ToGRPCModels(this IEnumerable<ISubGroup> subGroups) =>
            subGroups.Select(x => x.ToGRPCModel()).ToList().AsReadOnly();
        
        // Study Cards
        public static StudyCard ToGRPCModel(this IStudyCard studyCard)
        {
            return new StudyCard()
            {
                Id = studyCard.Id,
                Question = studyCard.Question,
                Answer = studyCard.Answer,
                SubGroupId = studyCard.SubGroupId
            };
        }

        public static IEnumerable<StudyCard> ToGRPCModels(this IEnumerable<IStudyCard> studyCards) =>
            studyCards.Select(x => x.ToGRPCModel()).ToList().AsReadOnly();
    }
}
