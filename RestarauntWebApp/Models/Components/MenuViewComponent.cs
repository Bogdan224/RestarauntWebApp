using Microsoft.AspNetCore.Mvc;
using RestarauntWebApp.Domain;
using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Infrastructure;

namespace RestarauntWebApp.Models.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;

        public MenuViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _dataManager.Services.GetServicesAsync();

            var listDTO = HelperDTO.TransformServices(list);

            return await Task.FromResult((IViewComponentResult)View("Default", listDTO));
        }
    }
}
