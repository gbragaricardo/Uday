using UDayCore.Models.Entities;
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
        if (e.Value && sender is CheckBox cb && cb.BindingContext is TaskItemWrapper wrapper)
        {

            if (cb.Parent?.Parent is VisualElement cardContainer)
            {
                // PASSO 1: Desaparece e encolhe levemente ao mesmo tempo (150 milissegundos)
                await Task.WhenAll(
                    cardContainer.FadeToAsync(0, 150),
                    cardContainer.ScaleToAsync(0.95, 150)
                );

                // PASSO 2: Muda a propriedade. O XAML vai trocar as camadas instantaneamente
                // (mas o usuário não vai ver o corte seco porque a opacidade está em 0)
                wrapper.IsAwaitingFeedback = true;

                // PASSO 3: Volta ao tamanho normal e reaparece com os botões de feedback
                await Task.WhenAll(
                    cardContainer.ScaleToAsync(1, 150, Easing.SpringOut), // Easing.SpringOut dá um efeito de "mola"
                    cardContainer.FadeToAsync(1, 150)
                );
            }
            else
            {
                // Fallback de segurança: se por algum motivo ele não achar a Grid visual,
                // ele apenas vira o cartão sem animação para não quebrar o app.
                wrapper.IsAwaitingFeedback = true;
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
        if (sender is Button btn && btn.BindingContext is TaskItemWrapper wrapper)
        {
            if (btn.Parent?.Parent?.Parent is VisualElement cardContainer)
            {
                await Task.WhenAll(
                    cardContainer.FadeToAsync(0, 150),
                    cardContainer.ScaleToAsync(0.95, 150)
                );

                wrapper.IsAwaitingFeedback = false;
                wrapper.Task.IsCompleted = true;

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
}