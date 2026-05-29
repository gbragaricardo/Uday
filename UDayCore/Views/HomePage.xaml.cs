using UDayCore.Models.Entities;
using UDayCore.Models.Enums;
using UDayCore.ViewModels;
using UDayCore.ViewModels.Items;

namespace UDayCore.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is HomeViewModel vm)
        {
            vm.LoadTaskItemsCommand.Execute(null);
        }
    }

    private async void OnTaskCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox cb && cb.BindingContext is TaskItemWrapper wrapper)
        {
            if (e.Value)
            {
                // Se a tarefa já está completa (veio do banco assim), não mostramos o feedback
                if (wrapper.IsCompleted) return;

                if (cb.Parent?.Parent is VisualElement cardContainer)
                {
                    await Task.WhenAll(
                        cardContainer.FadeToAsync(0, 150),
                        cardContainer.ScaleToAsync(0.95, 150)
                    );

                    wrapper.IsAwaitingFeedback = true;

                    await Task.WhenAll(
                        cardContainer.ScaleToAsync(1, 150, Easing.SpringOut),
                        cardContainer.FadeToAsync(1, 150)
                    );
                }
                else
                {
                    wrapper.IsAwaitingFeedback = true;
                }
            }
            else
            {
                wrapper.IsCompleted = false;

                if (BindingContext is HomeViewModel vm)
                    await vm.RefreshTaskStateAsync(wrapper);

                wrapper.IsAwaitingFeedback = false;
            }
        }
    }

    private async void OnTaskBackClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton btn && btn.BindingContext is TaskItemWrapper wrapper)
        {
            if (btn.Parent?.Parent?.Parent is VisualElement cardContainer)
            {
                await Task.WhenAll(
                    cardContainer.FadeToAsync(0, 150),
                    cardContainer.ScaleToAsync(0.95, 150)
                );

                wrapper.IsAwaitingFeedback = false;
                wrapper.IsCheckBoxChecked = false;

                await Task.WhenAll(
                    cardContainer.ScaleToAsync(1, 150, Easing.SpringOut),
                    cardContainer.FadeToAsync(1, 150)
                );
            }
            else
            {
                wrapper.IsAwaitingFeedback = false;
            }
        }
    }

    private async void OnEffortSelected(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is TaskItemWrapper wrapper && btn.CommandParameter is EffortLevel effort)
        {
            if (btn.Parent?.Parent?.Parent is VisualElement cardContainer)
            {
                await Task.WhenAll(
                    cardContainer.FadeToAsync(0, 150),
                    cardContainer.ScaleToAsync(0.95, 150)
                );

                wrapper.Task.EffortLevel = effort;
                wrapper.IsAwaitingFeedback = false;
                wrapper.IsCompleted = true;

                if (BindingContext is HomeViewModel vm)
                    await vm.RefreshTaskStateAsync(wrapper);
                

                await Task.WhenAll(
                    cardContainer.ScaleToAsync(1, 150, Easing.SpringOut),
                    cardContainer.FadeToAsync(1, 150)
                );
            }
            else
            {
                wrapper.Task.EffortLevel = effort;
                wrapper.IsAwaitingFeedback = false;
            }
        }
    }
}