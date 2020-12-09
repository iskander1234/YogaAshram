using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace yogaAshram.Models.ModelViews
{
    public class EmployeeEditModelView
    {
        [Required(ErrorMessage = "Введите логин")]
        [Remote(action: "CheckEditUserName", controller: "Vaidation", ErrorMessage = "Аккаунт с таким логином уже зарегистрирован")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите почту")]
        [Remote(action: "CheckEditEmail", controller: "Vaidation", ErrorMessage = "Аккаунт с такой почтой уже зарегистрирован")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите имя и фамилию")]
        public string NameSurname { get; set; }
    }
}