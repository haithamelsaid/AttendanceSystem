using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Task_attendanceSystem.Models;
using Task_attendanceSystem.ViewModels;

namespace Task_attendanceSystem.Controllers
{
    public class HomeController : Controller
    {
         

        //private readonly ILogger<HomeController> _logger;
         //private readonly UserManager<ApplicationUser> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        //private readonly SignInManager<ApplicationUser> signInManager;
          private AppDbContext db;
        //ApplicationUser appUser ;
         //public HomeController(ApplicationUser appUser,ILogger<HomeController> logger,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, AppDbContext db)
         public HomeController(   AppDbContext db )
         {

        //    _logger = logger;
       //      this.userManager = userManager;
        //    this.roleManager = roleManager;
        //    this.signInManager = signInManager;
            this.db = db;
        //    this.appUser = appUser;
         }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult mydays(string name)
        {


            List<Attendence> attendences = db.Attendences.Where(x => x.applicationUser.UserName ==name).ToList();
            return View(attendences);
        }
        //        [HttpPut]
        public IActionResult CheckedInSubmit(int id, checkedinVM checkedin)
        {

            Attendence attendence = db.Attendences.Where(x => x.Id == id).Single();
            attendence.Day = checkedin.Day;
            attendence.DateTime = checkedin.DateTime;
            attendence.CertainOfStartTime = checkedin.CertainOfStartTime;
            attendence.CertainOfEndTime = checkedin.CertainOfEndTime;
            attendence.CheckedIn = DateTime.Now.TimeOfDay;
            //attendence.CheckedOut = checkedin.CheckedOut;
            attendence.CheckedInComment = checkedin.CheckedInComment;
            attendence.CheckedInComment = checkedin.CheckedOutComment;
            attendence.IsAttended = true;
            

            db.Attendences.Update(attendence);
            db.SaveChanges();
            return View("Index", "Home");
        }
        public IActionResult CheckedOutSubmit(int id, checkedinVM checkedin)
        {

            Attendence attendence = db.Attendences.Where(x => x.Id == id).Single();
            attendence.Day = checkedin.Day;
            attendence.DateTime = checkedin.DateTime;
            attendence.CertainOfStartTime = checkedin.CertainOfStartTime;
            attendence.CertainOfEndTime = checkedin.CertainOfEndTime;
            //attendence.CheckedIn =checkedin.CheckedIn;
            attendence.CheckedOut = DateTime.Now.TimeOfDay;
            attendence.CheckedInComment = checkedin.CheckedInComment;
            attendence.CheckedInComment = checkedin.CheckedOutComment;

            db.Attendences.Update(attendence);
            db.SaveChanges();
            return View("Index", "Home");
        }
        //public IActionResult CheckedOutSubmit(int id)
        //{
        //    Attendence attendence = db.Attendences.Where(x => x.Id == id).Single();
        //    attendence.CheckedOut =DateTime.Now.TimeOfDay;
        //    //attendence.CheckedOutComment = 

        //     db.Attendences.Update(attendance);
        //    return View("Index", "Home");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}