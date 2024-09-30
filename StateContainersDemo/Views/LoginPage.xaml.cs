using StateContainersDemo.ViewModels;

namespace StateContainersDemo.Views;

public partial class LoginPage : ContentPage
{
    public LoginViewModel ViewModel { get; } = new LoginViewModel();

    public LoginPage()
	{
		InitializeComponent();
        BindingContext = ViewModel;
    }
}