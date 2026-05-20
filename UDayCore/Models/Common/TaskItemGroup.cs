using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UDayCore.ViewModels.Items;

namespace UDayCore.Models.Common
{
    public class TaskItemGroup : ObservableCollection<TaskItemWrapper>
    {
        public string Title { get; private set; }

        public TaskItemGroup(string title, IEnumerable<TaskItemWrapper> items) : base(items)
        {
            Title = title;
        }
    }
}
