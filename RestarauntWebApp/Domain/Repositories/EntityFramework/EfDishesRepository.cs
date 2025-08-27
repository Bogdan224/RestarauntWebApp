using Microsoft.EntityFrameworkCore;
using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Domain.Repositories.Abstract;

namespace RestarauntWebApp.Domain.Repositories.EntityFramework
{
    public class EfDishesRepository : IDishesRepository
    {
        private readonly AppDbContext _context;
        public EfDishesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync()
        {
            return await _context.Dishes.Include(x=> x.DishCategory).ToListAsync();
        }

        public async Task<Dish?> GetDishByIdAsync(int id)
        {
            return await _context.Dishes.Include(x => x.DishCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveDishAsync(Dish entity)
        {
            _context.Entry(entity).State = entity.Id == default
                ? EntityState.Added
                : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDishAsync(int id)
        {
            _context.Entry(new Dish() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
