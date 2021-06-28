using System.ComponentModel.DataAnnotations;

namespace c_sharp_rush00.Models
{
    public class HabitCheck
    {
        [Key]
        public long Id {get; set;}
        public System.DateTime Date {get;init;}
        public bool IsChecked {get; set;}
    }
}