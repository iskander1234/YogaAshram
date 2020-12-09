using System;
using System.Collections.Generic;
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
    
    
    public class SellerController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly YogaAshramContext _db;
        private readonly SignInManager<Employee> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public SellerController(UserManager<Employee> userManager, YogaAshramContext db, SignInManager<Employee> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET
    
      [Authorize(Roles = "seller")]
        public async Task<IActionResult> Index()
        {
            Employee empl = await _userManager.GetUserAsync(User);

            return View(new SellerIndexModel()
            {
                Employee = empl,
                Branches = _db.Branches.ToList(),
                Clients = _db.Clients.ToList()
            });
        }
      
        
       
        












    }

}
