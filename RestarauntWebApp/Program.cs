using RestarauntWebApp.Infrastructure;

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

            //Подключаем функционал контроллеров
            builder.Services.AddControllersWithViews();

            //Собираем конфигурацию
            var app = builder.Build();

            //! Порядок следования middleware очень важен, они будут выполнятся согласно нему

            //Подключаем использование статических файлов(css, js, html и т.д.)
            app.UseStaticFiles();

            //Подключаем систему маршрутизации
            app.UseRouting();

            //Регистрируем нужные нам маршруты
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}
