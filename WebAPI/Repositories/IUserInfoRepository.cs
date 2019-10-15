using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Repositories {
    public interface IUserInfoRepository {
        IEnumerable<UserInfo> GetUserInfos();
        UserInfo GetUserInfoByEmail(string email);
        void InsertUserInfo(UserInfo userInfo);
        void DeleteUserInfo(string email);
        void UpdateUserInfo(UserInfo userInfo);
        void Save();
    }
}
