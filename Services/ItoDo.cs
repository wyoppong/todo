using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using toDo.Models;

namespace toDo.Services
{
    public interface ItoDo
    {
        Task<IEnumerable<toDoItem>> GetIncompleteItemAsync(ApplicationUser user);
        Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser user);
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
    }
}