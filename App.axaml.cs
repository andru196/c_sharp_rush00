using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using c_sharp_rush00.ViewModels;
using c_sharp_rush00.Views;

namespace c_sharp_rush00
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                using var db = new c_sharp_rush00.Models.ModelsContext();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(db),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}