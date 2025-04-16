using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI101.Maui.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.ViewModels
{
	public partial class PetAdoptionViewModel : ObservableObject
	{
		private IPetService _petService;

		public PetAdoptionViewModel(IPetService petService)
		{
			_petService = petService;

			pets = Task.Run(async () => await _petService.GetPetList()).Result;

			var y = 0;
		}

		[ObservableProperty]
		List<GetPetResponse> pets;

		[RelayCommand]
		async void CardSelected(GetPetResponse pet)
		{
			var detail = new PetFormDetail
			{ 
				PetImageId = pet.Reference_Image_Id
			};

			await Shell.Current.GoToAsync(nameof(AdoptionDetails), 
				new Dictionary<string, object>
				{
					["detail"] = detail
				});
		}
	}
}
