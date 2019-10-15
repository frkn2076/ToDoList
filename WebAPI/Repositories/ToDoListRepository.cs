using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;

namespace WebAPI.Repositories {
    public class ToDoListRepository : IToDoListRepository {

        private readonly AppDBContext context;

        public ToDoListRepository(AppDBContext context) {
            this.context = context;
        }
        public IEnumerable<ToDoList> GetToDoLists() {
            return context.ToDoList.Include(toDoList => toDoList.Items).ToList();
        }
        public ToDoList GetToDoListById(int id) {
            return context.ToDoList.Include(toDoList => toDoList.Items).FirstOrDefault(x => x.Id == id);
        }
        public void InsertToDoList(ToDoList toDoList) {
            context.ToDoList.Add(toDoList);
        }
        public void DeleteToDoList(int id) {
            ToDoList toDoList = context.ToDoList.Include(x => x.Items).FirstOrDefault(y => y.Id == id);
            context.ToDoList.Remove(toDoList);
        }
        public void UpdateToDoList(ToDoList toDoList) {
            var toDoListToUpdate = context.ToDoList.Include(x => x.Items).FirstOrDefault(y => y.Id == toDoList.Id);
            toDoListToUpdate.Name = toDoList.Name;
            toDoListToUpdate.CreateDate = toDoList.CreateDate;
            toDoListToUpdate.Items = toDoList.Items;
            context.ToDoList.Update(toDoListToUpdate);
        }
        public void Save() {
            context.SaveChanges();
        }
    }
}
