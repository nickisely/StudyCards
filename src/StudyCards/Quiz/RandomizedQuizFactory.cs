using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Quiz
{
    public class RandomizedQuizFactory : IQuizFactory
    {
        public IQuiz Create(IEnumerable<IStudyCard> studyCards)
        {
            return new RandomizedQuiz(studyCards);
        }
    }
}
