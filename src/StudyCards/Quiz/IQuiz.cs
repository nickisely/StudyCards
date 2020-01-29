using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Quiz
{
    public interface IQuiz
    {
        IStudyCard? CurrentCard { get; }
        IStudyCard? PreviousCard();
        IStudyCard? NextCard();
        void Reset();
    }
}
