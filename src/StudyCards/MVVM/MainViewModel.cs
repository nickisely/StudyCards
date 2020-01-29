using StudyCards.Data;
using StudyCards.Quiz;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.MVVM
{
    public class MainViewModel : ViewModelBase
    {
        private QuizControlViewModel quizControlVM;
        public QuizControlViewModel QuizControlVM
        {
            get => this.quizControlVM;
            set => this.SetValue(ref this.quizControlVM, value);
        }

        private AddStudyCardViewModel addStudyCardVM;
        public AddStudyCardViewModel AddStudyCardVM
        {
            get => this.addStudyCardVM;
            set => this.SetValue(ref this.addStudyCardVM, value);

        }

        public MainViewModel(ICategoryService categoryService, IGroupService groupService, IStudyCardService studyCardService, IQuizFactory quizFactory) :  base()
        {
            this.quizControlVM = new QuizControlViewModel(categoryService, groupService, studyCardService, quizFactory);
            this.addStudyCardVM = new AddStudyCardViewModel(categoryService, groupService, studyCardService);
        }

    }
}
