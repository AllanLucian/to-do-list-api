using Microsoft.EntityFrameworkCore;
using to_do_list_api.Data;
using to_do_list_api.Models;
using to_do_list_api.Repository.Interface;

namespace to_do_list_api.Repository;

public class TodoItemRepository : ITodoItemRepository
{
    private TodoDbContext _dbContext;

    public TodoItemRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
       return await _dbContext.Set<TodoItem>().ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<TodoItem>().FindAsync(id);
    }

    public async Task<TodoItem> CreateAsync(TodoItem todoItem)
    {
        _dbContext.Set<TodoItem>().Add(todoItem);
        await _dbContext.SaveChangesAsync();
        return todoItem;
    }

    public async Task<TodoItem?> UpdateAsync(Guid id, TodoItem todoItem)
    {
        var item = _dbContext.Set<TodoItem>().FirstOrDefault(t => t.Id == id);

        item.Name = todoItem.Name;
        item.IsComplete = todoItem.IsComplete;
        
        await _dbContext.SaveChangesAsync();

        return _dbContext.Set<TodoItem>().FirstOrDefault(x => x.Id == id);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var todoItem = _dbContext.Set<TodoItem>().FirstOrDefault(p => p.Id == id);
        
        if (todoItem is not null)
        {
            _dbContext.Remove(todoItem);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}