using MAUI101.Maui.Helpers;

namespace MAUI101.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
