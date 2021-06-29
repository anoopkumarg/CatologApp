using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs
{
    public class UpdateItemDto
    {
        [Required]
        public string Name {get; set;}
        [Required]
        [Range(1, 1000*100)]
        public decimal Price {get; set;}
    }
}