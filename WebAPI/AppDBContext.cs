using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI {
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
