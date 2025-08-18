using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using NitroSongs.Modules.Songs.ViewModels;
using NitroSongs.Navigation;
using NitroSongs.Services;
using NitroSongs.Services.Songs;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NitroSongs
{ 
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Window? _window;
        public static IHost AppHost { get; private set; } = null!;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            AppHost = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.Sources.Clear();

                config
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var config = context.Configuration;

                services.Configure<Configuration>(config.GetSection("Urls"));
                services.AddHttpClient();

                //Global Services
                services.AddSingleton<ApiService>();
                services.AddSingleton<INavigationService, NavigationService>();
                
                //Services
                services.AddTransient<ISongService, SongsService>();

                //ViewModels
                services.AddTransient<SongsViewModel>();
                services.AddTransient<SongViewerViewModel>();
                services.AddTransient<SongEditViewModel>();

                services.AddSingleton<MainWindow>();
            })
            .Build();

            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new MainWindow(AppHost.Services.GetRequiredService<INavigationService>());
            _window.Activate();
        }
    }
}
