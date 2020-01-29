using StudyCards.Data;
using StudyCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace StudyCards.MVVM
{
    public class AddStudyCardViewModel : ViewModelBase
    {
        private IEnumerable<ICategory>? categories;

        public IEnumerable<ICategory>? Categories
        {
            get => this.categories;
            set => this.SetValue(ref this.categories, value);
        }

        private IEnumerable<IGroup>? groups;

        public IEnumerable<IGroup>? Groups
        {
            get => this.groups;
            set => this.SetValue(ref this.groups, value);
        }

        private IEnumerable<ISubGroup>? subGroups;

        public IEnumerable<ISubGroup>? SubGroups
        {
            get => this.subGroups;
            set => this.SetValue(ref this.subGroups, value);
        }

        private ICategory? selectedCategory;

        public ICategory? SelectedCategory
        {
            get => this.selectedCategory;
            set
            {
                if (this.SetValue(ref this.selectedCategory, value))
                    this.OnSelectedCategoryChanged();
            }
        }

        private IGroup? selectedGroup;

        public IGroup? SelectedGroup
        {
            get => this.selectedGroup;
            set
            {
                if (this.SetValue(ref this.selectedGroup, value))
                    this.OnSelectedGroupChanged();
            }
        }

        private ISubGroup? selectedSubGroup;

        public ISubGroup? SelectedSubGroup
        {
            get => this.selectedSubGroup;
            set => this.SetValue(ref this.selectedSubGroup, value);
        }

        private string? question;

        public string? Question
        {
            get => this.question;
            set => this.SetValue(ref this.question, value);
        }

        private string? answer;

        public string? Answer
        {
            get => this.answer;
            set => this.SetValue(ref this.answer, value);
        }

        public ICommand SaveCommand => new ActionCommand(this.OnSave);

        private readonly ICategoryService categoryService;
        private readonly IGroupService groupService;
        private readonly IStudyCardService studyCardService;

        public AddStudyCardViewModel(ICategoryService categoryService, IGroupService groupService, IStudyCardService studyCardService): base()
        {
            this.categoryService = categoryService;
            this.groupService = groupService;
            this.studyCardService = studyCardService;

            this.OnRefresh();
        }

        private async void OnRefresh()
        {
            this.Categories = await this.categoryService.GetCategoriesAsync(IncludeLevel.None).ConfigureAwait(false);
        }

        private async void OnSelectedCategoryChanged()
        {
            if (this.SelectedCategory == null)
                return;

            var category = await this.categoryService.GetCategoryAsync(this.SelectedCategory.Id, IncludeLevel.Group).ConfigureAwait(false);
            this.Groups = category.Groups;
        }

        private async void OnSelectedGroupChanged()
        {
            if (this.SelectedGroup == null)
                return;

            var group = await this.groupService.GetGroupAsync(this.SelectedGroup.Id, IncludeLevel.SubGroup).ConfigureAwait(false);
            this.SubGroups = group.SubGroups;
        }

        private async void OnSave()
        {
            if (this.SelectedSubGroup == null ||
                string.IsNullOrWhiteSpace(this.Question) ||
                string.IsNullOrWhiteSpace(this.Answer))
            {
                return;
            }

            var studyCard = new StudyCardModel()
            {
                Question = this.Question!,
                Answer = this.Answer!,
                SubGroupId = this.SelectedSubGroup.Id
            };

            await this.studyCardService.SaveStudyCardAsync(studyCard).ConfigureAwait(false);

            this.Question = null;
            this.Answer = null;
        }
    }
}
