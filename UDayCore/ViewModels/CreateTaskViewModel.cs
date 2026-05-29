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
        [ObservableProperty] public partial RecurrenceType SelectedRecurrenceType { get; set; } = RecurrenceType.None;
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
            DateTime? availableFrom = AvailableFrom;
            DateTime? dueDate = DueDate;

            if (SelectedScheduleType == TaskScheduleType.TimeBox)
            {
                var range = CalculateTimeBoxRange(SelectedTimeBox);
                availableFrom = range.AvailableFrom;
                dueDate = range.DueDate;
            }

            TaskItem newTask = new TaskItem
            {
                Title = this.Title,
                Description = this.Description ?? string.Empty,
                EstimatedDurationMinutes = this.EstimatedDurationMinutes,
                ScheduleType = SelectedScheduleType,
                AvailableFrom = availableFrom,
                DueDate = dueDate,
                Priority = SelectedPriority,
                EffortLevel = SelectedEffortLevel,
                RecurrenceType = SelectedScheduleType == TaskScheduleType.Recurring ? SelectedRecurrenceType : RecurrenceType.None
            };

            await _taskItemService.SaveTaskItemAsync(newTask);

            await Shell.Current.GoToAsync("//HomePage");
        }

        private (DateTime AvailableFrom, DateTime DueDate) CalculateTimeBoxRange(TimeBoxType timeBoxType)
        {
            var today = DateTime.Today;
            DateTime availableFrom;
            DateTime dueDate;

            switch (timeBoxType)
            {
                case TimeBoxType.ThisWeek:
                    int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
                    availableFrom = today.AddDays(-1 * diff);
                    dueDate = availableFrom.AddDays(6);
                    break;
                case TimeBoxType.NextWeek:
                    int nextDiff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
                    availableFrom = today.AddDays(-1 * nextDiff + 7);
                    dueDate = availableFrom.AddDays(6);
                    break;
                case TimeBoxType.ThisMonth:
                    availableFrom = new DateTime(today.Year, today.Month, 1);
                    dueDate = availableFrom.AddMonths(1).AddDays(-1);
                    break;
                case TimeBoxType.NextMonth:
                    availableFrom = new DateTime(today.Year, today.Month, 1).AddMonths(1);
                    dueDate = availableFrom.AddMonths(1).AddDays(-1);
                    break;
                default:
                    availableFrom = today;
                    dueDate = today;
                    break;
            }

            return (availableFrom, dueDate);
        }
    }
}
