using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StudyCards.Models
{
    public class CategoryModel : ICategory
    {
        private ReadOnlyCollection<IGroup> groups;

        public CategoryModel(IEnumerable<IGroup>? groups)
        {
            this.Groups = groups != null ? groups.ToList().AsReadOnly() : new List<IGroup>().AsReadOnly();
        }


        public string Name { get; set; }

        public IEnumerable<IGroup> Groups { get; }

        public long Id { get; set; }
    }
}
