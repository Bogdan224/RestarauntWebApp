using RestarauntWebApp.Domain.Repositories.Abstract;

namespace RestarauntWebApp.Domain
{
    public class DataManager
    {
        public IDishCategoriesRepository DishCategories { get; set; }
        public IDishesRepository Dishes { get; set; }
        public IToppingsRepository Toppings { get; set; }

        public DataManager(IDishCategoriesRepository dishCategoriesRepository,
            IDishesRepository dishRepository, 
            IToppingsRepository toppings)
        {
            DishCategories = dishCategoriesRepository;
            Dishes = dishRepository;
            Toppings = toppings;
        }
    }
}
