using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using yogaAshram.Models;
using yogaAshram.Models.ModelViews;
using yogaAshram.Services;

namespace yogaAshram.Controllers
{
    
    [Authorize(Roles = "chief")]
    public class ChiefController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly YogaAshramContext _db;

        public ChiefController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, YogaAshramContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
     
        public async Task<IActionResult> Index()
        {
            Employee empl = await _userManager.GetUserAsync(User);
            ViewBag.Branches = _db.Branches.Include(b => b.Admin).ToList();
            
            List<Branch> branches = _db.Branches.Where(b => b.Admin.Role == "admin").ToList();
            
            long[] admins = new long[branches.Count];
            for (int i = 0; i < branches.Count; i++)
            {
                admins[i] = Convert.ToInt64(branches[i].AdminId);
            }
            ViewBag.AdminIdArray = String.Join(" ",admins);
            ViewBag.Admin = _db.Employees.Where(e => e.Role == "admin").ToList();

            return View(new ChiefIndexModelView() { Employee = empl });
        }

        
        
    }
}