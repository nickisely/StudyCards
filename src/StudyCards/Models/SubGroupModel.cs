using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.Models
{
    public class SubGroupModel : ISubGroup
    {
        public SubGroupModel(IEnumerable<IStudyCard>? studyCards)
        {
            this.StudyCards = studyCards != null ? studyCards.ToList().AsReadOnly() : new List<IStudyCard>().AsReadOnly();
        }

        public string Name { get; set; } = string.Empty;
        public long GroupId { get; set; }

        public IEnumerable<IStudyCard> StudyCards { get; }

        public long Id { get; set; }
    }
}
