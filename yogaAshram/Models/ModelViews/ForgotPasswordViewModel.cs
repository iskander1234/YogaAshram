using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace yogaAshram.Models.ModelViews
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Введите email")]
        [Remote(action: "CheckEmailExist", controller: "Validation", ErrorMessage = "Такой почты не существует")]
        public string Email { get; set; }
    }
}