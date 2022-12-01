using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Security.Claims;
using Task_attendanceSystem.Models;
using Task_attendanceSystem.ViewModels;

namespace Task_attendanceSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private AppDbContext db;
        ApplicationUser appUser=new ApplicationUser();
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,SignInManager<ApplicationUser> signInManager,AppDbContext db )
        {

            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Registeration()
        {

            return View();
        }
       [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterationVM registerationVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = registerationVm.UserName,
                    Email = registerationVm.Email,
                    PhoneNumber = registerationVm.PhoneNumber,
                    Address = registerationVm.Address
                };
                IdentityResult result = await userManager.CreateAsync(user, registerationVm.Password);
                await userManager.AddToRoleAsync(user, "Employee");
                //await userManager.AddToRoleAsync(user, "Admin");
                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(registerationVm);
                }
                return RedirectToAction("Index", "Home");

            }
            return View(registerationVm);
        }
        public IActionResult SignIn()
        {
            //LoginVM loginVM = new();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginVM.UserName);
                if (user != null)
                {
                    bool found =await userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(user, loginVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }

            ModelState.AddModelError("", "Invalid username or password");
            return View(loginVM);
            }
            return View(loginVM);

        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Employees()
        {
            List<ApplicationUser> users = userManager.Users.Where(x=>x.UserName!="Admin").ToList();
            return View(users);
        }
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //[Route("/{id}")]
        public IActionResult MakeAttendanceTime(string id)
        {
            //if (id == appUser.UserName)
            //if (userName == User.Identity.Name)
            //{
            ViewBag.id = id;
            //this not work that i delete it
            //TempData["id"] = id;
            return View();
            //}
            //else
            //{
              //  return RedirectToAction(nameof(Employees));
            //}
        }
         
        //[Route("/{id}")]
        [HttpPost]
        public IActionResult MakeAttendanceTime(string id,[FromForm]MakeAttendanceTimeVM makeAttendanceTimeVM)
        {
             Attendence attendence = new Attendence();
            //id = TempData["id"].ToString();
            //attendence.ApplicationUserGuid = db.Users.SingleOrDefault(x => x.Id == id).Id.ToString();

            //final  that true ISA
            //if (id == TempData["id"].ToString())
            //{
                attendence.ApplicationUserGuid = id;
            //}

            attendence.Day= makeAttendanceTimeVM.Day;
            attendence.DateTime= makeAttendanceTimeVM.DateTime;
            attendence.CertainOfStartTime= makeAttendanceTimeVM.CertainOfStartTime;
            attendence.CertainOfEndTime= makeAttendanceTimeVM.CertainOfEndTime;
            
            //why not work i don't know
            //attendence.ApplicationUserGuid = (string)TempData["id"];
            
            
            //attendence.Id = makeAttendanceTimeVM.Id;
            //attendence.ApplicationUserGuid = userManager.FindByIdAsync();
            db.Attendences.Add(attendence);
            db.SaveChanges();
            return RedirectToAction("Employees");
        }

        //public IActionResult ShowAttendance([FromRoute] int id)
        // need it   [Route("/{id}")]
       // need it public IActionResult ShowAttendance(string id)
        public IActionResult ShowAttendance(string id)
        {
            
            // need it   List<Attendence> attendences = db.Attendences.Where(x=>x.ApplicationUserGuid==id).ToList();
            List<Attendence> attendences = db.Attendences.Where(x=>x.ApplicationUserGuid==id).ToList();
            return View(attendences);
         }
    }
}
