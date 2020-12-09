
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace yogaAshram.Models
{
    public class YogaAshramContext : IdentityDbContext<Employee, Role, long>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ManagerEmployee> ManagerEmployees { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<TrialUsers> TrialUserses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<ClientCategory> Categories { get; set; }
        public DbSet<CurrentSum> CurrentSums { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ClientsMembership> ClientsMemberships { get; set; }
        public DbSet<AttendanceCount> AttendanceCounts { get; set; }
        
        public DbSet<Sickness> Sicknesses { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public YogaAshramContext(DbContextOptions options) : base(options)
        {
        }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientCategory>().HasData(
                new
                {
                    Id = Convert.ToInt64(1), Name = "Пенсионеры"
                }, //15% discount if not in group for pensioners, otherwise - 40%
                new {Id = Convert.ToInt64(2), Name = "Студенты"}, //15% 
                new
                {
                    Id = Convert.ToInt64(3), Name = "Школьники"
                }, //15% discount if not in group for kids, otherwise - 20%
                new {Id = Convert.ToInt64(4), Name = "Корпоратив"}, //Don't know yet. Let it be just 15%
                new {Id = Convert.ToInt64(5), Name = "Без скидок"}
            );
            modelBuilder.Entity<Membership>().HasData(
                new Membership
                {
                    Id = Convert.ToInt64(10000), Name = "12 разовый абонемент в группу для пенсионеров (40% скидка)",
                    Price = 10000, AttendanceDays = 12, CategoryId = Convert.ToInt64(1)
                },
                new
                {
                    Id = Convert.ToInt64(10001), Name = "8 разовый абонемент в группу для пенсионеров (40% скидка)",
                    Price = 8000, AttendanceDays = 8, CategoryId = Convert.ToInt64(1)
                },
                new
                {
                    Id = Convert.ToInt64(10002), Name = "12 разовый абонемент с 15% скидкой для пенсионеров",
                    Price = 14000, AttendanceDays = 12, CategoryId = Convert.ToInt64(1)
                },
                new
                {
                    Id = Convert.ToInt64(10003), Name = "8 разовый абонемент с 15% скидкой для пенсионеров",
                    Price = 11000, AttendanceDays = 8, CategoryId = Convert.ToInt64(1)
                },
                new
                {
                    Id = Convert.ToInt64(10004), Name = "12 разовый абонемент с 15% скидкой для школьников",
                    Price = 14000, AttendanceDays = 12, CategoryId = Convert.ToInt64(3)
                },
                new
                {
                    Id = Convert.ToInt64(10005), Name = "8 разовый абонемент с 15% скидкой для школьников",
                    Price = 11000, AttendanceDays = 8, CategoryId = Convert.ToInt64(3)
                },
                new
                {
                    Id = Convert.ToInt64(10006), Name = "12 разовый абонемент с 15% скидкой для студентов",
                    Price = 14000, AttendanceDays = 12, CategoryId = Convert.ToInt64(2)
                },
                new
                {
                    Id = Convert.ToInt64(10007), Name = "8 разовый абонемент с 15% скидкой для студентов",
                    Price = 11000, AttendanceDays = 8, CategoryId = Convert.ToInt64(2)
                },
                new
                {
                    Id = Convert.ToInt64(10008), Name = "12 разовый абонемент с 15% скидкой для корпоративных клиентов",
                    Price = 14000, AttendanceDays = 12, CategoryId = Convert.ToInt64(4)
                },
                new
                {
                    Id = Convert.ToInt64(10009), Name = "8 разовый абонемент с 15% скидкой для корпоративных клиентов",
                    Price = 11000, AttendanceDays = 8, CategoryId = Convert.ToInt64(4)
                },
                new
                {
                    Id = Convert.ToInt64(10010), Name = "12 разовый абонемент в детскую группу (20% скидка)",
                    Price = 13000, AttendanceDays = 12, CategoryId = Convert.ToInt64(3)
                },
                new
                {
                    Id = Convert.ToInt64(10011), Name = "8 разовый абонемент в детскую группу (20% скидка)",
                    Price = 10500, AttendanceDays = 8, CategoryId = Convert.ToInt64(3)
                },
                new
                {
                    Id = Convert.ToInt64(10012), Name = "12 разовый абонемент обычный",
                    Price = 16000, AttendanceDays = 12, CategoryId = Convert.ToInt64(5)
                },
                new
                {
                    Id = Convert.ToInt64(10013), Name = "8 разовый абонемент обычный",
                    Price = 13000, AttendanceDays = 8, CategoryId = Convert.ToInt64(5)
                },
                new
                {
                    Id = Convert.ToInt64(10014), Name = "4 разовый абонемент",
                    Price = 8000, AttendanceDays = 4, CategoryId = Convert.ToInt64(5)
                },
                new
                {
                    Id = Convert.ToInt64(10015), Name = "1 разовый абонемент",
                    Price = 2500, AttendanceDays = 1, CategoryId = Convert.ToInt64(5)
                }
            );
            
            modelBuilder.Entity<Sickness>().HasData(
                new Sickness {Id = Convert.ToInt64(10000), Name = "здоров"},
                new Sickness {Id = Convert.ToInt64(10001), Name = "остеохондроз"},
                new Sickness {Id = Convert.ToInt64(10002), Name = "грыжа"},
                new Sickness {Id = Convert.ToInt64(10003), Name = "сколиоз"},
                new Sickness {Id = Convert.ToInt64(10004), Name = "артрит"},
                new Sickness {Id = Convert.ToInt64(10005), Name = "гипертония"},
                new Sickness {Id = Convert.ToInt64(10006), Name = "сахарный диабет"},
                new Sickness {Id = Convert.ToInt64(10007), Name = "сердечная недостаточность"},
                new Sickness {Id = Convert.ToInt64(10008), Name = "лишний вес"}
            );
        }
    }
}