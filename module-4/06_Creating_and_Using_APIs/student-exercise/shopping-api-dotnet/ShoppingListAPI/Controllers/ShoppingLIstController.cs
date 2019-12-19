using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers
{
    [Route("api/groceries")]
    [ApiController]
    public class ShoppingLIstController : ControllerBase
    {
        private readonly IDataAccessLayer<Item> dal;

        public ShoppingLIstController(IDataAccessLayer<Item> dataAccessLayer)
        {
            dal = dataAccessLayer;
        }

        [HttpGet]
        public List<Item> GetAll()
        {
            return dal.GetAll();
        }

        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = dal.Get(id);

            if ( item != null )
            {
                return item;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Item item)
        {
            dal.Add(item);

            return CreatedAtRoute("GetItem,", new { id = item.Id }, item);
            
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, Item updatedItem)
        {
            var existingItem = dal.Get(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.name = updatedItem.name;
            existingItem.Id = updatedItem.Id;
            existingItem.completed = updatedItem.completed;

            dal.Update(existingItem);

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = dal.Get(id);

            if (item == null)
            {

                return NotFound();
            }
            dal.Delete(id);

            return NoContent();
        }
    }
}