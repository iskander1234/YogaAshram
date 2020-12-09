using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace yogaAshram.Models.ModelViews
{
    public class ClientsEditModelView
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Введите Ф.И.О")]
        public string NameSurname { get; set; }
        
        [Required(ErrorMessage = "Введите номер телефона")]
   
        public string PhoneNumber { get; set; }
        public long GroupId { get; set; }
        public virtual Group Group { get; set; }
        public ClientType ClientType { get; set; }
   
        public int LessonNumbers  { get; set; }
        public string Color { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]

   
        public DateTime StartDate { get; set; }
        public string Comment { get; set; }
        
        public long SicknessId { get; set; }
        public Sickness Sickness { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Source { get; set; }
        public bool Contract { get; set; }
        public bool WhatsAppGroup { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]

        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string WorkPlace { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public DateTime DateOfBirth { get; set; }

        public long MembershipId { get; set; }
        
        public virtual Client Client { get; set; }
        
        public long ScheduleId { get; set; }
        
        public virtual Schedule Schedule { get; set; }
        
        
    }
}