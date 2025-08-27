using Microsoft.AspNetCore.Mvc;
using RestarauntWebApp.Domain;
using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> DishCategoriesEdit(int id)
        {
            //В зависимости от наличия ID либо добавляем либо изменяем запись
            DishCategory? entity = id == default
                ? new DishCategory()
                : await _dataManager.DishCategories.GetDishCategoryByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> DishCategoriesEdit(DishCategory entity)
        {
            //В модели присутствуют ошибки, возвращем на доработку
            if (!ModelState.IsValid)
                return View(entity);

            await _dataManager.DishCategories.SaveDishCategoryAsync(entity);
            _logger.LogInformation($"Добавлена/обновлена категория блюда с ID: {entity.Id}");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DishCategoriesDelete(int id)
        {
            //Т.к. в целях безопасности отключено каскадное удаление, то прежде чем удалить категорию, убедитесь,
            //что на нее нет ссылки ни у одной из услуг
            await _dataManager.DishCategories.DeleteDishCategoryAsync(id);
            _logger.LogInformation($"Удвлена категория блюда с ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
