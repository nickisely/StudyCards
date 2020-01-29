using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Quiz
{
    public interface IQuizFactory
    {
        IQuiz Create(IEnumerable<IStudyCard> studyCards);
    }
}
