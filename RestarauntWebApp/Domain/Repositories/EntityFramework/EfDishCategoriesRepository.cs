using Microsoft.EntityFrameworkCore;
using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Domain.Repositories.Abstract;

namespace RestarauntWebApp.Domain.Repositories.EntityFramework
{
    public class EfDishCategoriesRepository : IDishCategoriesRepository
    {
        private readonly AppDbContext _context;

        public EfDishCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DishCategory>> GetDishCategoriesAsync()
        {
            return await _context.DishCategories.Include(x => x.Dishes).ToListAsync();
        }

        public async Task<DishCategory?> GetDishCategoryByIdAsync(int id)
        {
            return await _context.DishCategories.Include(x => x.Dishes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveDishCategoryAsync(DishCategory entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDishCategoryAsync(int id)
        {
            _context.Entry(new DishCategory() {Id = id}).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
