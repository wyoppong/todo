using System;
using System.ComponentModel.DataAnnotations;

namespace toDo.Models
{
    public class NewTodoItem 
    {
        [Required]
        public string Title { get; set; }
    }
}