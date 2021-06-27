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
    }
}