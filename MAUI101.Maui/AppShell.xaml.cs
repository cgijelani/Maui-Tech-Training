namespace MAUI101.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
			Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
			Routing.RegisterRoute(nameof(AdoptionDetails), typeof(AdoptionDetails));
			Routing.RegisterRoute(nameof(PetAdoptionPage), typeof(PetAdoptionPage));
			Routing.RegisterRoute(nameof(ViewMyFormsPage), typeof(ViewMyFormsPage));
			Routing.RegisterRoute(nameof(ViewCompletedForm), typeof(ViewCompletedForm));

		}
    }
}
