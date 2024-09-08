using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using to_do_list_api.Models;
using to_do_list_api.Service.Interface;

namespace to_do_list_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ILogger<TodoItemsController> _logger;
        private ITodoItemService _todoItemService;

        public TodoItemsController(ILogger<TodoItemsController> logger, ITodoItemService todoItemService)
        {
            _logger = logger;
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAllTodoItems()
        {
            return await _todoItemService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItemById(Guid id)
        {
            var todoItem = await _todoItemService.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todoItem)
        {
            return await _todoItemService.CreateAsync(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(Guid id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _todoItemService.UpdateAsync(id, todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var todoItem = await _todoItemService.GetByIdAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            await _todoItemService.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> TodoItemExists(Guid id)
        {
            return await _todoItemService.GetByIdAsync(id) != null ? true : false;
        }
    }
}