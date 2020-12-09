using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using yogaAshram.Models;
using yogaAshram.Models.ModelViews;
using yogaAshram.Services;

namespace yogaAshram.Controllers
{
    
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IHostEnvironment _environment;
        private YogaAshramContext _db;

        public EmployeesController(UserManager<Employee> userManager, 
            SignInManager<Employee> signInManager,
            IHostEnvironment environment, 
            YogaAshramContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
            _db = db;
        }
        
        // GET
        public IActionResult Index(long? employeeId)
        {
            if (employeeId == null)
                employeeId = GetUserId.GetCurrentUserId(this.HttpContext);
            
            
            Employee employee = _db.Users.FirstOrDefault(u => u.Id == employeeId);
            
            return View(employee);
        }
        string GetRuRoleName(string role)
        {
            switch (role)
            {
                case "manager":
                    return "Старший менеджнер";
                case "seller":
                    return "Менеджер по продажам";
                case "marketer":
                    return "Маркетолог";
                case "admin":
                    return "Администратор";
                case "coach":
                    return "Инструктор";
            }
            return null;
        }
        private async Task SetViewBagRoles()
        {
            Dictionary<string, string> rolesDic = new Dictionary<string, string>();
            var roles = await _db.Roles.Where(p => p.Name != "chief").ToArrayAsync();
            foreach (var item in roles)
                rolesDic.Add(item.Name, GetRuRoleName(item.Name));
            ViewBag.Roles = rolesDic;
        }
        [Authorize]
        public IActionResult GetChangePasswordModalAjax()
        {
            return PartialView("PartialViews/ChangePasswordPartial", new ChangePasswordModelView());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePasswordAjax(ChangePasswordModelView model)
        {
            Employee employee = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                var result = await _userManager.ChangePasswordAsync(employee, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    employee.OnTimePassword = false;
                    employee.PasswordState = PasswordStates.Normal;
                    _db.Entry(employee).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return Json(true);
                }
            }
            return BadRequest();
        }
        [Authorize(Roles = "chief, manager")]
        public async Task<IActionResult> GetCreateEmplModalAjax()
        {
            Employee employee = await _userManager.GetUserAsync(User);
            await SetViewBagRoles();
            return PartialView("PartialViews/CreatePartial", new EmployeeCreateModelView
            {
                Email = employee.Email,
                NameSurname = employee.NameSurname,
                UserName = employee.UserName
            });
        }
        [HttpPost]
        [Authorize(Roles = "chief, manager")]
        public async Task<IActionResult> CreateAjax(EmployeeCreateModelView model)
        {
            if (ModelState.IsValid)
            {
                if (model.Role == "chief")
                    return BadRequest();
                Employee employee = new Employee()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    NameSurname = model.NameSurname,
                    Role = model.Role
                };
                if (model.Role == "coach")
                {
                    _db.Entry(employee).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                    return Json("true");
                }
                string newPsw = PasswordGenerator.Generate();
                Console.WriteLine(newPsw);
                var result = await _userManager.CreateAsync(employee, newPsw);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(employee, model.Role);
                    await EmailService.SendPassword(model.Email, newPsw, Url.Action("Login", "Account", null, Request.Scheme));
                    return Json("true");
                }              
            }
            return Json(false);
        }
        [HttpGet]
        [Authorize(Roles = "chief, manager")]
        public async Task<IActionResult> Edit(long emplId)
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(p => p.Id == emplId);
            if (employee is null)
                return NotFound();
            return View(new EditOtherEmployeeModelView()
            {
                UserName = employee.UserName,
                Email = employee.Email,
                NameSurname = employee.NameSurname,
                Role = employee.Role,
                Id = employee.Id
            });
        }
        [HttpPost]
        [Authorize(Roles = "chief, manager")]
        public async Task<IActionResult> Edit(EditOtherEmployeeModelView model)
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(p => p.Id == model.Id);
            if (employee is null)
                return BadRequest();
            if (_db.Employees.Any(p => (p.Id != model.Id) && (p.UserName == model.UserName || p.Email == model.Email))
                || String.IsNullOrEmpty(model.NameSurname))
                return BadRequest();
            employee.NameSurname = model.NameSurname;
            employee.UserName = model.UserName;
            employee.Email = model.Email;
            employee.Role = model.Role;
            _db.Entry(employee).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("ListEmployee");
        }
        [Authorize]
        public async Task<IActionResult> GetEditModalAjax()
        {
            Employee employee = await _userManager.GetUserAsync(User);
            return PartialView("PartialViews/EmployeeEditPartial", new EmployeeEditModelView
            {
                Email = employee.Email,
                NameSurname = employee.NameSurname,
                UserName = employee.UserName
            });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditAjax(EmployeeEditModelView model)
        {
            Employee employee = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                employee.UserName = model.UserName;
                employee.Email = model.Email;
                employee.NameSurname = model.NameSurname;
                _db.Entry(employee).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Json("true");
            }
            return BadRequest();
        }
        public IActionResult Search(string search)
                {
                    if (User.IsInRole("chief"))
                    {
                        if (string.IsNullOrEmpty(search))
                        {
                            ViewBag.Error = "Введите имя сотрудника для поиска";
                            return PartialView("PartialView", _db.Employees.Where(e => e.Id != GetUserId.GetCurrentUserId(this.HttpContext)).ToList());
                        }
                        search = search.ToUpper();
                        List<Employee> employees = _db.Employees
                            .Where(e => e.Id != GetUserId.GetCurrentUserId(this.HttpContext) && e.UserName != "na")
                            .Where(p => p.UserName.ToUpper().Contains(search)
                                        || p.NameSurname.ToUpper().Contains(search))
                            .ToList();
                        if (employees.Count == 0)
                        {
                            ViewBag.Error = "Совпадений не найдено";
                        }
                        return PartialView("PartialView", employees); 
                    } 
                    
                    if (string.IsNullOrEmpty(search))
                    {
                        ViewBag.Error = "Введите имя пользователя для поиска";
                        return PartialView("PartialViewManager", _db.ManagerEmployees
                            .Include(c => c.Employee)
                            .Include(c => c.Manager)
                            .ToList());
                    }
                    search = search.ToUpper();
                    List<ManagerEmployee> managerEmployees = _db.ManagerEmployees
                        .Include(c => c.Employee)
                        .Include(c => c.Manager)
                        .Where(p => p.Employee.NameSurname.ToUpper().Contains(search) 
                                    || p.Employee.UserName.ToUpper().Contains(search))
                        .ToList();
                    if (managerEmployees.Count == 0)
                    {
                        ViewBag.Error = "Совпадений не найдено";
                    }
                    return PartialView("PartialViewManager", managerEmployees);

                }
        [HttpGet]
        [Authorize(Roles = "chief")]
        public async Task<IActionResult> Delete(long emplId)
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(p => p.Id == emplId);
            if (employee is null)
                return NotFound();
            if (employee.UserName == User.Identity.Name)
                return BadRequest();
            return View(employee);
        }
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "chief")]
        public async Task<IActionResult> DeleteEmpl(long emplId)
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(p => p.Id == emplId);
            List<Branch> branches = _db.Branches.Where(b => b.AdminId == emplId).ToList();
            foreach (var b in branches)
            {
                b.Admin = new Employee() {UserName = "na", Role = "na", Email = "na"};
                _db.Entry(b).State = EntityState.Modified;
            }
            if (employee is null)
                return NotFound();
            if (employee.UserName == User.Identity.Name)
                return BadRequest();
            
            _db.Entry(employee).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Chief");
        }
        [Authorize]
        [ActionName("ListEmployee")]
        public async Task<IActionResult> ListEmployee(long emplId)
        {
            Employee employee = _db.Employees.FirstOrDefault(e => e.Id == emplId);
            
            List<Employee> employees = _db.Employees.Where(e => e.Role != "chief" && e.UserName != "na").ToList();
            List<Branch> branches = _db.Branches.Where(b => b.Admin != null).ToList();
            
            var empl = employees
                .Join(branches, e => e.Id, b => b.AdminId,
                    (employ, branch) => new EmployeesModelView() {Employee = employ, Branch = branch}).ToList();
            var empl2 = new List<EmployeesModelView>();
            foreach (var em in employees)
            {
                empl2.Add(new EmployeesModelView() {Employee = em});
            }
            empl2.AddRange(empl);
            empl2 = empl2.GroupBy(elem=>elem.Employee.Id).Select(group=>group.Last()).ToList();
            
            ViewBag.Employees = empl2;
            return View(employee);
        }
        
        [Authorize]
        public IActionResult RedirectToChoose()
        {
            List<Branch> branches = _db.Branches.ToList();
            return View(branches);

        }
        
    }
}