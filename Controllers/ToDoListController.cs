using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using ToDoListApi.Abstractions;
using ToDoListApi.Containers;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListContainer _container;

        public ToDoListController(IToDoListContainer container)
        {
            _container = container;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all To-Do lists", Description = "Retrieves all To-Do lists for the user.")]
        [SwaggerResponse(200, "Successfully retrieved the list of To-Do lists", typeof(IEnumerable<ToDoList>))]
        public ActionResult<IEnumerable<ToDoList>> Get() => Ok(_container.GetAll());


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a To-Do list by ID", Description = "Retrieves a specific To-Do list by its ID.")]
        [SwaggerResponse(200, "Successfully retrieved the To-Do list", typeof(ToDoList))]
        [SwaggerResponse(404, "To-Do list not found")]
        public ActionResult<ToDoList> Get(int id)
        {
            var list = _container.GetByList_Id(id);
            if (list == null) return NotFound();
            return Ok(list);
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Create a new To-Do list", Description = "Creates a new To-Do list.")]
        [SwaggerResponse(201, "Successfully created the To-Do list", typeof(ToDoList))]
        public ActionResult Add(ToDoList list)
        {
            // maybe add a title to the list
            _container.Add(list);
            return CreatedAtAction(nameof(Get), new { id = list.Id }, list);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing To-Do list", Description = "Updates an existing To-Do list.")]
        [SwaggerResponse(204, "Successfully updated the To-Do list")]
        [SwaggerResponse(400, "Invalid ID supplied")]
        public ActionResult Update(int id, ToDoList list)
        {
            if (id != list.Id) return BadRequest();
            _container.Update(list);
            return Ok(_container.GetByList_Id(id));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a To-Do list", Description = "Deletes a specific To-Do list by its ID.")]
        [SwaggerResponse(204, "Successfully deleted the To-Do list")]
        [SwaggerResponse(404, "To-Do list not found")]
        public ActionResult Delete(int id)
        {
            _container.Delete(id);
            return Ok(_container.GetAll());
        }
    }
}
