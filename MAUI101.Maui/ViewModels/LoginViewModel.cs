using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI101.Maui.Exceptions;
using MAUI101.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.ViewModels
{
    public partial class LoginViewModel : ObservableObject
	{
		private readonly UserService _userService;
		private const string RegisterErrorTitle = "Problem registering user";
		private const string LoginErrorTitle = "Problem on login";

		public LoginViewModel(UserService userService)
		{
			_userService = userService;
		}

		[ObservableProperty]
		string username;

		[ObservableProperty]
		string password;

		[RelayCommand]
		async void Login()
		{
			try
			{
				await _userService.Login(username, password);
			}
			catch (LoginFailedException ex)
			{
				// Probably a better way to handle displaying this message, but I just took the easiest approach.
				await DisplayErrorMessage(ex, LoginErrorTitle);
			}
			catch (LoginValidationException ex)
			{
				await DisplayErrorMessage(ex, LoginErrorTitle);
			}
		}

		[RelayCommand]
		async void Register()
		{
			try
			{
				await _userService.Register(username, password);
			}
			catch (UsernameTakenException ex)
			{
				// Probably a better way to handle displaying this message, but I just took the easiest approach.
				await DisplayErrorMessage(ex, RegisterErrorTitle);
			}
			catch (LoginValidationException ex)
			{
				await DisplayErrorMessage(ex, RegisterErrorTitle);
			}
			catch (Exception ex)
			{
				await DisplayErrorMessage(ex, RegisterErrorTitle);
			}
		}

		private async Task DisplayErrorMessage(Exception ex, string title)
		{
			await Shell.Current.DisplayAlert(title, ex.Message, "OK");
		}
	}
}