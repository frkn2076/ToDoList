using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        private readonly IUserInfoRepository userInfoRepository;
        private readonly IToDoListRepository toDoListRepository;
        private readonly IItemRepository itemRepository;
        private readonly IEncryptor encryptor;
        public ValuesController(IUserInfoRepository userInfoRepository, IToDoListRepository toDoListRepository, IItemRepository itemRepository, IEncryptor encryptor) {
            this.userInfoRepository = userInfoRepository;
            this.toDoListRepository = toDoListRepository;
            this.itemRepository = itemRepository;
            this.encryptor = encryptor;
        }

        [HttpPost("login")]
        public IActionResult Login(UserInfo userInfo) {
            try {
                var myUserInfo = userInfoRepository.GetUserInfoByEmail(userInfo.Email);
                var cryptoPassword = encryptor.MD5Hash(userInfo.Password);
                if (myUserInfo?.Password == cryptoPassword) {
                    return Ok(myUserInfo);
                }
                return BadRequest("Wrong Info");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registration")]
        public IActionResult Registration(UserInfo userInfo) {
            try {
                var myUserInfo = userInfoRepository.GetUserInfoByEmail(userInfo.Email);
                if (myUserInfo == null) {
                    var cryptoPassword = encryptor
                        .MD5Hash(userInfo.Password);
                    var newUserInfo = new UserInfo() {
                        Email = userInfo.Email,
                        Password = cryptoPassword
                    };
                    userInfoRepository.InsertUserInfo(newUserInfo);
                    userInfoRepository.Save();
                    return Ok("Registration is succesful");
                }
                    return BadRequest("This user is registered before");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("toDoLists/{email}")]
        public IActionResult GetToDoLists(string email) {
            try {
                var userInfo = userInfoRepository.GetUserInfoByEmail(email);
                if (userInfo != null) {
                    var toDoLists = userInfo.ToDoLists.ToList();
                    return Ok(toDoLists);
                }
                return BadRequest("User not found");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("items/{toDoListId}")]
        public IActionResult GetItems(int toDoListId) {
            try {
                var toDoList = toDoListRepository.GetToDoListById(toDoListId);
                if(toDoList != null) {
                    var items = toDoList.Items;
                    return Ok(items);
                }
                return BadRequest("To-Do List not found");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updateToDoList")]
        public IActionResult UpdateToDoList(ToDoList toDoList) {
            try {
                toDoListRepository.UpdateToDoList(toDoList);
                toDoListRepository.Save();
                return Ok();
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("deleteToDoList/{toDoListId}")]
        public IActionResult DeleteToDoList(int toDoListId) {
            try {
                toDoListRepository.DeleteToDoList(toDoListId);
                toDoListRepository.Save();
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("insertToDoList/{toDoListName}")]
        public IActionResult InsertToDoList([FromBody]string email, string toDoListName) {
            try {
                var toDoList = new ToDoList() {
                    Name = toDoListName,
                    CreateDate = DateTime.Now
                };
                var userInfo = userInfoRepository.GetUserInfoByEmail(email);
                var toDoLists = new List<ToDoList>();
                toDoLists.AddRange(userInfo.ToDoLists);
                toDoLists.Add(toDoList);
                var userInfoToUpdate = new UserInfo() {
                    Email = email,
                    Password = userInfo.Password,
                    ToDoLists = toDoLists
                };
                userInfoRepository.UpdateUserInfo(userInfoToUpdate);
                userInfoRepository.Save();
                return Ok(userInfoToUpdate);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updateUserInfo/{email}")]
        public IActionResult UpdateUserInfo([FromBody] List<ToDoList> toDoLists, string email) {
            try {
                var userInfo = userInfoRepository.GetUserInfoByEmail(email);
                userInfo.ToDoLists = toDoLists;
                userInfoRepository.UpdateUserInfo(userInfo);
                userInfoRepository.Save();
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
