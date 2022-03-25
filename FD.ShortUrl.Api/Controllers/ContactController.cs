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
    public class ContactController : ControllerBase
    {
        private readonly ContactDb _context;

        public ContactController(ContactDb context)
        {
            _context = context;         
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetItems()
        {
            return await _context.Contacts                
                .ToListAsync();
        }
        
        [HttpGet("{id}")]       
        public async Task<ActionResult<Contact>> GetItem(int id)
        {
            var item = await _context.Contacts.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        } 

        [HttpPost]       
        public async Task<ActionResult<Contact>> PostItem([FromBody] Contact contact)
        {                                  
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetItem), new { id = contact.Id }, contact);
        }       
    }
}
