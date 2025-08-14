namespace RestarauntWebApp.Infrastructure
{
    public class AppConfig
    {
        public TinyMCE TinyMce { get; set; } = new TinyMCE();
        public Company Company { get; set; } = new Company();
    }

    public class TinyMCE
    {
        public string? APIKey { get; set; }
    }

    public class Company
    { 
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? PhoneShort { get; set; }
        public string? Email { get; set; }
    }
}
