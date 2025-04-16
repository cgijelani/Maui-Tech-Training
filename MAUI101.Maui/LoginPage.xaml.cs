using MAUI101.Maui.ViewModels;

namespace MAUI101.Maui;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}