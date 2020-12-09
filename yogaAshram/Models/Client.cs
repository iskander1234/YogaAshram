using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using yogaAshram.Controllers;
using yogaAshram.Models.ModelViews;

namespace yogaAshram.Models
{
    public enum ClientType
    {[Description("Пробник")]
        Probe,
        [Description("Активный")]
        AreEngaged,
        [Description("Не ходит")]
        NotEngaged
    }
    public enum Paid
    {
        [Description("Оплатил")]
        Оплачено,
        [Description("Не отплатил")]
        Не_оплачено,
        [Description("Долг")]
        Есть_долг
    }
    
    public enum WhatsAppGroup
    {
        [Description("состоит")]
        Состоит_в_группе,
        [Description("не состоит")]
        Не_состоит_в_группе
    }
    public enum Contract
    {   [Description("есть")]
        Есть_договор,
        [Description(" нет")]
        Нет_договора
    }
    public class Client
    {
        public long Id { get; set; }
        
        public string NameSurname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasMembership { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WorkPlace { get; set; }
        public ClientType ClientType { get; set; }
        public int LessonNumbers  { get; set; }
        
        public string Color { get; set; }
        public string Source { get; set; }

        public long GroupId { get; set; }
        
        public virtual Group Group { get; set; }
        public long  CreatorId { get; set; }
        
        public virtual Employee Creator { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public int Balance { get; set; } = 0;
        public Paid Paid { get; set; } = Paid.Не_оплачено;
        public Contract Contract { get; set; } = Contract.Нет_договора;
        public WhatsAppGroup WhatsAppGroup{ get; set; }= WhatsAppGroup.Не_состоит_в_группе;
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public long? MembershipId { get; set; }
        
        public long? SicknessId { get; set; }
        public virtual Sickness Sickness { get; set; }
        public virtual Membership Membership { get; set; }
        
        
        [NotMapped]
        public virtual ClientsEditModelView ClientsEditModelView { get; set; }

        public string GetColorOfState()
        {
            string res = "";
            if (this.ClientType == ClientType.Probe)
                res = "#66b4cf";
            else if (this.ClientType == ClientType.AreEngaged)
                res = "#f0f67a";
            else if (this.ClientType == ClientType.NotEngaged)
                res = "#7a0589";
            return res;
        }

        
        
        
        
    }
    
}