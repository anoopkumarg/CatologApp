using Microsoft.AspNetCore.Mvc;
using Catalog.Repository;
using System.Collections.Generic;
using Catalog.Entities;
using System;
using Catalog.DTOs;
using System.Linq;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController: ControllerBase
    {
        private readonly IItemRepoInterface repo;
        public ItemsController(IItemRepoInterface repository)
        {
            this.repo = repository;
        }
        [HttpGet]
        public  IEnumerable<ItemDto> GetItems(){
            return repo.GetItems().Select(item => item.AsDto());
        }
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item = repo.GetItem(id);
            if(item is null) {
              return NotFound();
            }
            return item.AsDto();
        }
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            
            };
            repo.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDTo){
            Item existingItem = repo.GetItem(id);
            if( existingItem is null){
                return NotFound();
            }
            Item updatedItem = new Item()
            {
                Id = existingItem.Id,
                CreatedDate = existingItem.CreatedDate,
                Name = itemDTo.Name,
                Price = itemDTo.Price
            };
            repo.UpdateItem(updatedItem);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
            Item existingItem = repo.GetItem(id);
            if( existingItem is null){
                return NotFound();
            }
            repo.DeleteItem(id);
            return Ok();
        }
    }
}