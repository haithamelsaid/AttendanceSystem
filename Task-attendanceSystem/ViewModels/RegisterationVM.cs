using System.ComponentModel.DataAnnotations;

namespace Task_attendanceSystem.ViewModels
{
    public class RegisterationVM
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
     }
}
