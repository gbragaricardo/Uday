using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UDayCore.Models.Entities;
using UDayCore.Models.Enums;
using UDayCore.Services;
using UDayCore.ViewModels.Items;
using UDayCore.Views;

namespace UDayCore.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TaskItemService _taskItemService;
        public ObservableCollection<TaskItemWrapper> TaskItems { get; set; } = [];

        public HomeViewModel(TaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [RelayCommand]
        private async Task LoadTaskItemsAsync()
        {
            var dbTaskItems = await _taskItemService.GetTaskItemsAsync();

            TaskItems.Clear();

            foreach (var item in dbTaskItems)
                TaskItems.Add(new TaskItemWrapper(item));
        }


        [RelayCommand]
        private async Task OpenCreateTaskPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(CreateTaskPage));
        }

        [RelayCommand]
        private async Task DeleteTaskItemAsync(TaskItemWrapper taskItemWrapper)
        {
            if (taskItemWrapper == null)
                return;

            await _taskItemService.DeleteTaskItemAsync(taskItemWrapper.Task);
            TaskItems.Remove(taskItemWrapper);
        }
    }
}
