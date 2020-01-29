using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.Quiz
{
    public class RandomizedQuiz : IQuiz
    {
        private IStudyCard[] cards;
        private int index = 0;
        private readonly Random random;

        public RandomizedQuiz(IEnumerable<IStudyCard> studyCards)
        {
            this.random = new Random();

            if (studyCards.Any())
                this.cards = this.RandomizeCards(studyCards);
            else
                this.cards = new IStudyCard[0];
        }

        public IStudyCard? CurrentCard => this.cards.Length == 0 ? null : this.cards[this.index];

        public IStudyCard? NextCard()
        {
            if (this.cards.Length == 0)
                return null;

            this.index++;

            if (this.index >= this.cards.Length)
                this.index = this.cards.Length - 1;

            return this.CurrentCard;
        }

        public IStudyCard? PreviousCard()
        {
            if (this.cards.Length == 0)
                return null;

            this.index--;

            if (this.index < 0)
                this.index = 0;

            return this.CurrentCard;
        }

        public void Reset() => this.cards = this.RandomizeCards(this.cards);
        
        private IStudyCard[] RandomizeCards(IEnumerable<IStudyCard> studyCards) =>
            studyCards.OrderBy(_ => this.random.Next(0, studyCards.Count())).ToArray();

    }
}
