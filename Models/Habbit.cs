using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace c_sharp_rush00.Models
{
    public class Habbit
    {
        [Key]
        public long Id {get; set;}
        [Required] public string Title {get; set;}
        [Required] public System.DateTime Start {get; set;}
        public string Motivation {get; set;}
        public bool IsFinished {get; set;}
        public bool IsActive {get; set;}
        public List<HabitCheck> Checks {get;} = new List<HabitCheck>();
    }
}