using crudNET.Models;
using crudNET.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace crudNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorie _userRepositorie;

        public UserController(IUserRepositorie userRepositorie)
        {
            _userRepositorie = userRepositorie;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
           var users = await _userRepositorie.GetAllUser();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            var userById = await _userRepositorie.GetUserById(id);
            return Ok(userById);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel userModel)
        {
            var newUser = await _userRepositorie.AddUser(userModel);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            var updateUser = await _userRepositorie.UpdateUser(userModel, id);
            return Ok(updateUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            var deleted = await _userRepositorie.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
