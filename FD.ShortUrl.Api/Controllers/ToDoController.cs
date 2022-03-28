using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TodoDb _context;

        public ToDoController(TodoDb context)
        {
            _context = context;         
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        [HttpPatch]
        public IActionResult JsonPatchWithModelState(
    [FromBody] JsonPatchDocument<TodoItemDTO> patchDoc)
        {
            if (patchDoc != null)
            {
                var customer = new TodoItemDTO();
                patchDoc.ApplyTo(customer, ModelState);
               
                return new ObjectResult(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(todoItem);
        }



        //[HttpGet("{id}")]
        //public IActionResult GetTodoItem(int id)
        //{
        //    var todoItem = _context.TodoItems.Find(id);

        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(todoItem);
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<TodoItemDTO> GetTodoItem(int id)
        //{
        //    var todoItem = _context.TodoItems.Find(id);

        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return ItemToDTO(todoItem);
        //}


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem([FromBody]TodoItemDTO todoItemDTO)
        {
            if (todoItemDTO.Name.Contains("bad"))
            {
                return BadRequest();
            }            
            
            var todoItem = new Todo
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name,
                Desc = todoItemDTO.Desc,
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }



        private static TodoItemDTO ItemToDTO(Todo todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}
