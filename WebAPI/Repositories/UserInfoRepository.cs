using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;

namespace WebAPI.Repositories {
    public class UserInfoRepository : IUserInfoRepository {

        private readonly AppDBContext context;

        public UserInfoRepository(AppDBContext context) {
            this.context = context;
        }
        public IEnumerable<UserInfo> GetUserInfos() {
            return context.UserInfo.Include(x=>x.ToDoLists).ThenInclude(todoList => todoList.Items).ToList();
        }
        public UserInfo GetUserInfoByEmail(string email) {
            return context.UserInfo.Include(x => x.ToDoLists).ThenInclude(y => y.Items).FirstOrDefault(x => x.Email.Equals(email));
        }
        public void InsertUserInfo(UserInfo userInfo) {
            context.UserInfo.Add(userInfo);
        }
        public void DeleteUserInfo(string email) {
            UserInfo userInfo = context.UserInfo.Include(x=>x.ToDoLists).FirstOrDefault(x=>x.Email.Equals(email));
            context.UserInfo.Remove(userInfo);
        }
        public void UpdateUserInfo(UserInfo userInfo) {
            var userInfoToUpdate = context.UserInfo.Include(x => x.ToDoLists).ThenInclude(y => y.Items).FirstOrDefault(x => x.Email.Equals(userInfo.Email));
            userInfoToUpdate.ToDoLists = userInfo.ToDoLists;
            context.UserInfo.Update(userInfoToUpdate);
        }
        public void Save() {
            context.SaveChanges();
        }
    }
}
