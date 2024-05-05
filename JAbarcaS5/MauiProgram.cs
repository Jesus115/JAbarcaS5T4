using Microsoft.Extensions.Logging;

namespace JAbarcaS5;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		string dbPath = FileAcessHelper.GetLocalFilePath("dbPersona.db3");

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s,dbPath));
		return builder.Build();
	}
}

