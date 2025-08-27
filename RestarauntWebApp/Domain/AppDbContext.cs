using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Domain
{
    //Контекст базы данных
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<DishCategory> DishCategories { get; set; } = null!;
        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Topping> Toppings { get; set; } = null!;

        //public AppDbContext(){}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            string adminName = "admin";
            string roleAdminId = "116217E2-D44E-4566-95AA-6678F980011D";
            string userAdminId = "660BAE6C-5635-4C8F-9D27-C58FBABA007A";

            //Добавляем роль администратора сайта
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });

            //Добавляем нового IdentityUser в качестве администратора сайта
            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), adminName),
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });

            //Определяем админа в соответсвующую роль
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = userAdminId
            });
        }
    }
}
