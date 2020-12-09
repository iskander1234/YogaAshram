using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yogaAshram.Models;

namespace yogaAshram.Controllers
{
    public class MarketerController : Controller
    {
        private readonly UserManager<Employee> _userManager;

        public MarketerController(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

       
        [Authorize]
        public async Task<IActionResult> Details()
        {
            Employee empl = await _userManager.GetUserAsync(User);
            return View(empl);
        }
    }
}