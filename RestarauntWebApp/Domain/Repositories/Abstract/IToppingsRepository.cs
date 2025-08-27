using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Domain.Repositories.Abstract
{
    public interface IToppingsRepository
    {
        Task<IEnumerable<Topping>> GetToppingsAsync();
        Task<Topping?> GetToppingByIdAsync(int id);
        Task SaveToppingAsync(Topping entity);
        Task DeleteToppingAsync(int id);
    }
}
