using Microsoft.AspNetCore.Identity;

namespace yogaAshram.Models
{
    public class Role: IdentityRole<long>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
    
}