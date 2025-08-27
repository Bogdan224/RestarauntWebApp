using Microsoft.AspNetCore.Mvc;
using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ToppingsEdit(int id)
        {
            //В зависимости от наличия ID либо добавляем либо изменяем запись
            Topping? entity = id == default
                ? new Topping()
                : await _dataManager.Toppings.GetToppingByIdAsync(id);
            ViewBag.Dishes = await _dataManager.Dishes.GetDishesAsync();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ToppingsEdit(Topping entity)
        {
            //В модели присутствуют ошибки, возвращем на доработку
            if (!ModelState.IsValid)
            {
                ViewBag.Dishes = await _dataManager.Dishes.GetDishesAsync();
                return View(entity);
            }

            await _dataManager.Toppings.SaveToppingAsync(entity);
            _logger.LogInformation($"Добавлен/обновлен ингредиент с ID: {entity.Id}");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ToppingsDelete(int id)
        {
            //Т.к. в целях безопасности отключено каскадное удаление, то прежде чем удалить категорию, убедитесь,
            //что на нее нет ссылки ни у одной из услуг
            await _dataManager.Toppings.DeleteToppingAsync(id);
            _logger.LogInformation($"Удален ингредиент с ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
