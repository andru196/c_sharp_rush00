using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace c_sharp_rush00.Views
{
    public partial class HabbitCheckListView : UserControl
    {
        public HabbitCheckListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}