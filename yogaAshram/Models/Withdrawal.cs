using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace yogaAshram.Models
{
    public class Withdrawal
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Введите сумму")]
        [Remote(action: "CheckSumOfWithdrawal", controller: "Validation", ErrorMessage = "Сумма должна быть больше нуля")]
        public int Sum { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public long CreatorId { get; set; }
        public virtual Employee Creator { get; set; }
        public long BranchId { get; set; }
        public virtual Branch  Branch{ get; set; }
        public bool IsCash { get; set; } 

    }
}