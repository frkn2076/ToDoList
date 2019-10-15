using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Response {
    public class UserInfo {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("toDoLists")]
        public List<ToDo> ToDoLists { get; set; }
    }
}
