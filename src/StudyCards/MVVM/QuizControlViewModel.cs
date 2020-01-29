using StudyCards.Data;
using StudyCards.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace StudyCards.MVVM
{
    public class QuizControlViewModel : ViewModelBase
    {
        private string? sideName;

        public string? SideName
        {
            get => this.sideName;
            set => this.SetValue(ref this.sideName, value);
        }

        private string? sideText;

        public string? SideText
        {
            get => this.sideText;
            set => this.SetValue(ref this.sideText, value);
        }

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
            set
            {
                if (this.SetValue(ref this.selectedSubGroup, value))
                    this.OnSelectedSubGroupChanged();
            }
        }

        public ICommand PrevCommand => new ActionCommand(this.OnPrevCard);
        public ICommand NextCommand => new ActionCommand(this.OnNextCard);
        public ICommand FlipCommand => new ActionCommand(this.OnFlip);

        private readonly ICategoryService categoryService;
        private readonly IGroupService groupService;
        private readonly IStudyCardService studyCardService;
        private readonly IQuizFactory quizFactory;
        private IQuiz? currentQuiz;
        private bool isQuestion;

        public QuizControlViewModel(ICategoryService categoryService, IGroupService groupService, IStudyCardService studyCardService, IQuizFactory quizFactory) : base()
        {
            this.categoryService = categoryService;
            this.groupService = groupService;
            this.studyCardService = studyCardService;
            this.quizFactory = quizFactory;

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
            this.SubGroups = null;
        }

        private async void OnSelectedGroupChanged()
        {
            if (this.SelectedGroup == null)
                return;

            var group = await this.groupService.GetGroupAsync(this.SelectedGroup.Id, IncludeLevel.SubGroup).ConfigureAwait(false);
            this.SubGroups = group.SubGroups;
        }

        private async void OnSelectedSubGroupChanged()
        {
            if (this.SelectedSubGroup == null)
                return;

            var studyCards = await this.studyCardService.GetStudyCardsAsync(this.SelectedSubGroup.Id).ConfigureAwait(false);
            this.currentQuiz = this.quizFactory.Create(studyCards);
            this.SetQuestion();
        }

        private void OnFlip()
        {
            if (this.isQuestion)
                this.SetAnswer();
            else
                this.SetQuestion();
        }

        private void OnPrevCard()
        {
            this.currentQuiz?.PreviousCard();
            this.SetQuestion();
        }

        private void OnNextCard()
        {
            this.currentQuiz?.NextCard();
            this.SetQuestion();
        }

        private void SetQuestion()
        {
            var studyCard = this.currentQuiz?.CurrentCard;
            this.SideName = "Question";
            this.SideText = studyCard?.Question;
            this.isQuestion = true;
        }

        private void SetAnswer()
        {
            var studyCard = this.currentQuiz?.CurrentCard;
            this.SideName = "Question";
            this.SideText = studyCard?.Answer;
            this.isQuestion = false;
        }
    }
}
