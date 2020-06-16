using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using MyTodoWebApp.Models;
namespace MyTodoWebApp.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(TodoItem todoItem);
        
    }
}