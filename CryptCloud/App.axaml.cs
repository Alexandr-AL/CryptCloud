using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using CryptCloud.ViewModels;
using CryptCloud.ViewModels.Home;
using CryptCloud.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using CryptCloud.Infrastructure;
using CryptCloud.Infrastructure.Validators;
using CryptCloud.Views.Home;

namespace CryptCloud
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();
            Ioc.Default.ConfigureServices(provider);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                DisableAvaloniaDataAnnotationValidation();

                desktop.MainWindow = new MainWindowView
                {
                    DataContext = provider.GetRequiredService<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            
            services.AddSingleton<LoginPageViewModel>();
            services.AddSingleton<HomePageViewModel>();
            
            services.AddSingleton<DiskConnectionPageViewModel>();
            services.AddSingleton<LatestPageViewModel>();
            services.AddSingleton<MyDisksPageViewModel>();
            services.AddSingleton<FilesPageViewModel>();
            services.AddSingleton<DownloadsPageViewModel>();
            services.AddSingleton<SettingsPageViewModel>();
            services.AddSingleton<TrashCanPageViewModel>();
            services.AddSingleton<TopContentElementViewModel>();

            services.AddSingleton<IPageFactory, PageFactory>();

            services.AddTransient<UserValidator>();
        }
    }
}