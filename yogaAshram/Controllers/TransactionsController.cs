using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yogaAshram.Models;
using yogaAshram.Models.ModelViews.Transactions;
using yogaAshram.Services;

namespace yogaAshram.Controllers
{
    
    public class TransactionsController : Controller
    {
        private readonly YogaAshramContext _db;
        private readonly UserManager<Employee> _userManager;

        public TransactionsController(UserManager<Employee> userManager, YogaAshramContext db)
        {
            _userManager = userManager;
            _db = db;
        }


        // GET
        //
        [Authorize]
        public async Task<IActionResult> Index(long branchId, DateTime start)
        {
            if(start==DateTime.MinValue)
                start=DateTime.Now;
            
            ViewBag.BranchId = branchId;
            if (User.IsInRole("admin"))
            {
                Employee user = await _userManager.GetUserAsync(User);
                branchId = _db.Branches.FirstOrDefault(p => p.AdminId == user.Id).Id;
            }
            List<Payment> payments = _db.Payments.Where(p => p.BranchId == branchId && p.CateringDate.Date==start.Date).ToList();
       
            List<Withdrawal> withdrawals = _db.Withdrawals.Where(p => p.BranchId == branchId && p.Date.Date==start.Date).ToList();
            CurrentSum currentSum = _db.CurrentSums.FirstOrDefault(p => p.BranchId == branchId);
            TransactionIndexModel model = new TransactionIndexModel()
            {
                Payments = payments,
                Withdrawals = withdrawals,
                CurrentSum = currentSum,
                BranchId=branchId

            };
            if (model.CurrentSum == null) model.CurrentSum = new CurrentSum();
            return View(model);
        }
        
        [Authorize (Roles = "chief")]
        public IActionResult Withdraw(long branchId)
        {
           CurrentSum cs= _db.CurrentSums.FirstOrDefault(p => p.BranchId == branchId);
           ViewBag.CurrentSum = cs;

            return View(new Withdrawal(){BranchId = branchId});
        }
        
        [Authorize (Roles = "chief")]
        [HttpPost]
        public async Task<IActionResult> Withdraw(Withdrawal model)
        {
            CurrentSum cs = _db.CurrentSums.FirstOrDefault(p => p.BranchId == model.BranchId);
            ViewBag.CurrentSum = cs;
            if (ModelState.IsValid)
            {
                model.CreatorId = GetUserId.GetCurrentUserId(HttpContext);
                model.Date = DateTime.Now;
                if (model.IsCash == true)
                {
                    if (cs.CashSum >= model.Sum)
                        cs.CashSum -= model.Sum;
                    else
                    {
                        ModelState.AddModelError("Sum", "Недостаточно средств для снятия");
                        return View(model);
                    }
                }
                else
                {
                    if (cs.CreditSum >= model.Sum)
                        cs.CreditSum -= model.Sum;
                    else
                    {
                        ModelState.AddModelError("Sum", "Недостаточно средств для снятия");
                        return View(model);
                    }
                }
                _db.Entry(model).State = EntityState.Added;
                _db.Entry(cs).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", new {branchId = model.BranchId});
            }
            return View(model);
        }
        
    }
}