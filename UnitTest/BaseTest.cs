using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI;
using WebAPI.Controllers;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace UnitTest {
    public class BaseTest {
        public Mock<IUserInfoRepository> userInfoRespository;
        public Mock<IToDoListRepository> todoListRepository;
        public Mock<IItemRepository> itemRespository;
        public Mock<IEncryptor> encryptor;
        public ValuesController valuesController;

        public BaseTest() {
            userInfoRespository = new Mock<IUserInfoRepository>();
            todoListRepository = new Mock<IToDoListRepository>();
            itemRespository = new Mock<IItemRepository>();
            encryptor = new Mock<IEncryptor>();
            valuesController = new ValuesController(userInfoRespository.Object, todoListRepository.Object, itemRespository.Object, encryptor.Object);
        }

        public void GetMockUserInfo(UserInfo userInfo) {
            userInfoRespository.Setup(x => x.GetUserInfoByEmail(It.IsAny<string>())).Returns(userInfo);
        }
        public string GetMockEncryptor() {
            var result = "cryptedPassword";
            encryptor.Setup(x => x.MD5Hash(It.IsAny<string>())).Returns(result);
            return result;
        }

        public void GetMockUserInfoException(string exceptionMessage) {
            userInfoRespository.Setup(x => x.GetUserInfoByEmail(It.IsAny<string>())).Throws(new Exception(exceptionMessage));
        }

        //public Mock<IItemRepository> GetMockItem(Item item) {
        //    itemRespository.Setup(x => x.GetItemById(It.IsAny<int>())).Returns(item);
        //    return itemRespository;
        //}

        //public Mock<IItemRepository> GetMockItems(List<Item> items) {
        //
        //}
    }
}
