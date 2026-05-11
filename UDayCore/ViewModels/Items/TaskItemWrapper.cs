using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Entities;

namespace UDayCore.ViewModels.Items
{
    public partial class TaskItemWrapper : ObservableObject
    {
        public TaskItem Task { get; }

        [ObservableProperty] public partial bool IsAwaitingFeedback { get; set; }
        [ObservableProperty] public partial bool IsCheckBoxChecked { get; set; }

        public TaskItemWrapper(TaskItem task)
        {
            Task = task;
        }
    }
}
