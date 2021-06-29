using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repository
{
    public class InMemeItemRepo: IItemRepoInterface
    {
        private readonly List<Item> items = new List<Item>()
        {
           new Item(){Id = Guid.NewGuid(), Name = "Rally Seat", Price = 2000, CreatedDate = DateTimeOffset.UtcNow},
           new Item(){Id = Guid.NewGuid(), Name = "Center Stand", Price = 800, CreatedDate = DateTimeOffset.UtcNow},
           new Item(){Id = Guid.NewGuid(), Name = "Handle Bar Raiser", Price = 2400, CreatedDate = DateTimeOffset.UtcNow},
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}