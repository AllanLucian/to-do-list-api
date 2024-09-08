using to_do_list_api.Models;

namespace to_do_list_api.Repository.Interface;

public interface ITodoItemRepository
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(Guid id);
    Task<TodoItem> CreateAsync(TodoItem todoItem);
    Task<TodoItem?> UpdateAsync(Guid id, TodoItem todoItem);
    Task<bool> DeleteAsync(Guid id);
}
