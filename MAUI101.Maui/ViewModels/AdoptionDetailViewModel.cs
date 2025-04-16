using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI101.Maui.Data_Models;
using MAUI101.Maui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.ViewModels
{
	[QueryProperty("Detail", "detail")]
	public partial class AdoptionDetailViewModel : ObservableValidator
	{
		private LocalDbService _localDbService;
		private UserService _userService;

		public AdoptionDetailViewModel(LocalDbService localDbService, UserService userService)
        {
			_localDbService = localDbService;
			_userService = userService;

			// Set data for State picker.
			states = StateHelper.states;

			var now = DateTime.Now;
			// Set default date to today.
			dateOfBirth = now;
			// Date must be before todays date.
			maxDate = now;
		}

		[ObservableProperty]
		PetFormDetail detail;

		[Required(ErrorMessage = "First name is required.")]
		[MaxLength(12)]
        [ObservableProperty]
		[Display(Name ="First Name")]
        string firstName;

		[MaxLength(12)]
		[ObservableProperty]
		[Display(Name = "Middle Name")]
		string middleName;

		[Required(ErrorMessage = "Last name is required.")]
		[MaxLength(12)]
		[ObservableProperty]
		[Display(Name = "Last Name")]
		string lastName;

		[Required(ErrorMessage = "Date of Birth is required.")]
		[ObservableProperty]
		[Display(Name = "Date of Birth")]
		DateTime dateOfBirth;

		[Required(ErrorMessage = "Street is required.")]
		[MaxLength(20)]
		[ObservableProperty]
		[Display(Name = "Street")]
		string street;

		[Required(ErrorMessage = "City is required.")]
		[MaxLength(20)]
		[ObservableProperty]
		[Display(Name = "City")]
		string city;

		[Required(ErrorMessage = "State is required.")]
		[ObservableProperty]
		[Display(Name = "State")]
		string state;

		[Required(ErrorMessage = "Phone number is required.")]
		[MaxLength(12)]
		[ObservableProperty]
		[Display(Name = "Phone Number")]
		string phoneNumber;

		[Required(ErrorMessage = "Email is required.")]
		[MaxLength(25)]
		[ObservableProperty]
		[Display(Name = "Email")]
		string email;

		[Required(ErrorMessage = "Pet name is required.")]
		[MaxLength(20)]
		[ObservableProperty]
		[Display(Name = "Pet Name")]
		string petName;

		[ObservableProperty]
		DateTime maxDate;

		[ObservableProperty]
		string error;

		[ObservableProperty]
		List<string> states;

		[RelayCommand]
		async void Submit()
		{
			ValidateAllProperties();

			if (HasErrors)
			{
				Error = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
				return;
			}

			var formInfo = new AdoptionForm
			{
				FirstName = FirstName,
				LastName = LastName,
				MiddleName = MiddleName,
				City = City,
				State = State,
				PhoneNumber = PhoneNumber,
				Email = Email,
				DateOfBirth = DateOfBirth,
				PetName = PetName,
				Street = Street,
				UserName = _userService.CurrentUser,
				ImageId = Detail.PetImageId
			};

			// Could use some error handling and succes validation here as an improvment. 
			var id = await _localDbService.AddAdoptionForm(formInfo);

			await Shell.Current.DisplayAlert("Success", "Form submitted successfuly", "OK");
			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
		}
	}
}
