using RestarauntWebApp.Domain;
using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Models;

namespace RestarauntWebApp.Infrastructure
{
    public static class HelperDTO
    {
        //Service => ServiceDTO
        public static DishDTO TransformDish(Dish entity, DataManager dataManager)
        {
            DishDTO entityDTO = new()
            {
                Id = entity.Id,
                CategoryName = entity.DishCategory?.Name,
                Name = entity.Name,
                Description = entity.Description,
                PhotoFileName = entity.Photo,
                Price = entity.Price,
                Weight = entity.Weight
            };
            if (entity.ToppingsIds != null)
            {
                entityDTO.ToppingsDTO = TransformToppings(entity.ToppingsIds, dataManager);
            }

            return entityDTO;
        }

        public static IEnumerable<DishDTO> TransformDishes(IEnumerable<Dish> entities, DataManager dataManager)
        {
            List<DishDTO> entitiesDTO = new List<DishDTO>();

            foreach (var entity in entities)
            {
                entitiesDTO.Add(TransformDish(entity, dataManager));
            }

            return entitiesDTO;
        }

        public static ToppingDTO TransformTopping(int id, DataManager dataManager)
        {
            var entity = dataManager.Toppings.GetToppingByIdAsync(id).Result!;

            ToppingDTO entityDTO = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };

            return entityDTO;
        }

        public static IEnumerable<ToppingDTO> TransformToppings(IEnumerable<int> entities, DataManager dataManager)
        {
            List<ToppingDTO> entitiesDTO = new List<ToppingDTO>();

            foreach (var topping in entities)
            {
                if(topping >= 0)
                    entitiesDTO.Add(TransformTopping(topping, dataManager));
            }
            return entitiesDTO;
        }

    }
}
