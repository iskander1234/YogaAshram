using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class EmployeeCreateModelView
    {
        [Required(ErrorMessage = "Введите ваши имя и фамилию")]
        public string NameSurname { get; set; }
        [Remote(action: "CheckUserNameCreate", controller: "Validation", ErrorMessage = "Такой логин уже существует")]
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин для пользователя")]
        public string UserName { get; set; }
        
        [Remote(action: "CheckEmailCreate", controller: "Validation", ErrorMessage = "Такая почта уже существует")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        public string Role { get; set; }
    }
}
