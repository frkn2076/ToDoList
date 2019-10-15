using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ToDoList.Response {
    public class ToDo {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
