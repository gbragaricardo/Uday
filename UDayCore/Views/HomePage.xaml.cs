namespace UDayCore.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    // Método que o botão do XAML vai chamar
    private async void OnTestarTelaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTaskPage());
    }
}