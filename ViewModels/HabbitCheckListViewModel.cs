using System.Linq;
using System.Collections.ObjectModel;
using c_sharp_rush00.Models;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using Avalonia.Metadata;
using System.Threading.Tasks;

namespace c_sharp_rush00.ViewModels
{
    public class HabbitCheckListViewModel : ViewModelBase
    {
        public ObservableCollection<HabitCheck> HabbitChecks {get;}
        public ReactiveCommand<HabitCheck, Unit> CheckedHabbitItem { get; }
        Habbit Habbit {get;}

        public HabbitCheckListViewModel(Habbit h, IEnumerable<HabitCheck> list, MainWindowViewModel a)
        {
            HabbitChecks = new ObservableCollection<HabitCheck>(list.OrderBy(x=>x.Date));
            CheckedHabbitItem = ReactiveCommand.Create<HabitCheck>(CheckedHabbit);
            MainWindowVeiwModel = a;
            Habbit = h;
        }

        public void CheckedHabbit(HabitCheck check)
        {
            using var db = new c_sharp_rush00.Models.ModelsContext();
            db.HabitChecks.First(x=>x.Id == check.Id).IsChecked = check.IsChecked;
            db.SaveChanges();
        }

        public void AddItem()
        {
            MainWindowVeiwModel.Content = new AddNewHabbitViewModel(new ModelsContext(), 
                (x, y) => MainWindowVeiwModel.Content = this, MainWindowVeiwModel);
        }

        public void FinishHabbit()
        {
            using var db = new ModelsContext();
            var habbit = db.Habbits.First(x=>x.Id == Habbit.Id);
            habbit.IsFinished = true;
            habbit.IsActive = false;
            db.SaveChanges();
            MainWindowVeiwModel.Content = new MainViewModel(MainWindowVeiwModel);
        }
    }
}