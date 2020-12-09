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
    
    public class ValidationController : Controller
    {
        private YogaAshramContext _db;
        private readonly UserManager<Employee> _userManager;
        public ValidationController(YogaAshramContext db, UserManager<Employee> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [Authorize]
        public bool CheckEditEmplUserName(string userName, long emplId)
        {
            return !_db.Employees.Any(p => p.UserName == userName && p.Id != emplId);
        }
        [Authorize]
        public bool CheckEditEmplEmail(string email, long emplId)
        {
            return !_db.Employees.Any(p => p.Email == email && p.Id != emplId);
        }
        [Authorize]
        public async Task<bool> CheckEditUserName(string userName)
        {
            if (_db.Employees.Any(p => p.UserName == userName))
            {
                Employee employee = await _userManager.GetUserAsync(User);
                if (employee.UserName != userName)
                    return false;
            }
            return true;
        }
        [Authorize]
        public async Task<bool> CheckEditEmail(string email)
        {
            if (_db.Employees.Any(p => p.Email == email))
            {
                Employee employee = await _userManager.GetUserAsync(User);
                if (employee.Email != email)
                    return false;
            }
            return true;
        }
        public bool CheckEmailForEditing(string Email, long Id)
        {
            List<Employee> usersList = _db.Users.Where(u => u.Id != Id).ToList();
            return usersList.All(u => u.Email != Email);
        }
        
        public bool CheckUserNameForEditing(string UserName, long Id)
        {
            List<Employee> usersList = _db.Users.Where(u => u.Id != Id).ToList();
            return usersList.All(u => u.UserName != UserName);
        }
        [Authorize]
        public async Task<bool> CheckPassword(string currentPassword)
        { 
            Employee empl = await _userManager.GetUserAsync(User);           
            return await _userManager.CheckPasswordAsync(empl, currentPassword);
        }
        public bool CheckRoleExistence(string role)
        {
            return _db.Roles.Any(p => p.Name == role);
        }
        public bool CheckUserNameCreate(string userName)
        {
            return !_db.Employees.Any(p => p.UserName == userName);
        }
        public bool CheckClientName(string nameSurname)
        {
            return !_db.Clients.Any(p => p.NameSurname == nameSurname);
        }
        public bool CheckEmailCreate(string email)
        {
            return !_db.Employees.Any(p => p.Email == email);
        }
        public bool CheckEmailExist(string email)
        {
            return _db.Employees.Any(p => p.Email == email);
            
        }
        public bool CheckAuthValid(string authentificator)
        {
            if (_db.Employees.Any(p => p.UserName== authentificator))
                return true;
            return _db.Employees.Any(p => p.Email == authentificator);
        }
        public bool CheckCreate(string name)
        {
            return _db.Branches.Any(p => p.Name != name);
        }
        
        [Authorize]
        public async Task<bool> CheckPasswordDelete(string password)
        {
            Employee empl = await _userManager.GetUserAsync(User);           
            return await _userManager.CheckPasswordAsync(empl, password);
        }
        
        public bool ClientPhoneNumber(string phoneNumber)
        {
            return !_db.Clients.Any(p => p.PhoneNumber == phoneNumber);
        }
        public bool CheckDate(DateTime startDate)
        {
            return (startDate >= DateTime.Today);
        }
        public bool CheckClient(long id)
        {
            return !_db.Clients.Any(p => p.Id == id);
        }
        public bool CheckMemberhip(long id)
        {
            return !_db.Memberships.Any(p => p.Id == id);
        }
        public bool CheckMemberhipId(long membershipId)
        {
            return !_db.Memberships.Any(p => p.Id == membershipId);
        }
        
        [Authorize]
        public bool CheckSumOfWithdrawal( int Sum)
        {
            return Sum > 0;
        }
        
        
    }
}