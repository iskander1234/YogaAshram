using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yogaAshram.Models;
using yogaAshram.Models.ModelViews;
using yogaAshram.Services;

namespace yogaAshram.Controllers
{
    
    [Authorize(Roles = "admin,chief")]

    public class AdminController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly YogaAshramContext _db;

        public AdminController(SignInManager<Employee> signInManager, YogaAshramContext db,
            UserManager<Employee> userManager)
        {
            _signInManager = signInManager;
            _db = db;
            _userManager = userManager;
        }

        [Authorize ]
       
          public async Task<IActionResult> Index()
        {
            Employee empl = await _userManager.GetUserAsync(User);
            Branch branch = _db.Branches.FirstOrDefault(b => b.AdminId == empl.Id);
            List<Group> groups;
            if (branch != null) groups = _db.Groups.Where(p => p.BranchId == branch.Id).ToList();
            else groups = null;
            

            return View(new AdminIndexModel()
            {
                Employee = empl,
                Branch = branch,
                Groups = groups
            });
        }
        
        
         public async Task<IActionResult> Scheduele(int? month, long? branchId)
         {
             if (User.IsInRole("admin"))
             {  Employee user=await _userManager.GetUserAsync(User);
                 branchId = _db.Branches.FirstOrDefault(p=>p.AdminId==user.Id).Id;
             }
             
             
             if (_db.CalendarEvents != null || branchId != null) 
                 ViewBag.Events = _db.CalendarEvents
                     .Where(c => c.BranchId == branchId)
                     .ToList();
             ViewBag.Groups = _db.Groups.Where(g => g.BranchId == branchId).ToList();
             List<Schedule> schedules = _db.Schedules.Where(s => s.BranchId == branchId).ToList();
             long[] groupIdArray = new long[schedules.Count];
             for (int i = 0; i < schedules.Count; i++)
             {
                 groupIdArray[i] = schedules[i].GroupId;
             }

             ViewBag.BranchId = branchId;
             ViewBag.GroupIdArray = String.Join(" ", groupIdArray);
            
             DateTime dateTime = DateTime.Today;
             if (month != null)
                 dateTime = new DateTime(dateTime.Year, Convert.ToInt32(month), 1);
             return View(dateTime);
         }


         
    }
}