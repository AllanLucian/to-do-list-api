using Microsoft.EntityFrameworkCore;
using to_do_list_api.Models;

namespace to_do_list_api.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
          modelBuilder.Entity<TodoItem>(entity =>
          {
               entity.ToTable("TodoItem"); 
               entity.HasKey(e => e.Id); 
               entity.Property(e => e.Name).IsRequired();
               entity.Property(e => e.IsComplete).IsRequired(); 
          }); 
     }
}
