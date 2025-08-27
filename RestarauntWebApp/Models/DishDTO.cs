using RestarauntWebApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestarauntWebApp.Models
{
    public class DishDTO
    {
        public int? Id { get; set; }
        public int? Weight { get; set; }
        public int? Price { get; set; }
        public string? CategoryName { get; set; }
        public IEnumerable<ToppingDTO>? ToppingsDTO { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhotoFileName { get; set; }
    }

    public class ToppingDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
    }
}
