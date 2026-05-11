using UDayCore.ViewModels;

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
}