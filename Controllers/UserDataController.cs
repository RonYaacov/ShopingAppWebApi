
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ShopingBotClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopingAppApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]

    public class UserDataController : ControllerBase
    {

        [HttpPost]
        public StatusCodeResult Post([FromBody] Models.ExternalUserData userData)//create new user
        {
          var validation = new DataValidation.UserDataValidation();

          if(validation.usernameValidation(userData) && validation.PasswordValidation(userData))
          {
                var mongo = new ShopingBotClassLibrary.DataAccess.MongoDBUsers();
            if(mongo.CreateNewUser(new ShopingBotClassLibrary.Models.User(){username = userData.UserName, password = userData.Password}))            
                {
                    return new StatusCodeResult(200);
                }
                else
                {
                    return new StatusCodeResult(400);
                }
            
          }
          else
            {
                return new StatusCodeResult(400);
            }
                   
        } 
        
        [HttpGet]
        public List<ShopingBotClassLibrary.Models.User> Get()//find all users
        {
            var mongo = new ShopingBotClassLibrary.DataAccess.MongoDBUsers();
            var allUsers = mongo.FindAllUsers();

            return allUsers;
        }

        [HttpDelete]
        public string Delete()//delete all users
        {
            var mongo = new ShopingBotClassLibrary.DataAccess.MongoDBUsers();
            return mongo.DeleteAllUsers();
        }
        /*[HttpPut]
        public ShopingBotClassLibrary.Models.User Put(ShopingBotClassLibrary.Models.User val)// updateing user password or number of purchased prodacts
        {
            var mongo = new ShopingBotClassLibrary.DataAccess.MongoDBUsers();
            return mongo.UpdateUser(val);
        }
        */

        [HttpGet]
        [Route("GetByUsername")]
        public ShopingBotClassLibrary.Models.User GetByUsername([FromBody]string username)// find by the username
        {
            var mongo = new ShopingBotClassLibrary.DataAccess.MongoDBUsers();
            return mongo.FindUserByUsername(username);
        }

        [HttpDelete]
        [Route("DeleteByUsername")]
        public ShopingBotClassLibrary.Models.User DeleteUserByUsername([FromBody] string username)// delete user by the username
        {
            var mongo = new ShopingBotClassLibrary.DataAccess.MongoDBUsers();
            return mongo.DeleteUserByUsername(username);
        }

    }
}