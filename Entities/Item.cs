using System;

namespace Catalog.Entities
{
    public class Item
    {
        public Guid Id {get; set;}
        public String Name {get; set;}
        public decimal Price {get; set;}
        public DateTimeOffset CreatedDate {get; set;}
        
    }
}