using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace c_sharp_rush00.Views
{
    public partial class AddNewHabbitView : UserControl
    {
        public AddNewHabbitView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}