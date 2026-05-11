using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UDayCore.ViewModels;
using UDayCore.Views;

namespace UDayCore
{
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
                });

            builder.Services.AddSingleton<UDayCore.Services.TaskItemService>();

            builder.Services.AddTransient<UDayCore.ViewModels.HomeViewModel>();
            builder.Services.AddTransient<UDayCore.Views.HomePage>();

            builder.Services.AddTransient<CreateTaskViewModel>();
            builder.Services.AddTransient<CreateTaskPage>();

            #region IFs FEIOS
#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Mapeador Global para remover o sublinhado do Android em todos os inputs de texto
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });

            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                // Ao definir como null, removemos o Drawable do sublinhado completamente.
                // Isso é isolado apenas para o campo de texto e não afeta o DatePickerDialog.
                handler.PlatformView.Background = null;
#endif
            });
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                // Ao definir como null, removemos o Drawable do sublinhado completamente.
                // Isso é isolado apenas para o campo de texto e não afeta o DatePickerDialog.
                handler.PlatformView.Background = null;
#endif
            });
            #endregion

            return builder.Build();
        }
    }
}
