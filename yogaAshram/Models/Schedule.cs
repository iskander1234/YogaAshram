using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using yogaAshram.Models.ModelViews;


namespace yogaAshram.Models
    {
        public class Schedule
        {
            public long Id { get; set; }
            public long BranchId { get; set; }
            public virtual Branch Branch { get; set; }
           public List<string> DayOfWeeksString { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan FinishTime { get; set; }
            public long GroupId { get; set; }
            public virtual Group Group{ get; set; }
            public virtual List<Group> Groups { get; set; }
            [NotMapped]
            public virtual ClientsCreateModelView ClientsCreateModelView { get; set; } 
            [NotMapped] 
            public DateTime ChosenDate { get; set; }
            [NotMapped] 
            public List<Attendance> Attendances { get; set; }
            [NotMapped] 
            [Required(ErrorMessage = "Введите Ф.И.О")]
         
            public string NameSurname { get; set; }
            [NotMapped] 
            [Required(ErrorMessage = "Введите номер телефона")]
          
            public string PhoneNumber { get; set; }
         }
    }

   
