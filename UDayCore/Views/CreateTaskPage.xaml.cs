using UDayCore.ViewModels;

namespace UDayCore.Views;

public partial class CreateTaskPage : ContentPage
{
	public CreateTaskPage(CreateTaskViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
	}
}