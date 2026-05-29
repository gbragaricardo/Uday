using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UDayCore.Models.Entities;
using UDayCore.ViewModels.Items;

namespace UDayCore.ViewModels
{
    [QueryProperty(nameof(Task), "Task")]
    public partial class TaskDetailViewModel : ObservableObject
    {
        [ObservableProperty] 
        private TaskItem _task;

        [ObservableProperty]
        private TaskItemWrapper _wrappedTask;

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        partial void OnTaskChanged(TaskItem value)
        {
            if (value != null)
            {
                WrappedTask = new TaskItemWrapper(value);
            }
        }
    }
}
