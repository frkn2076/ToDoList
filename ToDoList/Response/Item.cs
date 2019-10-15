using Newtonsoft.Json;
using System;
namespace ToDoList.Response {
    public class Item {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("deadLine")]
        public DateTime DeadLine { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }
    }
}
