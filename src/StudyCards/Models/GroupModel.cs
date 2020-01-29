using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCards.Models
{
    public class GroupModel : IGroup
    {
        public GroupModel(IEnumerable<ISubGroup>? subGroups)
        {
            this.SubGroups = subGroups != null ? subGroups.ToList().AsReadOnly() : new List<ISubGroup>().AsReadOnly();
        }

        public string Name { get; set; } = string.Empty;
        public long CategoryId { get; set; }

        public IEnumerable<ISubGroup> SubGroups { get; }

        public long Id { get; set; }
    }
}
