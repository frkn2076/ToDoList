using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;

namespace WebAPI.Repositories {
    public class ItemRepository : IItemRepository {

        private readonly AppDBContext context;

        public ItemRepository(AppDBContext context) {
            this.context = context;
        }
        public IEnumerable<Item> GetItems() {
            return context.Item.ToList();
        }
        public Item GetItemById(int id) {
            return context.Item.Find(id);
        }
        public void InsertItem(Item item) {
            context.Item.Add(item);
        }
        public void DeleteItem(int id) {
            Item item = context.Item.Find(id);
            context.Item.Remove(item);
        }
        public void UpdateItem(Item item) {
            var itemToUpdate = context.Item.Find(item.Id);
            itemToUpdate.Name = item.Name;
            itemToUpdate.Description = item.Description;
            itemToUpdate.DeadLine = item.DeadLine;
            itemToUpdate.Status = item.Status;
            itemToUpdate.CreateDate = item.CreateDate;
            context.Item.Update(itemToUpdate);
        }
        public void Save() {
            context.SaveChanges();
        }
    }
}
