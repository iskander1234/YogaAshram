using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using yogaAshram.Models;
using yogaAshram.Models.ModelViews;

namespace yogaAshram.Controllers
{
    
    [Authorize(Roles = "chief")]
    public class BranchController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly YogaAshramContext _db;

        public BranchController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, YogaAshramContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> CreateBranch(string name, string info, string address, long? adminId)
        {
            Branch branch = new Branch()
            {
                Name = name,
                Info = info,
                Address = address,
                AdminId = adminId,
                
            };
         
            _db.Entry(branch).State = EntityState.Added;
            await _db.SaveChangesAsync();
            long branchId = branch.Id;
            Employee chief= _db.Employees.FirstOrDefault(p => p.Id == 1);
         
            CurrentSum cs = new CurrentSum()
            {
                CashSum = 0,
                CreditSum = 0,
                BranchId=branchId
                
            };
            Employee admin = _db.Employees.FirstOrDefault(e => e.Id == adminId);
            admin.Branch = branch;
            _db.Entry(admin).State = EntityState.Modified;
            _db.Entry(cs).State = EntityState.Added;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Chief");
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(long id, 
            string name, 
            string address,
            string info,
            long? adminId)
        {
            Branch branch = _db.Branches.FirstOrDefault(p => p.Id == id);
            if (branch != null)
            {
                if (name != null)
                    branch.Name = name;
                
                else if(address != null)
                    branch.Address = address;
                
                else if(info != null)
                    branch.Info = info;
                
                else if(adminId != null)
                    branch.AdminId = adminId;

                _db.Entry(branch).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Chief");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id, CheckPasswordModelView model)
        {
            Employee empl = await _userManager.GetUserAsync(User);
            Branch branch = _db.Branches.FirstOrDefault(p => p.Id == id);
            CurrentSum currentSum = _db.CurrentSums.FirstOrDefault(p => p.BranchId == id);
            var result = await _userManager.CheckPasswordAsync(empl, model.Password);;
            if (result == true)
            {
                _db.Entry(branch).State = EntityState.Deleted;
                _db.Entry(currentSum).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Chief");
        }
    }
}