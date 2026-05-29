using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UDayCore.Models.Entities;
using UDayCore.Models.Enums;
using UDayCore.Services;

namespace UDayCore.ViewModels
{
    public partial class CreateTaskViewModel : ObservableObject
    {
        private readonly TaskItemService _taskItemService;

        public List<TaskScheduleType> ScheduleOptions { get; } = Enum.GetValues<TaskScheduleType>().ToList();
        public List<TimeBoxType> TimeBoxOptions { get; } = Enum.GetValues<TimeBoxType>().ToList();

        [ObservableProperty] public partial string Title { get; set; }
        [ObservableProperty] public partial string? Description { get; set; }
        [ObservableProperty] public partial int EstimatedDurationMinutes { get; set; } = 15;
        [ObservableProperty] public partial DateTime? AvailableFrom { get; set; }
        [ObservableProperty] public partial DateTime? DueDate { get; set; }
        [ObservableProperty] public partial EffortLevel SelectedEffortLevel { get; set; } = EffortLevel.Medium;
        [ObservableProperty] public partial PriorityLevel SelectedPriority { get; set; } = PriorityLevel.Medium;
        [ObservableProperty] public partial RecurrenceType SelectedRecurrenceType { get; set; } = RecurrenceType.Weekly;
        [ObservableProperty] public partial TaskScheduleType SelectedScheduleType { get; set; } = TaskScheduleType.SpecificDate;
        [ObservableProperty] public partial TimeBoxType SelectedTimeBox { get; set; } = TimeBoxType.ThisWeek;

        public CreateTaskViewModel(TaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

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

        [RelayCommand]
        private async Task CreateTaskItemAsync()
        {
            TaskItem newTask = new TaskItem
            {
                Title = this.Title,
                Description = this.Description ?? string.Empty,
                EstimatedDurationMinutes = this.EstimatedDurationMinutes,
                ScheduleType = SelectedScheduleType,
                AvailableFrom = this.AvailableFrom ?? null,
                DueDate = this.DueDate ?? null,
                Priority = SelectedPriority,
                EffortLevel = SelectedEffortLevel

            };

            await _taskItemService.SaveTaskItemAsync(newTask);

            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}
