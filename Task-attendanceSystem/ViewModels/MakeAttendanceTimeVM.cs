using Microsoft.AspNetCore.Mvc.Rendering;

namespace Task_attendanceSystem.ViewModels
{
    public class MakeAttendanceTimeVM
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan CertainOfStartTime { get; set; }
        public TimeSpan CertainOfEndTime { get; set; }
    }
}
