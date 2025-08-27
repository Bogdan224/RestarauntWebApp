using System.ComponentModel.DataAnnotations;

namespace RestarauntWebApp.Domain.Entities
{
    public class Dish : EntityBase
    {
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Вес")]
        public int Weight { get; set; }
        [Display(Name = "Описание")]
        [MaxLength(3000)]
        public string? Description { get; set; }
        [Display(Name = "Фото")]
        public string? Photo { get; set; }

        public int DishCategoryId { get; set; }
        public DishCategory? DishCategory { get; set; }

        public ICollection<int>? ToppingsIds { get; set; }
    }
}
