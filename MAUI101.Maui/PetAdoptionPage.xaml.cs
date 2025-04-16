using MAUI101.Maui.ViewModels;

namespace MAUI101.Maui;

public partial class PetAdoptionPage : ContentPage
{
	public PetAdoptionPage(PetAdoptionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}