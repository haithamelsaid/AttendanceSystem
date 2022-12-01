using System.ComponentModel.DataAnnotations.Schema;
using Task_attendanceSystem.Models;

namespace Task_attendanceSystem.ViewModels
{
    public class checkedinVM
    {  
         
        public DayOfWeek Day { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan CertainOfStartTime { get; set; }
        public TimeSpan CertainOfEndTime { get; set; }
        public TimeSpan? CheckedIn { get; set; }
        public TimeSpan? CheckedOut { get; set; }
        public string? CheckedInComment { get; set; }
        public string? CheckedOutComment { get; set; }
    }
}
