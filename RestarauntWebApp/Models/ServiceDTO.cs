using RestarauntWebApp.Domain.Entities;
using RestarauntWebApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestarauntWebApp.Models
{
    public class ServiceDTO
    {
        public int? Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Title { get; set; }
        public string? DescriptionShort { get; set; }
        public string? Description { get; set; }
        public string? PhotoFileName { get; set; }
        public string? Type { get; set; }
    }
}
