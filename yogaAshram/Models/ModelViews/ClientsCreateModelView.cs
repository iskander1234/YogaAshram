using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using yogaAshram.Controllers;

namespace yogaAshram.Models.ModelViews
{
    public class ClientsCreateModelView
    {
       
        public long GroupId { get; set; }
        public virtual Group Group { get; set; }
        public ClientType ClientType { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int LessonNumbers  { get; set; }
        public string Color { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]

        [Remote(action: "CheckDate", controller: "Validation", ErrorMessage = "Некоректная дата")]
        public DateTime StartDate { get; set; }
        public string Comment { get; set; }
        
        public long SicknessId { get; set; }
        public Sickness Sickness { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Source { get; set; }
        public bool Contract { get; set; }
        public bool WhatsAppGroup { get; set; }
   
        [RegularExpression (@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        public string Email { get; set; }
        public string Address { get; set; }
      
        public string WorkPlace { get; set; }
      
        public DateTime DateOfBirth { get; set; }

        public long MembershipId { get; set; }
        
        public virtual Client Client { get; set; }
        
    }
}