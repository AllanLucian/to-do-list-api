using to_do_list_api.Models;
using to_do_list_api.Repository.Interface;
using to_do_list_api.Service.Interface;

namespace to_do_list_api.Service;

public class TodoItemService : ITodoItemService
{
    private ITodoItemRepository _todoItemRepository;

    public TodoItemService(ITodoItemRepository itemRepository)
    {
        _todoItemRepository = itemRepository;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
       return await _todoItemRepository.GetAllAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(Guid Id)
    {
        return await _todoItemRepository.GetByIdAsync(Id);
    }

    public async Task<TodoItem> CreateAsync(TodoItem todoItem)
    {
        return await _todoItemRepository.CreateAsync(todoItem);
    }

    public async Task<TodoItem?> UpdateAsync(Guid id, TodoItem todoItem)
    {
        return await _todoItemRepository.UpdateAsync(id, todoItem);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _todoItemRepository.DeleteAsync(id);
    }
}
