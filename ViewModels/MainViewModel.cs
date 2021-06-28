using System.Linq;
using System.Collections.ObjectModel;
using c_sharp_rush00.Models;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using Avalonia.Metadata;
using System.Threading.Tasks;
using System;


namespace c_sharp_rush00.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Habbit> Habbits {get;}

        public ReactiveCommand<Habbit, Unit> SelectHabbitCommand { get; }
        public ReactiveCommand<Habbit, Unit> FinishHabbitCommand { get; }
        public MainViewModel(MainWindowViewModel a)
        {
            using var db = new ModelsContext();
            Habbits =  new ObservableCollection<Habbit>(db.Habbits.Where(x=>!x.IsFinished).OrderBy(x=>x.IsActive)
                .ThenBy(x=> x.Id));
            SelectHabbitCommand = ReactiveCommand.Create<Habbit>(SelectHabbit);
            FinishHabbitCommand = ReactiveCommand.Create<Habbit>(FinishHabbit);
            MainWindowVeiwModel = a;
        }
        public void SelectHabbit(Habbit check)
        {
            using var db = new ModelsContext();
            var target = db.Habbits.First(x=>check.Id == x.Id);
            MainWindowVeiwModel.Content 
                = new HabbitCheckListViewModel(target, target.Checks, MainWindowVeiwModel);
        }
        public void FinishHabbit(Habbit check)
        {
            using var db = new ModelsContext();
            check = db.Habbits.First(x=>x.Id == check.Id);
            check.IsFinished = true;
            check.IsActive = false;
            MainWindowVeiwModel.Content = new MainViewModel(MainWindowVeiwModel);
            db.SaveChanges();
        }
        public void AddHabbit()
        {
            MainWindowVeiwModel.AddItem();
        }

    }
}