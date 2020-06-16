using MyTodoWebApp.Data;
using MyTodoWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using MyTodoWebApp.Services;
namespace MyTodoWebApp
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;
        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items
                    .Where(x=>x.IsDone == false)
                    .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem todoItem)
        {
            todoItem.Id= Guid.NewGuid();
            todoItem.IsDone =false;
            todoItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(todoItem);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }
    }
}