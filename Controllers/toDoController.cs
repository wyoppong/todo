using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using toDo.Services;
using toDo.Models;
using Microsoft.AspNetCore.Identity;

namespace toDo.Controllers
{
    [Authorize]
    public class toDoController : Controller
    {
        private readonly ItoDo _itodo;
        private readonly UserManager<ApplicationUser> _userManager;
        public toDoController (ItoDo itodo, UserManager<ApplicationUser> userManager)
        {
            _itodo = itodo;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var toDoItems = await _itodo.GetIncompleteItemAsync(currentUser);

            var model = new toDoViewModel()
            {
                Items = toDoItems
            };

            return View(model);
        }

        public async Task<IActionResult> AddItem(NewTodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();
            var successful = await _itodo.AddItemAsync(newItem, currentUser);

            if (!successful)
            {
                return BadRequest(new {error = "could not add item"});
            }

            return Ok();
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var successful = await _itodo.MarkDoneAsync(id, currentUser);

            if (!successful) return BadRequest();

            return Ok();
        }

    }
}