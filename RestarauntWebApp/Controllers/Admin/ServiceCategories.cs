using Microsoft.AspNetCore.Mvc;
using RestarauntWebApp.Domain;
using RestarauntWebApp.Domain.Entities;

namespace RestarauntWebApp.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id)
        {
            //В зависимости от наличия ID либо добавляем либо изменяем запись
            ServiceCategory? entity = id == default
                ? new ServiceCategory()
                : await _dataManager.ServiceCategories.GetServiceCategoryByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
        {
            //В модели присутствуют ошибки, возвращем на доработку
            if (!ModelState.IsValid)
                return View(entity);

            await _dataManager.ServiceCategories.SaveServiceCategoryAsync(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id)
        {
            //Т.к. в целях безопасности отключено каскадное удаление, то прежде чем удалить категорию, убедитесь,
            //что на нее нет ссылки ни у одной из услуг
            await _dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
