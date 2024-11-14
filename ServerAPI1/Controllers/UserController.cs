using Core1;
using ServerAPI1.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI1.Controllers;


    [ApiController]
    [Route("/Listing")]

    public class UserController : ControllerBase
    {
        UserRepository repository;
        public UserController()
        {
            repository = new UserRepository();
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return (IEnumerable<User>)repository.GetAllUsers();
        }
        [HttpGet]
        [Route("AddUser")]
    public async Task AddUser(User user)
        {
            await repository.AddUser(user);

            //Mangler mere logik
        }


    }

