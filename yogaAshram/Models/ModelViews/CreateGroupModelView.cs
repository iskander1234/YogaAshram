using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace yogaAshram.Models.ModelViews
{
    public class CreateGroupModelView
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Введите наименование группы")]
        public string  Name { get; set; }
        [Remote(action: "CheckCreate", controller: "Validation", ErrorMessage = "Такого филиала нет !!!")]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [Required(ErrorMessage = "Выберите тренера")]
        public long CoachId { get; set; }
        
        public int MaxCapacity { get; set; } = 16;
        
        public int MinCapacity { get; set; } = 10;
        
        public long  CreatorId { get; set; }
        
        public virtual Employee Creator { get; set; }
    }
}