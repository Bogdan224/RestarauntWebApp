namespace RestarauntWebApp.Domain.Entities
{
    public class DishCategory : EntityBase
    {
        public ICollection<Dish>? Dishes { get; set; }
    }
}
