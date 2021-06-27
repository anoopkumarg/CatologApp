using System;

namespace Catalog.DTOs
{
    public class ItemDto
    {
        public Guid Id {get; set;}
        public String Name {get; set;}
        public decimal Price {get; set;}
        public DateTimeOffset CreatedDate {get; set;}
    }
}