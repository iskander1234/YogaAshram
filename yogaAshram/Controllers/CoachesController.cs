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

namespace yogaAshram.Controllers
{
    public class CoachesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly YogaAshramContext _db;

        public CoachesController(UserManager<Employee> userManager, YogaAshramContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        [Authorize(Roles = "chief, manager")]
        public async Task<IActionResult> Index(CoachesIndexModelView model)
        {
            if (model is null)
                model = new CoachesIndexModelView();
            var employees = _db.Employees.AsQueryable();
            if (model.BranchId != null)
                employees = _db.Groups.Where(p => p.BranchId == model.BranchId).Select(p => p.Coach);
            if (!String.IsNullOrEmpty(model.CoachName))
                employees = employees.Where(p => p.NameSurname.Contains(model.CoachName) || p.Email.Contains(model.CoachName) || p.UserName.Contains(model.CoachName));
            model.Coaches = await (from e in employees
                                   where e.Role == "coach"
                                   select new CoachSelector()
                                   {
                                       Coach = e,
                                       Groups = (from g in _db.Groups where g.CoachId == e.Id select g).ToArray()
                                   }).ToArrayAsync();
            return View(model);
        }
        [Authorize(Roles = "chief, manager, coach")]
        public async Task<IActionResult> Details(long? coachId, CoachDetailsModelView model)
        {
            if (model is null)
                model = new CoachDetailsModelView();
            Employee coach = new Employee();
            if (User.IsInRole("coach"))
                coach = await _userManager.GetUserAsync(User);
            else if (coachId != null)
            {
                coach = await _db.Employees.FindAsync(coachId);
                if (coach is null)
                    return NotFound();
                if (coach.Role != "coach")
                    return BadRequest();
            }
            else
                return NotFound();
            model.Groups = await _db.Groups.Where(g => g.CoachId == (long)coachId).ToListAsync();
            if (model.GroupId is null)
            {
                Group group = model.Groups.Where(g => g.CoachId == (long)coachId).FirstOrDefault();
                if (group != null)
                    model.GroupId = group.Id;
            }
            model.Coach = coach;
            model.Payments = await (from c in _db.Clients
                                    where c.Group.CoachId == coachId && c.Group.Id == model.GroupId
                                    select new PaymentSelector()
                                    {
                                        Client = c,
                                        Payments = _db.Payments.Where(pay => pay.ClientsMembership.ClientId == c.Id).ToArray()
                                    }.SetAmount()).ToArrayAsync();
            return View(model);
        }
    }
}