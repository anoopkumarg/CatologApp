using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repository
{
    public class MongoDbItemsRepo : IItemRepoInterface
    {
        private readonly IMongoCollection<Item> itemsColletion;
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        public MongoDbItemsRepo(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsColletion = database.GetCollection<Item>(collectionName);
        }

        public void CreateItem(Item item)
        {
            itemsColletion.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            var filteredItem = filterBuilder.Eq(item => item.Id, id);
            itemsColletion.DeleteOne(filteredItem);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsColletion.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
           return itemsColletion.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            var filteredItem = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsColletion.ReplaceOne(filteredItem, item);
        }
    }
}