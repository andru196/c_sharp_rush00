using ReactiveUI;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using c_sharp_rush00.Models;
using System.Collections.Generic;
using System.Reactive;


namespace c_sharp_rush00.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        ViewModelBase _content;
        public ViewModelBase Content {get => _content; set => this.RaiseAndSetIfChanged(ref _content, value);}

        public Habbit ActiveHabbit {get;}
        ModelsContext _db;
        Action<Habbit, IEnumerable<HabitCheck>> Action;
        public MainWindowViewModel(ModelsContext db)
        {
            Action = (Habbit h, IEnumerable<HabitCheck> hc) => Content = new HabbitCheckListViewModel(h, hc, this);
            var active = db.Habbits.Where(x => x.IsActive);
            if (active == null)
                throw new System.Exception();
            Habbit habbit = null;
            switch (active.Count())
            {
                case 1:
                    habbit = active.First();
                    Action(habbit, habbit.Checks);
                    break;
                case (0):
                    Content = new AddNewHabbitViewModel(db, Action, this);
                    return;
                default:
                    habbit = active.OrderBy(x => x.Id).Last();
                    active.Where(x=>x.Id != habbit.Id).ToList().ForEach(x=>x.IsActive = false);
                    db.SaveChanges();
                    Action(habbit, habbit.Checks);
                    break;
            }
            ActiveHabbit = habbit;
            _db = db;
        }
        
        public void RaiseMainView()
        {
            Content = new MainViewModel(this);
        }

        public void AddItem()
        {
            Content = new AddNewHabbitViewModel(_db, Action, this);
        }

    }
}
