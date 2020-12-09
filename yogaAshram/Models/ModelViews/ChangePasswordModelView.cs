using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yogaAshram.Models.ModelViews
{
    public class ChangePasswordModelView
    {
        [Required(ErrorMessage = "Введите текущий пароль")]
        [Remote(action: "CheckPassword", controller: "Validation", ErrorMessage = "Неверный пароль")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Введите новый пароль")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Подтвердите новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
