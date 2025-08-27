using Microsoft.EntityFrameworkCore;
using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Domain.Repositories.Abstract;

namespace RestarauntWebApp.Domain.Repositories.EntityFramework
{
    public class EfToppingsRepository : IToppingsRepository
    {
        private readonly AppDbContext _context;
        public EfToppingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topping>> GetToppingsAsync()
        {
            return await _context.Toppings.ToListAsync();
        }

        public async Task<Topping?> GetToppingByIdAsync(int id)
        {
            return await _context.Toppings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveToppingAsync(Topping entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteToppingAsync(int id)
        {
            _context.Entry(new Topping() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
