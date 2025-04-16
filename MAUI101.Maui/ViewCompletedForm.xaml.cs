using MAUI101.Maui.ViewModels;

namespace MAUI101.Maui;

public partial class ViewCompletedForm : ContentPage
{
	public ViewCompletedForm(ViewCompletedFormViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}