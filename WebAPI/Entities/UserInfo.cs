using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities {
    public class UserInfo {
        [Key]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public List<ToDoList> ToDoLists { get; set; }
    }
}
