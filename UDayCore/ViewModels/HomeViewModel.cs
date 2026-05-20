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
        [ObservableProperty] public partial double ProgressRatio { get; set; }
        [ObservableProperty] public partial double ProgressPercentage { get; set; }
        [ObservableProperty] public partial string ProgressText { get; set; }

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

            UpdateProgress();
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
            UpdateProgress();
        }

        public void UpdateProgress()
        {
            if (TaskItems == null || !TaskItems.Any())
            {
                ProgressRatio = 0;
                ProgressText = "0 de 0 tarefas concluídas";
                return;
            }

            int total = TaskItems.Count;

            int completed = TaskItems.Count(t => t.IsCompleted);

            ProgressRatio = (double)completed / total;
            ProgressPercentage = Math.Round(ProgressRatio * 100, 0);

            ProgressText = $"{completed} de {total} tarefas concluídas";
        }

        public async Task RefreshTaskStateAsync(TaskItemWrapper wrapper)
        {
            // await _taskService.UpdateTaskItemAsync(wrapper.Task);
            UpdateProgress();
        }
    }
}
