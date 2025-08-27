using Microsoft.AspNetCore.Mvc;
using RestarauntWebApp.Domain;
using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Infrastructure;
using RestarauntWebApp.Models;

namespace RestarauntWebApp.Controllers
{
    public class DishesController : Controller
    {
        private readonly DataManager _dataManager;

        public DishesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(HelperDTO.TransformDishes(await _dataManager.Dishes.GetDishesAsync(), _dataManager));
        }

        public async Task<IActionResult> Show(int id)
        {
            Dish? entity = await _dataManager.Dishes.GetDishByIdAsync(id);

            if (entity is null) return NotFound();

            return View(HelperDTO.TransformDish(entity, _dataManager));
        }
    }
}
