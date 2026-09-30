using BooxBox.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
{
    
}

namespace BooxBox
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string Defaultconnection = "Data source=BooxBox.db";
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.
                Services.AddDbContext<BooxBoxDbContext>(options => options.UseSqlite(Defaultconnection));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
