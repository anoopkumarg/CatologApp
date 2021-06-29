using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repository
{
    public class MongoDbItemsRepo : IItemRepoInterface
    {
        private readonly IMongoCollection<Item> itemsColletion;
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        public MongoDbItemsRepo(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsColletion = database.GetCollection<Item>(collectionName);
        }

        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}