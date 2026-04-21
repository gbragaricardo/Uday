using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Enums;

namespace UDayCore.ViewModels
{
    public partial class CreateTaskViewModel : ObservableObject
    {
        public List<TaskScheduleType> ScheduleOptions { get; } = Enum.GetValues<TaskScheduleType>().ToList();
        public List<TimeBoxType> TimeBoxOptions { get; } = Enum.GetValues<TimeBoxType>().ToList();


        [ObservableProperty]
        public partial TaskScheduleType SelectedScheduleType { get; set; } = TaskScheduleType.None;

        [ObservableProperty]
        public partial int Duration { get; set; } = 15;

        [ObservableProperty]
        public partial RecurrenceType SelectedRecurrenceType { get; set; } = RecurrenceType.None;

        [ObservableProperty]
        public partial TimeBoxType SelectedTimeBox { get; set; } = TimeBoxType.None;

        [ObservableProperty]
        public partial PriorityLevel SelectedPriority { get; set; } = PriorityLevel.Medium;

        [ObservableProperty]
        public partial EffortLevel SelectedEffortLevel { get; set; } = EffortLevel.Medium;


        public bool IsSingleDateVisible => SelectedScheduleType == TaskScheduleType.SpecificDate;
        public bool IsTimeframeVisible => SelectedScheduleType == TaskScheduleType.TimeFrame;
        public bool IsTimeBoxVisible => SelectedScheduleType == TaskScheduleType.TimeBox;
        public bool IsRecurrenceVisisble => SelectedScheduleType == TaskScheduleType.Recurring;


        partial void OnSelectedScheduleTypeChanged(TaskScheduleType value)
        {
            OnPropertyChanged(nameof(IsSingleDateVisible));
            OnPropertyChanged(nameof(IsTimeframeVisible));
            OnPropertyChanged(nameof(IsTimeBoxVisible));
            OnPropertyChanged(nameof(IsRecurrenceVisisble));
        }
    }
}
