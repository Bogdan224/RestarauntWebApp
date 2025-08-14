using RestarauntWebApp.Infrastructure;

namespace RestarauntWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //���������� � ������������ ���� appsettings.json
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //����������� ������ Project � ��������� ����� ��� ��������
            IConfiguration configuration = configurationBuilder.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            //���������� ���������� ������������
            builder.Services.AddControllersWithViews();

            //�������� ������������
            var app = builder.Build();

            //! ������� ���������� middleware ����� �����, ��� ����� ���������� �������� ����

            //���������� ������������� ����������� ������(css, js, html � �.�.)
            app.UseStaticFiles();

            //���������� ������� �������������
            app.UseRouting();

            //������������ ������ ��� ��������
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}
