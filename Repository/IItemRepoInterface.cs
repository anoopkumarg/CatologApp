using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repository
{
    public interface IItemRepoInterface
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
    }
}