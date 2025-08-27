using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Domain.Repositories.Abstract
{
    public interface IDishesRepository
    {
        Task<IEnumerable<Dish>> GetDishesAsync();
        Task<Dish?> GetDishByIdAsync(int id);
        Task SaveDishAsync(Dish entity);
        Task DeleteDishAsync(int id);
    }
}
