using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoListApi.Abstractions;
using ToDoListApi.Containers;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListItemController : ControllerBase
    {
        private readonly IToDoListItemContainer _container;

        public ToDoListItemController(IToDoListItemContainer container)
        {
            _container = container;
        }

        [HttpPost("{listId}")]
        [SwaggerOperation(Summary = "Add a new item to a To-Do list", Description = "Adds a new item to a specific To-Do list.")]
        public ActionResult Add(int listId, ToDoListItem item)
        {
            // maybe implement priority
            _container.Add(item, listId);

            // Returns the newly added item
            return CreatedAtAction(nameof(Get), new { id = item.Id, listId = listId }, item);
        }

        [HttpGet("{id}/{listId}")]
        [SwaggerOperation(Summary = "Get a To-Do list item by list ID and item ID", Description = "Retrieves a specific To-Do list item by its list and item ID.")]
        public ActionResult<ToDoListItem> Get(int id, int listId)
        {
            var item = _container.GetByList_Item_Id(id, listId);
            if (item == null) return BadRequest();

            // Returns the item
            return Ok(item);
        }


        [HttpPost("{id}/{listId}")]
        [SwaggerOperation(Summary = "Make a To-Do list item as complete", Description = "Complete a specific To-Do list item.")]
        public ActionResult Complete(int id, int listId)
        {
            var new_item = _container.Complete(id, listId);
            if (new_item == null) return BadRequest();

            // Returns the newly completed item
            return Ok(new_item);
        }

        [HttpPut("{id}/{listId}")]
        [SwaggerOperation(Summary = "Update a To-Do list item", Description = "Updates a specific To-Do list item by its list and item ID.")]
        public ActionResult Update(int id, ToDoListItem item, int listId)
        {
            var new_item = _container.Update(item, listId);
            if (new_item == null) return BadRequest();

            // Returns the newly updated item
            return Ok(new_item);
        }


        [HttpDelete("{id}/{listId}")]
        [SwaggerOperation(Summary = "Delete a To-Do list item", Description = "Deletes a specific To-Do list item by its ID and list ID.")]
        public ActionResult Delete(int id, int listId)
        {
            bool is_succssful = _container.Delete(id, listId);
            if (is_succssful) return NoContent();
            return BadRequest();
        }
    }
}