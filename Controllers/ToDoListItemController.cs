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
        [SwaggerResponse(201, "Successfully added the To-Do list item", typeof(ToDoListItem))]
        public ActionResult Add(int listId, ToDoListItem item)
        {
            // make sure listID increments correctly
            // maybe make space for items
            // maybe implement priority
            _container.Add(item, listId);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpGet("{id}/{listId}")]
        [SwaggerOperation(Summary = "Get a To-Do list item by list ID and item ID", Description = "Retrieves a specific To-Do list item by its list and item ID.")]
        [SwaggerResponse(200, "Successfully retrieved the To-Do list item", typeof(ToDoListItem))]
        [SwaggerResponse(404, "To-Do list item not found")]
        public ActionResult<ToDoListItem> Get(int id, int listId)
        {
            var item = _container.GetByList_Item_Id(id, listId);
            if (item == null) return NotFound();
            return Ok(item);
        }


        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a To-Do list item", Description = "Updates a specific To-Do list item.")]
        [SwaggerResponse(204, "Successfully updated the To-Do list item")]
        [SwaggerResponse(400, "Invalid ID supplied")]
        public ActionResult Update(int id, ToDoListItem item)
        {
            // make items completed
            if (id != item.Id) return BadRequest();
            _container.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}/{listId}")]
        [SwaggerOperation(Summary = "Delete a To-Do list item", Description = "Deletes a specific To-Do list item by its ID.")]
        [SwaggerResponse(204, "Successfully deleted the To-Do list item")]
        [SwaggerResponse(404, "To-Do list item not found")]
        public ActionResult Delete(int id, int listId)
        {

            _container.Delete(id, listId);
            return NoContent();
        }
    }
}