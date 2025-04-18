﻿using Block4Bilal.Menu;
using Block4Bilal.Profile;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Block4Bilal;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("ShadowsIntoLight-Regular.ttf", "Shadows");
                fonts.AddFont("Sofia-Regular.ttf", "Sofia");
                fonts.AddFont("Font Awesome 5 Free-Solid-900.otf", "FA-5-Solid");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddSingleton<IPreferences>(Preferences.Default);
        builder.Services.AddSingleton<IMenuService, MenuService>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransientWithShellRoute<CategoriesPage, CategoriesViewModel>(nameof(CategoriesPage));
        builder.Services.AddTransientWithShellRoute<DishPage, DishViewModel>(nameof(DishPage));
        return builder.Build();
    }
}
