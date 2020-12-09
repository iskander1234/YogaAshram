using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using yogaAshram.Models;
using yogaAshram.Models.ModelViews;
using yogaAshram.Services;
using Group = System.Text.RegularExpressions.Group;

namespace yogaAshram.Controllers
{
    public class MembershipController : Controller
    { 
        private readonly UserManager<Employee> _userManager;
        private readonly YogaAshramContext _db;
        private readonly PaymentsService _paymentsService;
        private readonly ClientServices _clientServices;
        public MembershipController(YogaAshramContext db, UserManager<Employee> userManager, PaymentsService paymentsService, ClientServices clientServices)
        {
            _db = db;
            _userManager = userManager;
            _paymentsService = paymentsService;
            _clientServices = clientServices;
        }

        
        // Таблица с абонементами
     
      
        
        public IActionResult Index()
        {
            List<Membership> model = _db.Memberships.ToList(); 
            return View(model);
        }
        public async Task<IActionResult> MembershipExtension(long clientId, string date)
        {
            Client client = await _db.Clients.FindAsync(clientId);
            if (client is null)
                return NotFound();
            long branchId = client.Group.BranchId;
            ViewBag.Memberships = await _db.Memberships.ToArrayAsync();
            if (User.IsInRole("admin"))
            {
                Employee employee = await _userManager.GetUserAsync(User);
                Branch branch = await _db.Branches.FirstOrDefaultAsync(b => b.AdminId == employee.Id);
                if (employee != null)
                    ViewBag.Schedules =
                        await _db.Schedules.Where(s => s.BranchId == branch.Id).ToListAsync();
                
                else
                    return NotFound();
            }
            else if (User.IsInRole("chief") || User.IsInRole("manager"))
                ViewBag.Schedules = await _db.Schedules.Where(s => s.BranchId == branchId).ToListAsync();
            else
                return NotFound();
            
            ViewBag.Date = Convert.ToDateTime(date);
            if (date is null)
            {
                ClientsMembership clientsMembership = _db.ClientsMemberships.ToList().Last(c => c.ClientId == clientId);
                ViewBag.Date = clientsMembership.DateOfExpiry;
            }
            return PartialView(new MembershipExtendModelView() {ClientId = client.Id, Client = client, BranchId = branchId});
        }
        
        // Добавление и редактриование абонемента 
        public async Task<IActionResult> AddOrEdit(long id = 0)
        {
          
            if (id == 0)
                return View(new Membership());
            else
            {
                var membershipModel = await _db.Memberships.FindAsync(id);
                if (membershipModel == null)
                {
                    return NotFound();
                }
                return View(membershipModel);
            }
        }

        
        // Добавление и редактриование абонемента 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(long id, Membership membershipModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _db.Entry(membershipModel).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _db.Update(membershipModel);
                        await   _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (_db.Memberships.FirstOrDefault(p=>p.Id==id)==null)
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _db.Memberships.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", membershipModel) });
        }


        //Вызов модалки для продления абонемента
        [HttpGet]
        public async Task<IActionResult> GetExtendModalAjax(long clientId, string date)
        {
            Client client = await _db.Clients.FindAsync(clientId);
            if (client is null)
                return NotFound();
            ViewBag.Memberships = await _db.Memberships.ToArrayAsync();
            ViewBag.Schedules = await _db.Schedules.ToListAsync();
            ViewBag.Date = Convert.ToDateTime(date);
            return PartialView("PartialViews/ExtendModalPartial",
                new MembershipExtendModelView() {ClientId = client.Id, Client = client});
        }
        
        
        // Продления абонемента
        [HttpPost]
        public async Task<IActionResult> ExtendAjax(MembershipExtendModelView model)
        {
            Client client = await _db.Clients.FirstOrDefaultAsync(p => p.Id == model.ClientId);
            Membership membership = await _db.Memberships.FirstOrDefaultAsync(p => p.Id == model.MembershipId);
            if (-client.Balance > model.CashSum + model.CardSum)
                return Content("errorNotEnoughSum");
            foreach (var attendanceUnActive in _db.Attendances.Where(a => a.ClientId == model.ClientId))
            {
                    attendanceUnActive.IsNotActive = true;
            }
            int daysFrozen = 0;
                if (membership.AttendanceDays == 12)
                    daysFrozen = 3;
                else if (membership.AttendanceDays == 8)
                    daysFrozen = 2;
                else
                    daysFrozen = 0;
                
                List<DateTime> datesOfAttendance = _clientServices.DatesForAttendance(
                        model.Date, model.GroupId,
                        membership.AttendanceDays);
                
                AttendanceCount attendanceCount = new AttendanceCount()
                {
                    AttendingTimes = membership.AttendanceDays,
                    AbsenceTimes = 0,
                    FrozenTimes = daysFrozen
                };
                _db.Entry(attendanceCount).State = EntityState.Added;
                
                client.MembershipId = membership.Id;
                client.GroupId = model.GroupId;
                client.Membership = membership;
                client.LessonNumbers = membership.AttendanceDays;
                client.HasMembership = true;
                _db.Entry(client).State = EntityState.Modified;
                
                DateTime endDate = _clientServices.EndDateForClientsMembership(
                    model.Date, model.GroupId,
                    membership.AttendanceDays);
                ClientsMembership clientsMembership = new ClientsMembership()
                {
                    ClientId = client.Id,
                    MembershipId = membership.Id,
                    DateOfPurchase = DateTime.Now,
                    DateOfExpiry = endDate,
                    FirstDateOfLesson =    model.Date
                };
                _db.Entry(clientsMembership).State = EntityState.Added;
                foreach (var date in datesOfAttendance)
                {
                    Attendance attendance = new Attendance()
                    {
                        ClientId = client.Id,
                        MembershipId = membership.Id,
                        Date = date,
                        AttendanceState = AttendanceState.notcheked,
                        GroupId = model.GroupId,
                        AttendanceCount = attendanceCount,
                        ClientsMembership = clientsMembership
                    };
                    _db.Entry(attendance).State = EntityState.Added;
                }
                Employee employee = await _userManager.GetUserAsync(User);
                
                await _db.SaveChangesAsync();
                model.BranchId = client.Group.BranchId;
                bool check = await _paymentsService.PayForMembership(model, clientsMembership, client, employee.Id);
                if(!check)
                    return Content("error");
                return Content("success");
            
        }

        
        
         // Добавление пробника в группу 
        [HttpGet]
        public async Task<IActionResult> BuyMembership(long clientId, long branchId)
        {
            if (User.IsInRole("admin"))
            {
                Employee user = await _userManager.GetUserAsync(User);
                branchId = _db.Branches.FirstOrDefault(p => p.AdminId == user.Id).Id;
            }

            ViewBag.Schedules = _db.Schedules.Where(p => p.BranchId == branchId).ToList();
            ViewBag.Memberships = _db.Memberships.ToList();
            Client client = _db.Clients.FirstOrDefault(p => p.Id == clientId);
            ViewBag.Groups = _db.Groups.Where(p => p.BranchId == branchId).ToList();
            return View(client);
        }

        // Добавление пробника в группу    
        [HttpPost]
        public async Task<IActionResult> BuyMembership(long clientId, long membershipId, long groupId, string firstDay)
        {    Client client = _db.Clients.FirstOrDefault(p => p.Id == clientId);
            if (clientId != 0 && membershipId != 0 && groupId != 0 && firstDay != null)
            {
                Console.WriteLine(groupId);
                DateTime startDate = DateTime.Parse(firstDay).Date;
                Console.WriteLine(startDate);
              
                client.Paid = Paid.Есть_долг;
                client.GroupId = groupId;
                client.MembershipId = membershipId;
                client.ClientType = ClientType.AreEngaged;
                client.CreatorId = GetUserId.GetCurrentUserId(this.HttpContext);
                client.HasMembership = true;
                Models.Group group = _db.Groups.FirstOrDefault(g => g.Id == groupId);
                if (group != null && group.Clients.Count == 0)
                    group.Clients = new List<Client>()
                    {
                        client
                    };
                else
                    group?.Clients.Add(client);

                Membership membership = _db.Memberships.FirstOrDefault(m => m.Id == membershipId);
                client.Balance = -membership.Price;
                DateTime endDate = _clientServices.EndDateForClientsMembership(
                    startDate,
                    group.Id,
                    membership.AttendanceDays);

                Console.WriteLine(endDate);

                ClientsMembership clientsMembership = new ClientsMembership()
                {
                    Client = client,
                    MembershipId = membership.Id,
                    DateOfPurchase = DateTime.Now,
                    DateOfExpiry = endDate,
                    FirstDateOfLesson = startDate
                };

                _db.Entry(clientsMembership).State = EntityState.Added;
                int daysFrozen = 0;
                if (membership.AttendanceDays == 12)
                    daysFrozen = 3;
                else if (membership.AttendanceDays == 8)
                    daysFrozen = 2;
                else
                    daysFrozen = 0;
                var datesOfAttendance = _clientServices.DatesForAttendance(
                    startDate, groupId,
                    membership.AttendanceDays + daysFrozen);
                AttendanceCount attendanceCount = new AttendanceCount()
                {
                    AttendingTimes = membership.AttendanceDays,
                    AbsenceTimes = 0,
                    FrozenTimes = daysFrozen
                };
                _db.Entry(attendanceCount).State = EntityState.Added;
                for (int i = 0; i < membership?.AttendanceDays; i++)
                {
                    Attendance attendance = new Attendance()
                    {
                        Client = client,
                        MembershipId = membership.Id,
                        Date = datesOfAttendance[i],
                        AttendanceState = AttendanceState.notcheked,
                        GroupId = groupId,
                        AttendanceCount = attendanceCount,
                        ClientsMembership = clientsMembership
                    };
                    _db.Entry(attendance).State = EntityState.Added;
                }

                _db.Entry(client).State = EntityState.Modified;
             _db.Entry(group).State = EntityState.Modified;
                await _db.SaveChangesAsync();     
                await Task.Delay(500);
                return RedirectToAction("RegularClients", "Clients", new {branchId =client.Group.BranchId });
            }
            else Console.WriteLine("");
                
            await Task.Delay(500);
            return RedirectToAction("RegularClients", "Clients", new {branchId =client.Group.BranchId });
        }
        
        
    }   
}