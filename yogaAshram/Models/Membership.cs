using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace yogaAshram.Models
{
    //Абонемент
    public class Membership
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Поле объязательно для заполнения")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле объязательно для заполнения")] 
        [Range(1, 100000,ErrorMessage = "Сумма должна быть больше нуля")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Поле объязательно для заполнения")]
        [Range(1, 300,ErrorMessage = "Кол-во должно быть больше 1")]
        public int AttendanceDays { get; set; }
        public long CategoryId { get; set; }
        public virtual ClientCategory Category { get; set; }
      
    }
}