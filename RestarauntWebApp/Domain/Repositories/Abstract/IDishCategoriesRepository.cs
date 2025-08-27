using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Domain.Repositories.Abstract
{
    public interface IDishCategoriesRepository
    {
        Task<IEnumerable<DishCategory>> GetDishCategoriesAsync();
        Task<DishCategory?> GetDishCategoryByIdAsync(int id);
        Task SaveDishCategoryAsync(DishCategory entity);
        Task DeleteDishCategoryAsync(int id);
    }
}
