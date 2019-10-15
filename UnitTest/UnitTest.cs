using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Entities;
using Xunit;

namespace UnitTest {
    public class UnitTest : BaseTest {
        [Fact]
        public void When_Login_succesfully_returns_ok_with_userInfo() {
            var cryptedPassword = GetMockEncryptor();
            var userInfo = new UserInfo() {
                Email = "ozturkfurkan1994@gmail.com",
                Password = cryptedPassword
            };
            GetMockUserInfo(userInfo);
            var result = valuesController.Login(userInfo);
            var okResult = result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<UserInfo>(okResult.Value);
        }

        [Fact]
        public void When_Login_fails_returns_badRequest_with_message() {
            GetMockEncryptor();
            var userInfo = new UserInfo() {
                Email = "ozturkfurkan1994@gmail.com",
                Password = "somePassword"
            };
            GetMockUserInfo(userInfo);
            var result = valuesController.Login(userInfo);
            var badResult = result as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<string>(badResult.Value);
        }

        [Fact]
        public void When_Login_fails_with_unexpected_problems_returns_badRequest_with_exception_message() {
            var cryptedPassword = GetMockEncryptor();
            var userInfo = new UserInfo() {
                Email = "ozturkfurkan1994@gmail.com",
                Password = "somePassword"
            };
            var exceptionMessage = "Error";
            GetMockUserInfoException(exceptionMessage);
            var result = valuesController.Login(userInfo);
            var badResult = result as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<string>(badResult.Value);
        }
    }
}
