using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Models;

namespace RestarauntWebApp.Infrastructure
{
    public static class HelperDTO
    {
        //Service => ServiceDTO
        public static ServiceDTO TransformService(Service entity)
        {
            ServiceDTO entityDTO = new()
            {
                Id = entity.Id,
                CategoryName = entity.ServiceCategory?.Title,
                Title = entity.Title,
                DescriptionShort = entity.DescriptionShort,
                Description = entity.Description,
                PhotoFileName = entity.Photo,
                Type = entity.Type.ToString()
            };

            return entityDTO;
        }

        public static IEnumerable<ServiceDTO> TransformServices(IEnumerable<Service> entities)
        {
            List<ServiceDTO> entitiesDTO = new List<ServiceDTO>();

            foreach (var entity in entities)
            {
                entitiesDTO.Add(TransformService(entity));
            }

            return entitiesDTO;
        }
    }
}
