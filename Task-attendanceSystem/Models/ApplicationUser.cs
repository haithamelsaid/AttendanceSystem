using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_attendanceSystem.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string Address { get; set; }
        public ICollection<Attendence> attendences { get; set; }
    }
}
