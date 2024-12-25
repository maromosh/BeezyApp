using BeezyApp.Services;
using BeezyApp.View;
using BeezyApp.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace BeezyApp
{
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
                })
                .RegisterDataServices()
                .RegisterPages()
                .RegisterViewModels();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<RegisterView>();
            builder.Services.AddTransient<HomePageView>();
            builder.Services.AddTransient<ReportsView>();
            builder.Services.AddTransient<UserView>();
            builder.Services.AddTransient<WorkShopView>();
            builder.Services.AddTransient<ChatView>();
            builder.Services.AddTransient<ManagerView>();
            builder.Services.AddTransient<EditProfileView>();

            return builder;
        }

        public static MauiAppBuilder RegisterDataServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<BeezyWebAPIProxy>();
            return builder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<HomePageVeiwModel>();
            builder.Services.AddTransient<ReportsVeiwModel>();
            builder.Services.AddTransient<UserViewModel>();
            builder.Services.AddTransient<WorkShopVeiwModle>();
            builder.Services.AddTransient<ChatVeiwModel>();
            builder.Services.AddTransient<ManagerVeiwModel>();
            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<EditProfileViewModel>();

            return builder;
        }
    }
}
