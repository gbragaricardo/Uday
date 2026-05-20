using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UDayCore.Models.Common;
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
        public ObservableCollection<TaskItemGroup> GroupedTasks { get; set; } = new();
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

            var wrappedTasks = dbTaskItems.Select(t => new TaskItemWrapper(t)).ToList();
            

            var groupedData = wrappedTasks
                .GroupBy(wt => wt.DayPeriod)
                .Select(group => new TaskItemGroup(group.Key.ToString(), group.ToList()))
                .ToList();

            GroupedTasks.Clear();

            foreach (var group in groupedData)
                GroupedTasks.Add(group);

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
            if (taskItemWrapper == null) return;

            await _taskItemService.DeleteTaskItemAsync(taskItemWrapper.Task);

            var targetGroup = GroupedTasks.FirstOrDefault(g => g.Contains(taskItemWrapper));

            if (targetGroup != null)
            {
                targetGroup.Remove(taskItemWrapper);

                if (targetGroup.Count == 0)
                    GroupedTasks.Remove(targetGroup);
                
            }

            UpdateProgress();
        }

        public void UpdateProgress()
        {
            if (GroupedTasks == null || !GroupedTasks.Any())
            {
                ProgressRatio = 0;
                ProgressText = "0 de 0 tarefas concluídas";
                return;
            }

            var allWrappedTasks = GroupedTasks.SelectMany(group => group).ToList();
            if (allWrappedTasks.Any() == false)
            {
                ProgressPercentage = 0;
                ProgressText = "0 de 0 tarefas concluídas";
                return;
            }

            int totalTasks = allWrappedTasks.Count;
            int completedTasks = allWrappedTasks.Count(t => t.IsCompleted);

            ProgressRatio = (double)completedTasks / totalTasks;
            ProgressPercentage = Math.Round(ProgressRatio * 100, 0);

            ProgressText = $"{completedTasks} de {totalTasks} tarefas concluídas";
        }

        public async Task RefreshTaskStateAsync(TaskItemWrapper wrapper)
        {
            // await _taskService.UpdateTaskItemAsync(wrapper.Task);
            UpdateProgress();
        }
    }
}
