using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace c_sharp_rush00.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected MainWindowViewModel MainWindowVeiwModel {get; init;}
    }
}
