using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities {
    public class Item {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
