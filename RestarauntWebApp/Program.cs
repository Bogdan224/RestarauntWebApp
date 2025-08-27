using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestarauntWebApp.Domain;
using RestarauntWebApp.Domain.Repositories.Abstract;
using RestarauntWebApp.Domain.Repositories.EntityFramework;
using RestarauntWebApp.Infrastructure;
using Serilog;

namespace RestarauntWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Подключаем в конфигурацию файл appsettings.json
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //Оборачиваем секцию Project в объектную форму для удобства
            IConfiguration configuration = configurationBuilder.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            //Подключаем контекст БД
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.Database.ConnectionString)
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

            builder.Services.AddTransient<IDishesRepository, EfDishesRepository>();
            builder.Services.AddTransient<IDishCategoriesRepository, EfDishCategoriesRepository>();
            builder.Services.AddTransient<IToppingsRepository, EfToppingsRepository>();
            builder.Services.AddTransient<DataManager>();

            //Настраиваем Identity систему
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //Настраиваем Auth cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });

            //Подключаем функционал контроллеров
            builder.Services.AddControllersWithViews();

            //Подключаем логи
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            //Собираем конфигурацию
            var app = builder.Build();
            
            //Подключаем логирование
            app.UseSerilogRequestLogging();

            //Далее подключаем обработку исключений
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Подключаем использование статических файлов(css, js, html и т.д.)
            app.UseStaticFiles();

            //Подключаем систему маршрутизации
            app.UseRouting();

            //Подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //Регистрируем нужные нам маршруты
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}
