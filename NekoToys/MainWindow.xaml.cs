using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AntDesign.ProLayout;
using NekoToys.Services;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace NekoToys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var levelSwitch = new LoggingLevelSwitch
            {
                MinimumLevel = LogEventLevel.Debug,
            };
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
                .WriteTo.BrowserConsole()
                .WriteTo.Console()
                .CreateLogger();

            var services = new ServiceCollection();
            services.AddWpfBlazorWebView();
            services.AddAntDesign();
            services.AddScoped<IClipboardService, ClipboardService>();
            services.AddLogging();
            services.Configure<ProSettings>(x =>
            {
                x.Title = "Ant Design Pro";
                x.NavTheme = "light";
                x.Layout = "mix";
                x.PrimaryColor = "daybreak";
                x.ContentWidth = "Fluid";
                x.HeaderHeight = 64;
            });
#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif

            Resources.Add("services", services.BuildServiceProvider());
        }
    }
}