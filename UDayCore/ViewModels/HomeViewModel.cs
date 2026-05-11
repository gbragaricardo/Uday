using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UDayCore.Models.Entities;
using UDayCore.Models.Enums;
using UDayCore.Services;
using UDayCore.Views;

namespace UDayCore.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TaskItemService _taskItemService;
        public ObservableCollection<TaskItem> MockTasks { get; set; } = [];
        public ObservableCollection<TaskItem> TaskItems { get; set; } = [];

        public HomeViewModel(TaskItemService taskItemService)
        {
            MockTasks.Add(new TaskItem
            {
                Id = 1,
                Title = "Validar requisitos do Plugin Revit",
                EstimatedDurationMinutes = 90,
                DueDate = DateTime.Now,
                Priority = PriorityLevel.High,
                EffortLevel = EffortLevel.Heavy
            });

            MockTasks.Add(new TaskItem
            {
                Id = 2,
                Title = "Finalizar tela de audiências Angular",
                EstimatedDurationMinutes = 120,
                DueDate = DateTime.Now,
                Priority = PriorityLevel.Medium,
                EffortLevel = EffortLevel.Medium
            });
            
            _taskItemService = taskItemService;
        }

        [RelayCommand]
        private async Task LoadTaskItemsAsync()
        {
            var dbTaskItems = await _taskItemService.GetTaskItemsAsync();

            TaskItems.Clear();

            foreach (var item in dbTaskItems)
                TaskItems.Add(item);
        }

        [RelayCommand]
        private async Task OpenCreateTaskPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(CreateTaskPage));
        }
    }
}
