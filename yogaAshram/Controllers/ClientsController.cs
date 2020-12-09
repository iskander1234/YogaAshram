using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yogaAshram.Models;
using yogaAshram.Models.ModelViews;
using yogaAshram.Services;
using State = yogaAshram.Models.State;

namespace yogaAshram.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly YogaAshramContext _db;
        private readonly ClientServices _clientServices;

        public ClientsController(UserManager<Employee> userManager,
            YogaAshramContext db, ClientServices clientServices, PaymentsService paymentsService)
        {
            _userManager = userManager;
            _db = db;
            _clientServices = clientServices;
        }
        
        //Подробная информация об активном клиенте
        [Authorize]
        public IActionResult ClientСabinet(long clientId)
        {
            var count = _db.AttendanceCounts.ToList();
            ViewBag.AbsenceCount = count[^1];
            
            ViewBag.Sicknesses = _db.Sicknesses.ToList();
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            return View(client);
        }
        
        
        //Информация о клиентах по пропускам итд 
        [Authorize]
        public IActionResult Index(int? membershipLeftDays, int? pageNumber, int? frozenTimes, double? dateFrozen, double? dateAbsent, long? coachId)
        {
            
            ViewBag.Coaches = _db.Groups.ToList();
            var clients = _db.Clients
                .Join(_db.Attendances, c => c.Id, a => a.ClientId, 
                    (client, attendance) => new ClientTableViewModel() { Client = client, Attendance = attendance })
                .ToList();
            clients = clients
                .Join(_db.ClientsMemberships, c => c.Client.Id, m => m.ClientId,
                    ((viewModel, membership) => new ClientTableViewModel()
                        {Client = viewModel.Client, Attendance = viewModel.Attendance, ClientsMembership = membership}))
                .ToList();
            clients = clients
                .GroupBy(p => p.Client.Id)
                .Select(g => g.Last()).ToList();

            int pageSize = 5;
            var model = clients.AsQueryable();
            
            if (User.IsInRole("admin"))
            {
                long employeeId = GetUserId.GetCurrentUserId(this.HttpContext);
                long branchId = _db.Branches.FirstOrDefault(b => b.AdminId == employeeId).Id;
                if (branchId != 0)
                    model = clients.Where(c => c.Client.Group.BranchId == branchId).AsQueryable();
                
            }

            if (membershipLeftDays != null)
            {
                ViewData["CurrentSort"] = membershipLeftDays;
                model = model
                    .Where(m => DateTime.Now <= m.ClientsMembership.DateOfExpiry 
                                && DateTime.Now.AddDays((double) membershipLeftDays) >= m.ClientsMembership.DateOfExpiry);
            }
            if (dateFrozen != null)
            {
                ViewData["DateFrozen"] = dateFrozen; 
                model = model
                    .Where(cl => cl.ClientsMembership.Client.Comments
                        .Any(com => cl.Client.Id == com.ClientId && com.Reason == Reason.Заморозка && com.Date >= DateTime.Today.AddDays((double) dateFrozen)) );
                
            }
            if (dateAbsent != null)
            {
                ViewData["DateAbsent"] = dateAbsent; 
                model = model
                    .Where(cl => cl.ClientsMembership.Client.Comments
                        .Any(com => cl.Client.Id == com.ClientId && com.Reason == Reason.Пропуск && com.Date >= DateTime.Today.AddDays((double) dateAbsent)) );
            }
            if (frozenTimes != null)
            {
                ViewData["FrozenTimes"] = frozenTimes; 
                model = model.Where(c => c.Attendance.AttendanceCount.FrozenTimes == frozenTimes);
            }
            if (coachId != null)
            {
                ViewData["Coach"] = coachId; 
                model = model.Where(c => c.Client.Group.CoachId == coachId);
            }
            return View(PageViewModel<ClientTableViewModel>.Create(model.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        
        //Добавление пробника 
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateClients(Schedule schedule, string newSikness)
        {
            long _sicknessId=0;
            if (newSikness != null) _sicknessId = AddSickness(newSikness);
            else _sicknessId = schedule.ClientsCreateModelView.SicknessId;
            Employee employee =
                _db.Employees.FirstOrDefault(e => e.Id == GetUserId.GetCurrentUserId(this.HttpContext));
           
            Client client = new Client()
            {
                NameSurname = schedule.NameSurname,
                PhoneNumber = schedule.PhoneNumber,
                DateOfBirth = schedule.ClientsCreateModelView.DateOfBirth,
                Email = schedule.ClientsCreateModelView.Email,
                Address = schedule.ClientsCreateModelView.Address,
                WorkPlace = schedule.ClientsCreateModelView.WorkPlace,
                SicknessId = _sicknessId,
                Source = schedule.ClientsCreateModelView.Source,
                GroupId = schedule.ClientsCreateModelView.GroupId,
                ClientType = ClientType.Probe,
                LessonNumbers = schedule.ClientsCreateModelView.LessonNumbers,
                CreatorId = employee.Id
            };
            
            if (schedule.ClientsCreateModelView.Comment != null)
                client.Comments = new List<Comment>
                {
                    new Comment()
                    {
                        Text = $"{employee?.UserName}: {schedule.ClientsCreateModelView.Comment}, {DateTime.Now:dd.MM.yyyy}",
                        Reason = Reason.Другое,
                        Client = client
                    }
                };
            _db.Entry(client).State = EntityState.Added;
            await _db.SaveChangesAsync();
            long ClientId = client.Id;
            if (schedule.ClientsCreateModelView.LessonNumbers == 3)
            {
                TrialUsers trialUsers = new TrialUsers
                {
                    GroupId = schedule.ClientsCreateModelView.GroupId,
                    ClientId = ClientId,
                    State = State.willAttend,
                    Color = "grey",
                    LessonTime = schedule.ClientsCreateModelView.StartDate,
                    SellerComments = new List<Comment>()
                };
                
                _db.Entry(trialUsers).State = EntityState.Added;
                List<DateTime> dates = _clientServices.TwoTimesTrial(schedule.ClientsCreateModelView.GroupId,
                    schedule.ClientsCreateModelView.StartDate);

                for (int i = 0; i < 2; i++)
                {
                    trialUsers = new TrialUsers
                    {
                        GroupId = schedule.ClientsCreateModelView.GroupId,
                        ClientId = ClientId,
                        State = State.willAttend,
                        Color = "grey",
                        LessonTime = dates[i]
                    };
                    _db.Entry(trialUsers).State = EntityState.Added;
                }
            }
            else
            {
                TrialUsers trialUsers = new TrialUsers
                {
                    GroupId = schedule.ClientsCreateModelView.GroupId,
                    ClientId = ClientId,
                    State = State.willAttend,
                    Color = "grey",
                    LessonTime = schedule.ClientsCreateModelView.StartDate
                };
                _db.Entry(trialUsers).State = EntityState.Added;
            }


            await _db.SaveChangesAsync();
            return RedirectToAction("Trials", "Clients", new {branchId = schedule.BranchId});
        }
        
        
        //Добавление комментария пробникам 
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> WriteComment(long clientId, string sellerComment)
        {
            
            TrialUsers client = _db.TrialUserses.FirstOrDefault(c => c.Id == clientId);
            
            Employee employee =
                _db.Employees.FirstOrDefault(e => e.Id == GetUserId.GetCurrentUserId(this.HttpContext));
          
            client.SellerComments.Add(new Comment()
            {
                Text = $"{employee?.UserName}: {sellerComment}, {DateTime.Now:dd.MM.yyyy}",
                Reason = Reason.Другое,
                ClientId = client.ClientId
            });
               
           
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            
            return  RedirectToAction("ClientInfo", "Clients" ,new {id= client.ClientId });

        }

        
        //Таблица с пробниками 
        [Authorize]
        public async Task<IActionResult> Trials(DateTime time, long branchId)
        {
            if (User.IsInRole("admin"))
            {  Employee user=await _userManager.GetUserAsync(User);
                branchId = _db.Branches.FirstOrDefault(p=>p.AdminId==user.Id).Id;
            }
            
            ViewBag.BranchId = branchId;
            if (time == DateTime.MinValue)
                return View(_db.TrialUserses.Where(p => p.Group.BranchId == branchId).OrderBy(p => p.LessonTime)
                    .ToList());
            List<TrialUsers> users = _db.TrialUserses.Where(p => p.LessonTime.Date == time.Date).ToList();

            return View(users.Where(p => p.Group.BranchId == branchId).ToList());
        }
        
        
        //Отметка посещаемости пробников
       [Authorize]
        [HttpGet]
        public IActionResult CheckAttendanceTrial(long groupId, long clientId, long branchId)
        {
            TrialUsers user = _db.TrialUserses.FirstOrDefault(u => u.Id == clientId);
            
            List<TrialUsers> clients = _db.TrialUserses
                .Where(p => p.GroupId == groupId && p.LessonTime == user.LessonTime).ToList();

            ViewBag.BranchIdHidden = branchId;
            return View(clients);
        }

        
        //Отметка  посещаемости пробников
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CheckAttendanceTrial(long[] arrayOfCustomerID, int[] arrayOfState,
            long HbranchId)
        {

            List<TrialCheckModel> models = new List<TrialCheckModel>();
            for (int i = 0; i < arrayOfCustomerID.Length; i++)
            {
                models.Add(new TrialCheckModel(arrayOfCustomerID[i], arrayOfState[i]));
            }

            List<TrialUsers> users = _db.TrialUserses.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < models.Count; j++)
                {
                    if (users[i].Id == models[j].Id)
                    {
                        users[i].State = (State) models[j].State;
                        if (users[i].State == State.attended)
                        {
                            // users[i].Client.LessonNumbers -= 1;
                            users[i].Color = "yellow";
                        }
                        else if (users[i].State == State.notattended)
                        {
                            users[i].Color = "red";
                        }

                        users[i].IsChecked = true;
                    }
                }

                _db.Entry(users[i]).State = EntityState.Modified;
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Trials", "Clients", new {branchId = HbranchId});
        }
        
        
        [Authorize]
       public IActionResult ClientInfo(long Id)
        {
          List<TrialUsers> trialUsersesLessons = _db.TrialUserses.Where(p => p.ClientId == Id).ToList();
          ViewBag.Lessons = trialUsersesLessons;
          TrialUsers client = trialUsersesLessons[0];
          return View(client);

        }
        
        
        //Добавление нового клиента 
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NewClientRegister(Schedule schedule, string newSikness)
        {
            long _sicknessId;
            if (ModelState.IsValid)
            {
                if (newSikness != null)
                    _sicknessId=AddSickness(newSikness);
                
                _sicknessId = schedule.ClientsCreateModelView.SicknessId;
                Client client = new Client()
                {
                    NameSurname = schedule.NameSurname,
                    PhoneNumber = schedule.PhoneNumber,
                    DateOfBirth = schedule.ClientsCreateModelView.DateOfBirth,
                    Email = schedule.ClientsCreateModelView.Email,
                    Address = schedule.ClientsCreateModelView.Address,
                    WorkPlace = schedule.ClientsCreateModelView.WorkPlace,
                    SicknessId = _sicknessId,
                    Source = schedule.ClientsCreateModelView.Source,
                    Paid = Paid.Есть_долг,
                    WhatsAppGroup = WhatsAppGroup.Не_состоит_в_группе,
                    Contract = Contract.Нет_договора,
                    GroupId = schedule.ClientsCreateModelView.GroupId,
                    MembershipId = schedule.ClientsCreateModelView.MembershipId,
                    ClientType = ClientType.AreEngaged,
                    CreatorId = GetUserId.GetCurrentUserId(this.HttpContext),
                    HasMembership = true
                };
                Employee employee =
                    _db.Employees.FirstOrDefault(e => e.Id == GetUserId.GetCurrentUserId(this.HttpContext));
                if (schedule.ClientsCreateModelView.Comment != null)
                    client.Comments = new List<Comment>
                    {
                        new Comment()
                        {
                            Text = $"{employee?.UserName}: {schedule.ClientsCreateModelView.Comment}, {DateTime.Now:dd.MM.yyyy}",
                            Reason = Reason.Другое,
                            Client = client
                        }
                    };
                    
               
                Group group = _db.Groups.FirstOrDefault(g => g.Id == schedule.ClientsCreateModelView.GroupId);
                if (group != null && group.Clients.Count == 0)
                    group.Clients = new List<Client>()
                    {
                        client
                    };
                else
                    group?.Clients.Add(client);

                Membership membership =
                    _db.Memberships.FirstOrDefault(m => m.Id == schedule.ClientsCreateModelView.MembershipId);
                client.Balance = -membership.Price;
                
                DateTime endDate = _clientServices.EndDateForClientsMembership(
                    schedule.ClientsCreateModelView.StartDate, 
                    schedule.ClientsCreateModelView.GroupId,
                    membership.AttendanceDays);
                ClientsMembership clientsMembership = new ClientsMembership()
                {
                    Client = client,
                    MembershipId = membership.Id,
                    DateOfPurchase = DateTime.Now,
                    DateOfExpiry = endDate,
                    FirstDateOfLesson =   schedule.ClientsCreateModelView.StartDate
                };
                Payment payment = new Payment()
                {
                    Debts = membership.Price,
                    ClientsMembership = clientsMembership,
                    Type = PaymentType.Pay,
                    CreatorId = employee.Id,
                    BranchId = group.BranchId,
                    Comment = "Платеж при создании клиента"
                };
                _db.Entry(payment).State = EntityState.Added;
                _db.Entry(clientsMembership).State = EntityState.Added;
                int daysFrozen = 0;
                if (membership.AttendanceDays == 12)
                    daysFrozen = 3;
                else if (membership.AttendanceDays == 8)
                    daysFrozen = 2;
                else
                    daysFrozen = 0;
                var datesOfAttendance = _clientServices.DatesForAttendance(
                    schedule.ClientsCreateModelView.StartDate, schedule.ClientsCreateModelView.GroupId,
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
                        GroupId = schedule.ClientsCreateModelView.GroupId,
                        AttendanceCount = attendanceCount,
                        ClientsMembership = clientsMembership
                    };
                    _db.Entry(attendance).State = EntityState.Added;
                }
                
                _db.Entry(client).State = EntityState.Added;
                _db.Entry(group).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("RegularClients", "Clients", new{branchId=client.Group.BranchId});
            }

            return BadRequest();
        }
        
        
        
        //Добавление в группу старого клиента 
        [HttpPost]
        public async Task<IActionResult> OldClientRegister(Schedule schedule, long clientId)
        {Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            if (ModelState.IsValid)
            {
                

                Debug.Assert(client != null, nameof(client) + " != null");
                client.NameSurname = schedule.NameSurname;
                client.PhoneNumber = schedule.PhoneNumber;
                client.DateOfBirth = schedule.ClientsCreateModelView.DateOfBirth;
                client.Email = schedule.ClientsCreateModelView.Email;
                client.Address = schedule.ClientsCreateModelView.Address;
                client.WorkPlace = schedule.ClientsCreateModelView.WorkPlace;
                client.Sickness = schedule.ClientsCreateModelView.Sickness;
                client.Source = schedule.ClientsCreateModelView.Source;
                Employee employee =
                    _db.Employees.FirstOrDefault(e => e.Id == GetUserId.GetCurrentUserId(this.HttpContext));
                if (client.Comments is null && schedule.ClientsCreateModelView.Comment != null)
                    client.Comments = new List<Comment>
                    {
                        new Comment()
                        {
                            Text = $"{employee?.UserName}: {schedule.ClientsCreateModelView.Comment}, {DateTime.Now:dd.MM.yyyy}",
                            Reason = Reason.Другое,
                            Client = client
                        }
                    };
                else
                {
                     client.Comments?.Clear();
                     client.Comments = new List<Comment>
                     {
                         new Comment()
                         {
                             Text = $"{employee?.UserName}: {schedule.ClientsCreateModelView.Comment}, {DateTime.Now:dd.MM.yyyy}",
                             Reason = Reason.Другое,
                             Client = client
                         }
                     };
                }
                
                client.Paid = Paid.Есть_долг;
                client.WhatsAppGroup = WhatsAppGroup.Не_состоит_в_группе;
                client.Contract = Contract.Нет_договора;
                client.GroupId = schedule.ClientsCreateModelView.GroupId;
                client.MembershipId = schedule.ClientsCreateModelView.MembershipId;
                client.ClientType = ClientType.AreEngaged;
                client.CreatorId = GetUserId.GetCurrentUserId(this.HttpContext);
                
                Group group = _db.Groups.FirstOrDefault(g => g.Id == schedule.ClientsCreateModelView.GroupId);
                if (group != null && group.Clients.Count == 0)
                    group.Clients = new List<Client>(){client};
                else
                    group?.Clients.Add(client);

                Membership membership =
                    _db.Memberships.FirstOrDefault(m => m.Id == schedule.ClientsCreateModelView.MembershipId);
                client.Balance -= membership.Price;
                client.HasMembership = true;
                _db.Entry(client).State = EntityState.Modified;
                
                DateTime endDate = _clientServices.EndDateForClientsMembership(
                    schedule.ClientsCreateModelView.StartDate, 
                    schedule.ClientsCreateModelView.GroupId,
                    membership.AttendanceDays);
                Console.WriteLine(endDate);
               ClientsMembership clientsMembership = new ClientsMembership()
               {
                   ClientId = client.Id,
                   MembershipId = membership.Id,
                   DateOfPurchase = DateTime.Now,
                   DateOfExpiry = endDate,
                   FirstDateOfLesson =   schedule.ClientsCreateModelView.StartDate
               };
                Payment payment = new Payment()
                {
                    Debts = membership.Price,
                    ClientsMembership = clientsMembership,
                    Type = PaymentType.Pay,
                    CreatorId = employee.Id,
                    BranchId = group.BranchId,
                    Comment = "Платеж при создании клиента"
                };
                _db.Entry(payment).State = EntityState.Added;
                _db.Entry(clientsMembership).State = EntityState.Added;
                
                int daysFrozen = 0;
                if (membership.AttendanceDays == 12)
                    daysFrozen = 3;
                else if (membership.AttendanceDays == 8)
                    daysFrozen = 2;
                else
                    daysFrozen = 0;
                var datesOfAttendance = _clientServices.DatesForAttendance(
                    schedule.ClientsCreateModelView.StartDate, schedule.ClientsCreateModelView.GroupId,
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
                        GroupId = schedule.ClientsCreateModelView.GroupId,
                        AttendanceCount = attendanceCount,
                        ClientsMembership = clientsMembership
                    };
                    
                    _db.Entry(attendance).State = EntityState.Added;
                }

                _db.Entry(group).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("RegularClients", "Clients",new{branchId=client.Group.BranchId});
        }

        
        //Список активных  клиентов 
        [Authorize]
        
        public async Task<IActionResult> RegularClients(long branchId)
        {
            if (User.IsInRole("admin"))
            {  Employee user=await _userManager.GetUserAsync(User);
                branchId = _db.Branches.FirstOrDefault(p=>p.AdminId==user.Id).Id;
            }
            
            List<Client> clients = _db.Clients.Where(c=>c.Group.BranchId==branchId && c.ClientType != ClientType.Probe ).OrderByDescending(p=>p.DateCreate).ToList();

            return View(clients);
        }
        
        
        //Сделать клиента не активным
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> MakeClientUnActive(long? clientId)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null && client.ClientType == ClientType.AreEngaged) 
                client.ClientType = ClientType.NotEngaged;
            else if (client != null && client.ClientType == ClientType.NotEngaged)
                client.ClientType = ClientType.AreEngaged;
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("RegularClients", new{branchId=client.Group.BranchId});
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> DeleteClient(long clientId)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            if (client == null) 
                return NotFound();
            long branchId = client.Group.BranchId;
            foreach (var attendance in _db.Attendances.Where(a => a.ClientId == clientId))
            {
                _db.Entry(attendance).State = EntityState.Deleted;
            }
            foreach (var membership in _db.ClientsMemberships.Where(a => a.ClientId == clientId))
            {
                _db.Entry(membership).State = EntityState.Deleted;
            }
            foreach (var comment in _db.Comments.Where(a => a.ClientId == clientId))
            {
                _db.Entry(comment).State = EntityState.Deleted;
            }
            _db.Entry(client).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return RedirectToAction("RegularClients", new {branchId = branchId});
        }
        
        

        
        //Добавить клиента в группу WA
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> MakeClientJoinInWhatsAppGroup(long? clientId)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null && client.WhatsAppGroup == WhatsAppGroup.Не_состоит_в_группе) 
                client.WhatsAppGroup = WhatsAppGroup.Состоит_в_группе;
            else if (client != null && client.WhatsAppGroup == WhatsAppGroup.Состоит_в_группе)
                client.WhatsAppGroup = WhatsAppGroup.Не_состоит_в_группе;
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("RegularClients", new{branchId=client.Group.BranchId});
        }
        
        
        //Подписал договор
        [HttpPost]
        public async Task<IActionResult> ClientSignedContract(long? clientId)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null) client.Contract = Contract.Есть_договор;
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("RegularClients", new{branchId=client.Group.BranchId});
        }
        
        
        //Написать коментарии
        [HttpPost]
        public async Task<IActionResult> Comment(long? clientId, string comment)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            Employee employee =
                _db.Employees.FirstOrDefault(e => e.Id == GetUserId.GetCurrentUserId(this.HttpContext));
            if (client != null && client.Comments is null)
                client.Comments = new List<Comment>
                {
                    new Comment()
                    {
                        Text = $"{employee?.UserName}: {comment}, {DateTime.Now:dd.MM.yyyy}",
                        Reason = Reason.Другое,
                        ClientId = client.Id
                    }
                };
            else
            {
                Comment cmt = new Comment()
                {
                    Text = $"{employee?.UserName}: {comment}, {DateTime.Now:dd.MM.yyyy}",
                    Reason = Reason.Другое,
                    ClientId = client.Id
                };
                client?.Comments.Add(cmt);
            }
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("RegularClients", new{branchId=client.Group.BranchId});
        }
        
        //Скачивание договора 
        public IActionResult GetPdfDocument(long? clientId)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            ContractPdfService contractPdf = new ContractPdfService(_db);
            return contractPdf.RenderPdfDocument(client.Id);
        }

        
        //Отметка клиентов в  группе
        [HttpPost]
        public async Task<IActionResult> RegularAttendance(DateTime date, long clientId, int state, long attendanceId, string reason)
        {
            
            List<Attendance> attendancesToCheckDate = _db.Attendances.Where(a => a.IsChecked 
                                                                                 && a.ClientId == clientId).ToList();
            if (attendancesToCheckDate.Any(a => a.Date == date))
                return Content("errorCheckedAlready");
            List<Attendance> attendancesToCheckPrev = _db.Attendances
                .Where(a => a.ClientId == clientId && a.IsChecked == false)
                .ToList();
            if(attendancesToCheckPrev.Any(a => a.Date < date))
                return Content("errorNeedToCheckPrev");
            Attendance attendance = _db.Attendances
                .FirstOrDefault(a => a.Id == attendanceId);
            
            Debug.Assert(attendance != null, nameof(attendance) + " != null");

            attendance.IsChecked = true;
            attendance.AttendanceState = (AttendanceState) state;
            attendance.AttendanceCount.AttendingTimes -= 1;
            if (attendance.AttendanceCount.AttendingTimes == 0)
            {
                Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
                client.HasMembership = false;
                _db.Entry(client).State = EntityState.Modified;
                foreach (var attendanceDays in _db.Attendances.Where(a => a.ClientId == clientId && a.Date > date))
                {
                    _db.Entry(attendanceDays).State = EntityState.Deleted;
                }
            }
            if (attendance.AttendanceCount.AbsenceTimes < 0)
                return Content("errorAttend");
            
            if (attendance.AttendanceState == AttendanceState.notattended)
                attendance.AttendanceCount.AbsenceTimes += 1;
            else if (attendance.AttendanceState == AttendanceState.cancel)
            {
                attendance.AttendanceCount.AttendingTimes += 1;
                ClientsMembership clientsMembership = _db.ClientsMemberships
                    .FirstOrDefault(c => c.Id == attendance.ClientsMembershipId);
                if (clientsMembership != null)
                {
                    DateTime lastDay = clientsMembership.DateOfExpiry;
                    clientsMembership.DateOfExpiry = _clientServices.DateIfFrozen(lastDay, attendance.GroupId);
                    Attendance att =
                        _db.Attendances.FirstOrDefault(a => a.AttendanceCountId == attendance.AttendanceCountId && a.Date == clientsMembership.DateOfExpiry);
                    if (att == null)
                    {
                        att = new Attendance()
                        {
                            AttendanceCountId = attendance.AttendanceCountId,
                            Date = clientsMembership.DateOfExpiry,
                            ClientId = clientId,
                            GroupId = attendance.GroupId,
                            MembershipId = attendance.MembershipId,
                            ClientsMembershipId = attendance.ClientsMembershipId
                        };
                        _db.Entry(att).State = EntityState.Added;
                        
                    } 
                    
                    _db.Entry(clientsMembership).State = EntityState.Modified;      
                    
                } 
            }
            else if (attendance.AttendanceState == AttendanceState.frozen && attendance.AttendanceCount.FrozenTimes > 0)
            {
                attendance.AttendanceCount.FrozenTimes -= 1;
                attendance.AttendanceCount.AttendingTimes += 1;
                ClientsMembership clientsMembership = _db.ClientsMemberships
                    .FirstOrDefault(c => c.Id == attendance.ClientsMembershipId);
                if (clientsMembership != null)
                {
                    DateTime lastDay = clientsMembership.DateOfExpiry;
                    clientsMembership.DateOfExpiry = _clientServices.DateIfFrozen(lastDay, attendance.GroupId);
                    Attendance att =
                        _db.Attendances.FirstOrDefault(a => a.AttendanceCountId == attendance.AttendanceCountId && a.Date == clientsMembership.DateOfExpiry);
                    if (att == null)
                    {
                        att = new Attendance()
                        {
                            AttendanceCountId = attendance.AttendanceCountId,
                            Date = clientsMembership.DateOfExpiry,
                            ClientId = clientId,
                            GroupId = attendance.GroupId,
                            MembershipId = attendance.MembershipId,
                            ClientsMembershipId = attendance.ClientsMembershipId
                        };
                        _db.Entry(att).State = EntityState.Added;
                        
                    } 
                    _db.Entry(clientsMembership).State = EntityState.Modified;
                }
            }
            else if(attendance.AttendanceState == AttendanceState.frozen && attendance.AttendanceCount.FrozenTimes == 0)
                return Content("errorFrozen");
            
            if (reason != null)
            {
                Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
                Comment comment = new Comment();
                comment.ClientId = clientId;
                comment.Date = date;
                if (attendance.AttendanceState == AttendanceState.frozen)
                    comment.Reason = Reason.Заморозка;
                else if(attendance.AttendanceState == AttendanceState.cancel)
                    comment.Reason = Reason.Отмена;
                else
                    comment.Reason = Reason.Пропуск;
                Employee employee =
                    _db.Employees.FirstOrDefault(e => e.Id == GetUserId.GetCurrentUserId(this.HttpContext));
                comment.Text = $"{employee?.UserName}: {attendance.AttendanceState} {reason}, {DateTime.Now:dd.MM.yyyy}";
                    client?.Comments.Add(comment);
                    _db.Entry(client).State = EntityState.Modified;
            }

            _db.Entry(attendance).State = EntityState.Modified;
            
            await _db.SaveChangesAsync();
            return Content("success");
        }
        
        
        //Комментирование посещаемости 
        [HttpPost]
        public async Task<IActionResult> CommentFromAttendance(long clientId, string comment)
        {
            Employee employee =
                _db.Employees.FirstOrDefault(e => e.Id == GetUserId.GetCurrentUserId(this.HttpContext));
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
            
            if (client != null && client.Comments is null)
                client.Comments = new List<Comment>
                {
                    new Comment()
                    {
                        Text = $"{employee?.UserName}: {comment}, {DateTime.Now:dd.MM.yyyy}",
                        Reason = Reason.Другое,
                        Client = client
                    }
                };
            else
            {
                Comment cmt = new Comment()
                {
                    Text = $"{employee?.UserName}: {comment}, {DateTime.Now:dd.MM.yyyy}",
                    Reason = Reason.Другое,
                    Client = client
                };
                client?.Comments.Add(cmt);
            }
                
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Content("success");
        }
        
        
        //Добавить болезнь 
        [HttpPost]
        public long AddSickness(string sicknessName)
        {
            try
            {
                Sickness sickness = new Sickness()
                {
                    Name = sicknessName
                };

                _db.Entry(sickness).State = EntityState.Added;
                _db.SaveChanges();
                return sickness.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        
        //Проверка неотмеченных клиентов для уведомления
        public bool GetGroupsLink()
        {
            return _db.Attendances.Where(p => p.IsChecked == false && p.Date == DateTime.Today).ToList().Count > 0;
        }
        
        
        //Редактирование клиента
        [Authorize]
        public IActionResult ClientEdit(long id)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == id); 
            ClientsEditModelView model = new ClientsEditModelView()
            {
                PhoneNumber = client.PhoneNumber,
                NameSurname = client.NameSurname,
                Email = client.Email,
                DateOfBirth = client.DateOfBirth,
                Source = client.Source, 
                WorkPlace = client.WorkPlace,
                Sickness = client.Sickness,
            };
            return View(model);
        }
        
        
        //Редактирование клиента 
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ClientEdit(ClientsEditModelView model)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == model.Id);
         
                if (client != null)
                {
                    client.PhoneNumber = model.PhoneNumber;
                    client.NameSurname = model.NameSurname;
                    client.Email = model.Email;
                    client.DateOfBirth = model.DateOfBirth;
                    client.Source = model.Source;
                    client.WorkPlace = model.WorkPlace;
                    client.Sickness = model.Sickness;
                    
                    _db.Entry(client).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                   
                 }
            
            return RedirectToAction("ClientСabinet", new {clientId = client.Id});
        }
    }
}