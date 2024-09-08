using System;

namespace to_do_list_api.Models;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}