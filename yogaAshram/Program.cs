using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using yogaAshram.Models;
using yogaAshram.Services;
// using yogaAshram.Jobs;
using yogaAshram.Quartz;

namespace yogaAshram
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           

            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();;
            var services = scope.ServiceProvider;
            try
            {
                  
                DataScheduler.Start(services);
                var userManager = services.GetRequiredService<UserManager<Employee>>();
                var roleManager = services.GetRequiredService<RoleManager<Role>>();
                await RoleInitializer.Initialize(roleManager, userManager);
             
             
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "�������� ���������� ��� ������������� �����");
            }
            
            
            
            
          
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }

   
}