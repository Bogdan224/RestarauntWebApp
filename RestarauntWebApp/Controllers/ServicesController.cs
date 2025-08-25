using Microsoft.AspNetCore.Mvc;
using RestarauntWebApp.Domain;
using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Infrastructure;
using RestarauntWebApp.Models;

namespace RestarauntWebApp.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;

        public ServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(HelperDTO.TransformServices(await _dataManager.Services.GetServicesAsync()));
        }

        public async Task<IActionResult> Show(int id)
        {
            Service? entity = await _dataManager.Services.GetServiceByIdAsync(id);

            if (entity is null) return NotFound();

            return View(HelperDTO.TransformService(entity));
        }
    }
}
