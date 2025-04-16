using MAUI101.Maui.ViewModels;

namespace MAUI101.Maui;

public partial class AdoptionDetails : ContentPage
{
	public AdoptionDetails(AdoptionDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}