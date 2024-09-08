using Microsoft.EntityFrameworkCore;
using to_do_list_api.Data;
using to_do_list_api.Repository;
using to_do_list_api.Repository.Interface;
using to_do_list_api.Service;
using to_do_list_api.Service.Interface;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Lista de Tarefas", Version = "v1" });
});

// Configurar o serviço de banco de dados SQL Server
builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TodoDatabaseConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoItems");
    });

}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
