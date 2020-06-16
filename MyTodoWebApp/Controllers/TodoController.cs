using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTodoWebApp.Models;
using MyTodoWebApp.Services;

namespace MyTodoWebApp.Controllers
{
    public class TodoController : Controller
    {
        public readonly ITodoItemService _todoItemService;
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            //Get items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();

             
            //Put items into a model
            var model = new TodoViewModel
            {
                items = items
            };
            //Render view using a model
            return View(model);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
             var successful = await _todoItemService.AddItemAsync(newItem);
             if(!successful)
            {
                return BadRequest(new {error ="Could not add item"});               
            }
            return RedirectToAction("Index");
        }
    }
}