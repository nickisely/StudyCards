using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCards.Models
{
    public class StudyCardModel : IStudyCard
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public long SubGroupId { get; set; }
        public long Id { get; set; }
    }
}
