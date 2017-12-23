using System.Collections.Generic;
using toDo.Models;

namespace toDo
{
    public class ManageUsersViewModel
    {
        public IEnumerable<ApplicationUser> Administrators { get; set; }
        public IEnumerable<ApplicationUser> Everyone { get; set; }
        
    }
}