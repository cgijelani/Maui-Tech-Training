using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using MAUI101.Maui.API;
using MAUI101.Maui.Services;
using MAUI101.Maui.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Refit;
using System.Reflection;

namespace MAUI101.Maui
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
			.UseMauiApp<App>()
			// Initialize the .NET MAUI Community Toolkit by adding the below line of code
			.UseMauiCommunityToolkit();

			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			var a = Assembly.GetExecutingAssembly();
			using var stream = a.GetManifestResourceStream($"MAUI101.Maui.Resources.Raw.config.json");
			var names = a.GetManifestResourceNames();
			foreach (var name in names)
			{
				Console.WriteLine(name);
			}
			var config = new ConfigurationBuilder()
				.AddJsonStream(stream)
				.Build();
			builder.Configuration.AddConfiguration(config);

			builder.UseMauiApp<App>().UseMauiCommunityToolkitMarkup();

			builder.Services.AddTransient<MainPage>();
			builder.Services.AddSingleton<LocalDbService>();

			builder.Services.AddTransient<LoginPage>();
			builder.Services.AddTransient<LoginViewModel>();
			builder.Services.AddSingleton<UserService>();

			builder.Services.AddTransient<AdoptionDetails>();
			builder.Services.AddTransient<AdoptionDetailViewModel>();

			builder.Services.AddTransient<PetAdoptionPage>();
			builder.Services.AddTransient<PetAdoptionViewModel>();

			builder.Services.AddTransient<LocalStorageService>();
			builder.Services.AddTransient<ViewFormsViewModel>();
			builder.Services.AddTransient<ViewMyFormsPage>();
			builder.Services.AddTransient<ViewCompletedForm>();
			builder.Services.AddTransient<ViewCompletedFormViewModel>();

			builder.Services.AddRefitClient<IPetService>()
				.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.thecatapi.com/v1"));

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
