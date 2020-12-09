using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yogaAshram.Models;

namespace yogaAshram.Services
{
    public static class RoleInitializer
    {
        public static async Task Initialize(RoleManager<Role> roleManager,
            UserManager<Employee> userManager)
        {
            string dirEmail = "dir@gmail.com";
            string dirPassword = "12345678910";
            string dirNameSurname = "Checdasd";
            string dirUserName = "Chief";
            var roles = new[] { "chief", "manager", "seller", "marketer", "admin","coach" };
            
            foreach (var role in roles)
            {
                if (await roleManager.FindByNameAsync(role) is null)
                    await roleManager.CreateAsync(new Role(role));
            }
            
            if (await userManager.FindByEmailAsync(dirEmail) is null)
            {
                Employee chief = new Employee()
                {
                    Email = dirEmail,
                    UserName = dirUserName,
                    NameSurname = dirNameSurname,
                    Role="chief"
                };
                var result = await userManager.CreateAsync(chief, dirPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(chief, "chief");
            }
        }
        
    }
}
