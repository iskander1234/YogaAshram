using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace yogaAshram.Models.ModelViews
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Введите email")]
        [Remote(action: "CheckEmailExist", controller: "Validation", ErrorMessage = "Такой почты не существует")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}