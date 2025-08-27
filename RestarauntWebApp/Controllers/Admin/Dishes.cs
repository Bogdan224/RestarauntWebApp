using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> DishesEdit(int id)
        {
            //В зависимости от наличия ID либо добавляем либо изменяем запись
            Dish? entity = id == default
                ? new Dish()
                : await _dataManager.Dishes.GetDishByIdAsync(id);
            ViewBag.DishCategories = await _dataManager.DishCategories.GetDishCategoriesAsync();
            ViewBag.Toppings = await _dataManager.Toppings.GetToppingsAsync();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> DishesEdit(Dish entity, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DishCategories = await _dataManager.DishCategories.GetDishCategoriesAsync();
                ViewBag.Toppings = await _dataManager.Toppings.GetToppingsAsync();
                return View(entity);
            }

            if (titleImageFile != null)
            {
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await _dataManager.Dishes.SaveDishAsync(entity);
            _logger.LogInformation($"Добавлено/обновлено блюдл с ID: {entity.Id}");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DishesDelete(int id)
        {
            await _dataManager.Dishes.DeleteDishAsync(id);
            _logger.LogInformation($"Удалено блюдо с ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
