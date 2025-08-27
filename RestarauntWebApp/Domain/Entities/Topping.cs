using System.ComponentModel.DataAnnotations;

namespace RestarauntWebApp.Domain.Entities
{
    public class Topping : EntityBase
    {
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Цена")]
        public int Price { get; set; }
    }
}
