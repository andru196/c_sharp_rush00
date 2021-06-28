using System;
using System.Collections.Generic;
using System.Linq;
using c_sharp_rush00.Models;
using Avalonia.Metadata;
using ReactiveUI;
using System.Reactive;

namespace c_sharp_rush00.ViewModels
{
    public class AddNewHabbitViewModel : ViewModelBase
    {
        Action<Habbit, IEnumerable<HabitCheck>> comeBack;
        public ReactiveCommand<Unit, Unit> Cancel { get; }

        public AddNewHabbitViewModel(ModelsContext db, Action<Habbit, IEnumerable<HabitCheck>> a, MainWindowViewModel a2)
        {
            comeBack = a;
            Cancel = ReactiveCommand.Create(CancelMethod);
            MainWindowVeiwModel = a2;

        }
        public string Title { get; set; } = "title";
        public string Motivation {get; set;} = "def";
        public System.DateTimeOffset Start {get; set;} = new DateTimeOffset(DateTime.Now);

        public uint ChecksCount {get; set;} = 13;

        [DependsOn(nameof(Title))]
        [DependsOn(nameof(Motivation))]
        [DependsOn(nameof(Start))]
        [DependsOn(nameof(ChecksCount))]
        public bool CanSave()
        {
            return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Motivation)
                && ChecksCount > 0 && Start > DateTimeOffset.Now.AddDays(-1);
        }
        public void Save()
        {
            using var db = new ModelsContext();
            var strt = Start.DateTime;
            var habbit = new Habbit()
            {
                Motivation = Motivation,
                Title = Title,
                IsFinished = false,
                Start = strt
            };
            while (ChecksCount-- > 0)
            {
                var hc = new HabitCheck()
                {
                    IsChecked = false,
                    Date = strt.AddDays(ChecksCount)
                };
                db.HabitChecks.Add(hc);
                habbit.Checks.Add(hc);
            }
            if (db.Habbits.All(x=>!x.IsActive || x.IsFinished))
                habbit.IsActive = true;
            db.Habbits.Add(habbit);
            db.SaveChanges();

            comeBack(habbit, habbit.Checks);
        }
        public void CancelMethod()
        {
            using var db = new ModelsContext();
            var h = db.Habbits.LastOrDefault(x=>x.IsActive);
            if (h != null)
                comeBack(h, h.Checks);
            else
                MainWindowVeiwModel.Content = new MainViewModel(MainWindowVeiwModel);
        }
    }
}