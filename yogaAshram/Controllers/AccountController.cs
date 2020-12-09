using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using yogaAshram.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using yogaAshram.Models.ModelViews;
using Microsoft.EntityFrameworkCore;
using yogaAshram.Services;

namespace yogaAshram.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private YogaAshramContext _db;
        private readonly RoleManager<Role> _roleManager;

        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, YogaAshramContext db, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _roleManager = roleManager;
        }        
        [HttpGet]
    
        public IActionResult Login(string returnUrl = null)
        {
            return View(new AccountLoginModelView() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginModelView model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = await _db.Employees.
                    FirstOrDefaultAsync(p => p.Email == model.Authentificator ||
                    p.UserName == model.Authentificator);
                /*if(employee.OnTimePassword && await _userManager.CheckPasswordAsync(employee ,model.Password))
                {
                    if (employee.PasswordState == PasswordStates.DisposableUsed)
                    {
                        ModelState.AddModelError("", "Одноразовый пароль уже был использован для входа");
                        return View(model);
                    }
                    else
                    {
                        employee.PasswordState = PasswordStates.DisposableUsed;
                        _db.Entry(employee).State = EntityState.Modified;
                        await _db.SaveChangesAsync();
                    }
                }*/
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
                    employee,
                    model.Password,
                    true,
                    false
                    );
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    var roles = _userManager.GetRolesAsync(employee);
                    foreach (var role in roles.Result)
                    {
                        if (role == "manager")
                            return RedirectToAction("Index", "Manager");
                        else if(role == "chief")
                            return RedirectToAction("Index", "Chief");
                        else if(role == "admin")
                            return RedirectToAction("Index", "Admin");
                        else if(role == "seller")
                            return RedirectToAction("Index", "Seller");
                        else if (role == "marketer")
                            return RedirectToAction("Details", "Marketer");
                    }
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Не корректный пароль и(или) аутентификатор");
            }
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                        new {email = model.Email, token = token}, Request.Scheme);
                    string message = $"<p>Здравствуйте!</p><p>Вы запросили восстановление пароля.</p>" +
                                     $"<p>Пожалуйста, перейдите по этой</p>" +
                                     $" <a href=" + '"' + passwordResetLink  +'"' + ">ссылке</a>," +
                                     " придумайте и введите ваш новый пароль.</p>";
                    await EmailService.SendMessageAsync(model.Email, "Восстановление пароля", message);
                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if(token is null || email is null)
                ModelState.AddModelError("", "Невалидный токен");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        user.OnTimePassword = false;
                        user.PasswordState = PasswordStates.Normal;
                        _db.Entry(user).State = EntityState.Modified;
                        await _db.SaveChangesAsync();
                        return View("ResetPasswordConfirmation");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }
        
        
        [Authorize]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            if (User.IsInRole("admin"))
                return RedirectToAction("Index", "Admin");
            if(User.IsInRole("chief"))
                return RedirectToAction("Index", "Chief");
            if(User.IsInRole("seller"))
                return RedirectToAction("Index", "Seller");
            if(User.IsInRole("marketer"))
                return RedirectToAction("Details", "Marketer");
            return RedirectToAction("Index", "Manager");
        }
    }
}