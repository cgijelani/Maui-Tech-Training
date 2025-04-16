using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI101.Maui.Data_Models;
using MAUI101.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.ViewModels
{
    public partial class ViewFormsViewModel : ObservableObject
	{
        UserService _userService;
        LocalDbService _localDbService;

        public ViewFormsViewModel(UserService userService, LocalDbService localDbService)
        {
            _userService = userService;
            _localDbService = localDbService;
		}

        [ObservableProperty]
        List<AdoptionForm> forms;

		[RelayCommand]
		async void CardSelected(AdoptionForm formDetails)
		{
			await Shell.Current.GoToAsync(nameof(ViewCompletedForm),
				new Dictionary<string, object>
				{
					["formDetails"] = formDetails
				});
		}
	}
}
