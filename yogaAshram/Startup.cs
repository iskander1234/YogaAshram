using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// using yogaAshram.Jobs;
using yogaAshram.Models;
using yogaAshram.Quartz;
using yogaAshram.Services;
using yogaAshram.Workers;

namespace yogaAshram
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddRouting(options => options.LowercaseUrls = true);
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<YogaAshramContext>(options => options.UseLazyLoadingProxies().UseNpgsql(connection))
                .AddIdentity<Employee, Role>(options =>
                {
                    options.Password.RequiredLength = 6; // минимальная длина
                    options.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                    options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                    options.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                    options.Password.RequireDigit = false; // требуются ли цифры
                    options.User.AllowedUserNameCharacters = null;
                })
                .AddEntityFrameworkStores<YogaAshramContext>()
                .AddDefaultTokenProviders();
           // services.AddTransient<EmailService>();
            services.AddTransient<ClientServices>();
            services.AddTransient<PaymentsService>();     
            services.AddTransient<JobFactory>();
            services.AddScoped<DataJob>();
            services.AddScoped<IBot,Bot>();
            services.AddScoped<EmailService>();
        
 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] { new CultureInfo("ru-RU") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

        
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}