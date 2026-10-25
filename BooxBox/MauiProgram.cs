using BooxBox.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BooxBox.Pages;
using BooxBox.Services;
using BooxBox.Repos;
using BooxBox.Interfaces;

namespace BooxBox
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            System.Diagnostics.Debug.WriteLine("MauiProgram gestart");

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<BooxBoxDbWrapper>();

            builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
            builder.Services.AddSingleton<AuthorService>();

            builder.Services.AddSingleton<IBookRepository, BookRepository>();
            builder.Services.AddSingleton<BookService>();

            builder.Services.AddSingleton<IBookCollectionRepository, BookCollectionRepository>();
            builder.Services.AddSingleton<BookCollectionService>();

            builder.Services.AddSingleton<IBookLocationRepository, BookLocationRepository>();
            builder.Services.AddSingleton<BookLocationService>();

            builder.Services.AddSingleton<IIllustratorRepository, IllustratorRepository>();
            builder.Services.AddSingleton<IllustratorService>();

            builder.Services.AddSingleton<ILanguageRepository, LanguageRepository>();
            builder.Services.AddSingleton<LanguageService>();
           
            builder.Services.AddSingleton<IBookLocationRepository, BookLocationRepository>();
            builder.Services.AddSingleton<BookLocationService>();


            builder.Services.AddTransient<ManualAddPage>();
            builder.Services.AddTransient<BookCollectionPage>();
            builder.Services.AddTransient<BookDetailsPage>();
            builder.Services.AddTransient<BookLocationPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
