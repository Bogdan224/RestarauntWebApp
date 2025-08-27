using System.ComponentModel.DataAnnotations;

namespace RestarauntWebApp.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Название")]
        [MaxLength(200)]
        public string? Name { get; set; }
    }
}
