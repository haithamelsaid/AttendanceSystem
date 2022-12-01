using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_attendanceSystem.Models
{
    public class Attendence
    {

        
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan CertainOfStartTime { get; set; }
        public TimeSpan CertainOfEndTime { get; set; }
        public TimeSpan? CheckedIn { get; set; }
        public TimeSpan? CheckedOut { get; set; }
        public string? CheckedInComment { get; set; }
        public string? CheckedOutComment { get; set; }
        public string ApplicationUserGuid { get; set; }
        public bool? IsAttended { get; set; }
        public bool? IsDelayed { get; set; } 
        public bool? IsAbsented { get; set; }

        [ForeignKey("ApplicationUserGuid")]
        public virtual ApplicationUser applicationUser { get; set; }

    }
}
