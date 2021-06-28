using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using c_sharp_rush00.ViewModels;

namespace c_sharp_rush00
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}