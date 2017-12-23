using System.Collections.Generic;

namespace toDo.Models
{
    public class toDoViewModel
    {
        public IEnumerable<toDoItem> Items { get; set; }
    }
}