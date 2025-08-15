using RestarauntWebApp.Domain.Repositories.Abstract;

namespace RestarauntWebApp.Domain
{
    public class DataManager
    {
        public IServiceCategoriesRepository ServiceCategories { get; set; }
        public IServicesRepository Services { get; set; }

        public DataManager(IServiceCategoriesRepository serviceCategoriesRepository,
            IServicesRepository servicesRepository)
        {
            ServiceCategories = serviceCategoriesRepository;
            Services = servicesRepository;
        }
    }
}
