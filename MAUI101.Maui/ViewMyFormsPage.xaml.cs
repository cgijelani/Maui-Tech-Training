using MAUI101.Maui.Services;
using MAUI101.Maui.ViewModels;

namespace MAUI101.Maui;

public partial class ViewMyFormsPage : ContentPage
{
	private ViewFormsViewModel _vm;
	private UserService _userService;
	private LocalDbService _localDbService;

	public ViewMyFormsPage(ViewFormsViewModel vm, UserService userService, LocalDbService localDbService)
	{
		InitializeComponent();
		_userService = userService;
		_localDbService = localDbService;

		_vm = vm;
		BindingContext = vm;

		Loaded += OnLoad;
	}

	private async void OnLoad(object sender, EventArgs e)
	{
		_vm.Forms = await _localDbService.GetUserAdoptionForms(_userService.CurrentUser);
	}
}