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

    private async void OnCardBackClicked(object sender, EventArgs e)
    {
        // 1. Verifica se quem chamou foi um botão e se o contexto é o nosso Wrapper
        if (sender is Button btn && btn.BindingContext is TaskItemWrapper wrapper)
        {
            // 2. Busca o contêiner visual principal para animar (a Grid principal do card)
            // Como o botão está dentro de um Layout > Grid > Border, subimos a árvore visual
            if (btn.Parent?.Parent?.Parent is VisualElement cardContainer)
            {
                // Animação de saída: Some e encolhe
                await Task.WhenAll(
                    cardContainer.FadeTo(0, 150),
                    cardContainer.ScaleTo(0.95, 150)
                );

                // 3. A MÁGICA ACONTECE AQUI: Muda o estado para revelar a frente
                wrapper.IsAwaitingFeedback = false;
                wrapper.IsCheckBoxChecked = false; 

                // Animação de entrada: Reaparece com efeito de mola
                await Task.WhenAll(
                    cardContainer.ScaleTo(1, 150, Easing.SpringOut),
                    cardContainer.FadeTo(1, 150)
                );
            }
            else
            {
                // Fallback de segurança caso a árvore visual mude no futuro
                wrapper.IsAwaitingFeedback = false;
            }
        }
    }
}