using MAUI101.Maui.API;
using MAUI101.Maui.Helpers;
using MAUI101.Maui.Services;
using Microsoft.Extensions.Configuration;

namespace MAUI101.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly LocalDbService _localDbService;
        private readonly IPetService _petService;

        public MainPage(LocalDbService localDbService, IPetService petService)
        {
            InitializeComponent();

            _localDbService = localDbService;
			_petService = petService;

		}

        private async void OnViewAdoptionsClick(object sender, EventArgs e)
        {
			await Shell.Current.GoToAsync($"//{nameof(PetAdoptionPage)}");
        }

		private async void OnViewFormsClick(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync($"//{nameof(ViewMyFormsPage)}");
		}
	}

}
