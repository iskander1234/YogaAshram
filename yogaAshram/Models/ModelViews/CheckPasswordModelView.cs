using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace yogaAshram.Models.ModelViews
{
    public class CheckPasswordModelView
    {
        [Remote(action: "CheckPasswordDelete", controller: "Validation", ErrorMessage = "Пароль не корректен !!!")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}