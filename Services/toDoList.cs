using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toDo.Data;
using toDo.Models;
using Microsoft.EntityFrameworkCore;


namespace toDo.Services
{
    public class toDoList : ItoDo
    {
        private readonly ApplicationDbContext _context;

        public toDoList(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<toDoItem>> GetIncompleteItemAsync(ApplicationUser user)
        {
            return await _context.Items
                .Where(x => x.IsDone == false && x.OwnerId == user.Id)
                .ToArrayAsync();

             
        }

        public async Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser user)
        {
            var entity = new toDoItem
            {
                Id = Guid.NewGuid(),
                OwnerId = user.Id,
                IsDone = false,
                Title = newItem.Title,
                DueAt = DateTimeOffset.Now.AddDays(3)
            };

            _context.Items.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id && x.OwnerId == user.Id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}