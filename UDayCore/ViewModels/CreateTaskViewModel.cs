using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Enums;

namespace UDayCore.ViewModels
{
    public partial class CreateTaskViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial int Duration { get; set; } = 15;

        [ObservableProperty]
        public partial PriorityLevel SelectedPriority { get; set; } = PriorityLevel.Medium;

        [ObservableProperty]
        public partial EffortLevel SelectedEffortLevel { get; set; } = EffortLevel.Medium;
    }
}
