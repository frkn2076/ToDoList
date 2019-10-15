using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Repositories {
    public interface IItemRepository {
        IEnumerable<Item> GetItems();
        Item GetItemById(int id);
        void InsertItem(Item item);
        void DeleteItem(int id);
        void UpdateItem(Item item);
        void Save();
    }
}
