using System;

namespace toDo.Models
{
    public class toDoItem
    {
        public Guid Id {get; set;}
        public bool IsDone { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }

        public string OwnerId { get; set; }
    }
}