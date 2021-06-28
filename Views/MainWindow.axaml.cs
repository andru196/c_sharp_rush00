using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using c_sharp_rush00.ViewModels;
namespace c_sharp_rush00.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}