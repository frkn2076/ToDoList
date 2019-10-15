using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Repositories {
    public interface IToDoListRepository {
        IEnumerable<ToDoList> GetToDoLists();
        ToDoList GetToDoListById(int id);
        void InsertToDoList(ToDoList toDoList);
        void DeleteToDoList(int id);
        void UpdateToDoList(ToDoList toDoList);
        void Save();
    }
}
