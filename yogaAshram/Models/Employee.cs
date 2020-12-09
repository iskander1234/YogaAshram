using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace yogaAshram.Models
{
    public enum PasswordStates
    {
        Normal,
        DisposableNew,
        DisposableUsed
    }
    public class Employee : IdentityUser<long>
    {
       
        public string NameSurname { get; set; }
        public bool OnTimePassword { get; set; } = true;
        public PasswordStates PasswordState { get; set; } = PasswordStates.DisposableNew;
        public string Role { get; set; }
        [NotMapped]
        public Branch Branch { get; set; }

       
    }
}