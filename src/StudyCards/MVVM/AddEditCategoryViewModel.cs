using StudyCards.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StudyCards.MVVM
{
    public class AddEditCategoryViewModel : ViewModelBase
    {
        private string? newName;

        public string? NewName
        {
            get => this.newName;
            set => this.SetValue(ref this.newName, value);
        }

        public ICommand AddCommand => new ActionCommand(this.OnAdd);

        private readonly ICategoryService categoryService;

        private void OnAdd()
        {
            if (string.IsNullOrWhiteSpace(this.NewName))
                return;

            //var category = new Category()
            //{
            //    Name = this.NewName
            //};

        }
    }
}
